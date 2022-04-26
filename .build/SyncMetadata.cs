using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Humanizer;
using Nuke.Common;
using Nuke.Common.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Npm.NpmTasks;

public partial class Solution
{
    [Parameter] private string FontAwesomeToken { get; set; }

    private Target RegenerateFromMetadata => _ => _
       .Executes(
            () =>
            {
                foreach (var version in Enum.GetValues<FontAwesomeVersion>())
                {
                    var stringV = version switch
                    {
                        FontAwesomeVersion.V5 => "5",
                        FontAwesomeVersion.V6 => "6"
                    };
                    var metadata = new List<(string name, string nodeModule, string sourcePath)>
                    {
                        ( "Free", "@fortawesome/fontawesome-free", $@"src\Blazor.FontAwesome{stringV}.Free" ),
                    };
                    var packageDirectory = TemporaryDirectory / version.ToString();
                    EnsureCleanDirectory(packageDirectory);
                    WriteAllText(packageDirectory / "package.json", "{}");

                    if (!string.IsNullOrWhiteSpace(FontAwesomeToken))
                    {
                        metadata.Add(( "Pro", "@fortawesome/fontawesome-pro", $@"src\Blazor.FontAwesome{stringV}.Pro" ));
                        WriteAllText(
                            packageDirectory / ".npmrc", $@"@fortawesome:registry=https://npm.fontawesome.com/
//npm.fontawesome.com/:_authToken={FontAwesomeToken}"
                        );
                    }

                    foreach (var (name, module, sourcePath) in metadata)
                    {
                        GenerateFiles(name, module, sourcePath, stringV, packageDirectory, version);
                    }
                }

                static void GenerateFiles(
                    string name, string module, string sourcePath, string stringV, AbsolutePath packageDirectory, FontAwesomeVersion version
                )
                {
                    Npm($"install {module}@{stringV} --no-package-lock", packageDirectory);
                    var iconsData = packageDirectory / "node_modules" / module / "metadata" / "icons.yml";
                    var categoriesData = packageDirectory / "node_modules" / module / "metadata" / "categories.yml";
                    var @namespace = $@"Rocket.Surgery.Blazor.FontAwesome{stringV}.{name}";

                    var ds = new DeserializerBuilder()
                            .WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();

                    var icons = ds.Deserialize<IconDictionary>(ReadAllText(iconsData)).ToModels();
                    var categories = ds.Deserialize<CategoryDictionary>(ReadAllText(categoriesData)).ToModels();
                    var categoryLookup = categories.SelectMany(model => model.Icons.Select(icon => ( icon, model ))).ToLookup(z => z.icon, z => z.model);

                    //icons.GroupBy(z => string.Join(":", z.Styles.Count() == 1 && z.Styles.Single() == FontAwesomeStyle.Brands ? z.Styles : z.Styles.Except(new[] { FontAwesomeStyle.Brands }).OrderBy(z => z))).Dump();

                    static string UsingNamespace(string @namespace, string str, string stringV)
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine("using System;");
                        sb.AppendLine(CultureInfo.InvariantCulture, $"using Rocket.Surgery.Blazor.FontAwesome{stringV};");
                        sb.AppendLine(CultureInfo.InvariantCulture, $"namespace {@namespace}");
                        sb.AppendLine("{");
                        sb.Append(str);
                        sb.AppendLine("}");
                        return sb.ToString();
                    }

                    var sb = new StringBuilder();
                    foreach (var style in Enum.GetValues<FontAwesomeStyle>())
                    {
                        var pascalStylePrefix = ToPrefix(style, version).Replace("-", "_", StringComparison.InvariantCulture).Pascalize();
                        var styleIcons = icons.Where(z => z.Styles.Any(s => s == style));
                        if (!styleIcons.Any()) continue;
                        sb.AppendLine("    /// <summary>");
                        sb.AppendLine(CultureInfo.InvariantCulture, $"    /// Font Awesome {pascalStylePrefix} Icons");
                        sb.AppendLine("    /// </summary>");
                        sb.AppendLine(CultureInfo.InvariantCulture, $"    public enum {pascalStylePrefix}");
                        sb.AppendLine("    {");
                        foreach (var model in styleIcons)
                        {
                            var pascalModelName = ToModelName(model).Pascalize();
                            sb.AppendLine("        /// <summary>");
                            sb.AppendLine(CultureInfo.InvariantCulture, $"        /// {model.Label.Titleize()}");
                            sb.AppendLine("        /// </summary>");
                            sb.AppendLine("        /// <remarks>");
                            sb.AppendLine(CultureInfo.InvariantCulture, $"        /// {model.Name} - Available in {string.Join(", ", model.Styles)}");
                            sb.AppendLine("        /// </remarks>");
                            sb.AppendLine(CultureInfo.InvariantCulture, $"        [FontAwesome(IconStyle.{style}, \"{model.Name}\")]");
                            sb.AppendLine(CultureInfo.InvariantCulture, $"        {pascalModelName},");
                            sb.AppendLine("");
                        }

                        sb.AppendLine("    }");

                        if (style == FontAwesomeStyle.Brands)
                        {
                            WriteAllText(
                                RootDirectory
                              / $"{sourcePath.Replace(".Free", "", StringComparison.InvariantCulture).Replace(".Pro", "", StringComparison.InvariantCulture)}.{style}"
                              / $"{pascalStylePrefix}.cs",
                                UsingNamespace(
                                    @namespace.Replace(".Free", "", StringComparison.InvariantCulture).Replace(".Pro", "", StringComparison.InvariantCulture)
                                  + "." + style, sb.ToString(), stringV
                                )
                            );
                        }
                        else
                        {
                            WriteAllText(
                                RootDirectory / $"{sourcePath}.{style}" / $"{pascalStylePrefix}.cs", UsingNamespace(@namespace, sb.ToString(), stringV)
                            );
                        }

                        sb = new StringBuilder();
                    }
                }
            }
        );

    private static readonly Regex startsWithDigit = new Regex(@"^\d", RegexOptions.Compiled);
    private static string ToModelName(IconModel model)
    {
        if (model.Name.Equals(nameof(Equals), StringComparison.OrdinalIgnoreCase))
        {
            return "equal";
        }

        if (startsWithDigit.IsMatch(model.Name))
        {
            return "_" + model.Name.Replace('-', ' ');
        }

        return model.Name.Replace('-', ' ');
    }

    enum FontAwesomeVersion
    {
        V5, V6
    }

    private static string ToPrefix(FontAwesomeStyle style, FontAwesomeVersion version)
    {
        return ( style, version ) switch
        {
            (FontAwesomeStyle.Solid, FontAwesomeVersion.V6)   => "fa-solid",
            (FontAwesomeStyle.Regular, FontAwesomeVersion.V6) => "fa-regular",
            (FontAwesomeStyle.Light, FontAwesomeVersion.V6)   => "fa-light",
            (FontAwesomeStyle.Duotone, FontAwesomeVersion.V6) => "fa-duotone",
            (FontAwesomeStyle.Brands, FontAwesomeVersion.V6)  => "fa-brands",
            (FontAwesomeStyle.Thin, _)                        => "fa-thin",
            (FontAwesomeStyle.Solid, _)                       => "fas",
            (FontAwesomeStyle.Regular, _)                     => "far",
            (FontAwesomeStyle.Light, _)                       => "fal",
            (FontAwesomeStyle.Duotone, _)                     => "fad",
            (FontAwesomeStyle.Brands, _)                      => "fab",
            _                                                 => throw new NotSupportedException()
        };
    }
}

internal enum FontAwesomeStyle
{
    Solid,
    Regular,
    Light,
    Duotone,
    Brands,
    Thin
}


internal class IconDictionary : Dictionary<string, IconModelBase>
{
    public IEnumerable<IconModel> ToModels()
    {
        foreach (var item in this)
        {
            yield return new IconModel
            {
                Name = item.Key,
                //Changes = item.Value.Changes,
                Label = item.Value.Label,
                //Search = item.Value.Search,
                Styles = item.Value.Styles.Select(
                    z => Enum.TryParse(typeof(FontAwesomeStyle), z, true, out var style) ? (FontAwesomeStyle)style : throw new KeyNotFoundException(z)
                ).ToArray(),
                Unicode = item.Value.Unicode,
                
                //Private = item.Value.Private,
                //Voted = item.Value.Voted,
                //Ligatures = item.Value.Ligatures,
            };
            if (item.Value.Aliases is { } aliases)
            {
                foreach (var alias in aliases.Names ?? Enumerable.Empty<string>())
                {
                    yield return new IconModel
                    {
                        Name = alias,
                        //Changes = item.Value.Changes,
                        Label = item.Value.Label,
                        //Search = item.Value.Search,
                        Styles = item.Value.Styles.Select(
                            z => Enum.TryParse(typeof(FontAwesomeStyle), z, true, out var style) ? (FontAwesomeStyle)style : throw new KeyNotFoundException(z)
                        ).ToArray(),
                        Unicode = item.Value.Unicode,
                
                        //Private = item.Value.Private,
                        //Voted = item.Value.Voted,
                        //Ligatures = item.Value.Ligatures,
                    };
                }
            }
        }
    }
}

internal class IconModel
{
    public string Name { get; set; }

    //public IEnumerable<string> Changes { get; set; }
    public string Label { get; set; }

    //public SearchModel Search { get; set; }
    public IEnumerable<FontAwesomeStyle> Styles { get; set; }

    public string Unicode { get; set; }
    //public bool Voted { get; set; }
    //public IEnumerable<string> Ligatures { get; set; }
    //public bool Private { get; set; }
}

internal class IconModelBase
{
    public IEnumerable<string> Changes { get; set; }
    public string Label { get; set; }
    public SearchModel Search { get; set; }

    public HashSet<string> Styles { get; set; }
    public string Unicode { get; set; }
    public bool Voted { get; set; }
    public IEnumerable<string> Ligatures { get; set; }
    public bool Private { get; set; }
    public IconAliases? Aliases { get; set; }
}

class IconAliases
{
    public IEnumerable<string>? Names { get; set; }
    public IconUnicodes? Unicodes { get; set; }
}

class IconUnicodes
{
    public IEnumerable<string>? Composite { get; set; }
    public IEnumerable<string>? Primary { get; set; }
    public IEnumerable<string>? Secondary { get; set; }
}

internal class SearchModel
{
    public IEnumerable<string> Terms { get; set; }
}

internal class CategoryModel
{
    public HashSet<string> Icons { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
}

internal class CategoryDictionary : Dictionary<string, CategoryModelBase>
{
    public IEnumerable<CategoryModel> ToModels()
    {
        foreach (var item in this)
        {
            yield return new CategoryModel
            {
                Name = item.Key,
                Icons = new HashSet<string>(item.Value.Icons, StringComparer.OrdinalIgnoreCase),
                Label = item.Value.Label,
            };
        }
    }
}

internal class CategoryModelBase
{
    public IEnumerable<string> Icons { get; set; }
    public string Label { get; set; }
}
