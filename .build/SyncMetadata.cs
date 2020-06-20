using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Humanizer;
using Nuke.Common;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.IO.FileSystemTasks;
using Nuke.Common.Tools.Npm;
using static Nuke.Common.Tools.Npm.NpmTasks;
using Nuke.Common.IO;

public partial class Solution
{
    [Parameter] string FontAwesomeToken { get; set; }
    Target RegenerateFromMetadata => _ => _
        .Executes(() =>
        {
            var metadata = new List<(string name, string nodeModule, AbsolutePath sourcePath)>()
            {
                ("Free", "@fortawesome/fontawesome-free", (AbsolutePath)@"src\Blazor.FontAwesome5.Free"),
            };

            WriteAllText(TemporaryDirectory / "package.json", "{}");
            if (!string.IsNullOrWhiteSpace(FontAwesomeToken))
            {
                metadata.Add(("Pro", "@fortawesome/fontawesome-pro", (AbsolutePath)@"src\Blazor.FontAwesome5.Pro"));
                WriteAllText(TemporaryDirectory / ".npmrc", $@"@fortawesome:registry=https://npm.fontawesome.com/
//npm.fontawesome.com/:_authToken={FontAwesomeToken}");
            }

            foreach (var (name, module, sourcePath) in metadata)
            {
                Npm($"install {module} --no-package-lock", TemporaryDirectory);

                var iconsData = TemporaryDirectory / "node_modules" / module / "metadata" / "icons.yml";
                var categoriesData = TemporaryDirectory / "node_modules" / module / "metadata" / "categories.yml";
                var @namespace = $@"Rocket.Surgery.Blazor.FontAwesome5.{name}";

                var ds = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build();

                var icons = ds.Deserialize<IconDictionary>(ReadAllText(iconsData)).ToModels();
                var categories = ds.Deserialize<CategoryDictionary>(ReadAllText(categoriesData)).ToModels();
                var categoryLookup = categories.SelectMany(model => model.Icons.Select(icon => (icon, model))).ToLookup(z => z.icon, z => z.model);

                //icons.GroupBy(z => string.Join(":", z.Styles.Count() == 1 && z.Styles.Single() == FontAwesomeStyle.Brands ? z.Styles : z.Styles.Except(new[] { FontAwesomeStyle.Brands }).OrderBy(z => z))).Dump();

                static string UsingNamespace(string @namespace, string str)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("using System;");
                    sb.AppendLine("using Rocket.Surgery.Blazor.FontAwesome5;");
                    sb.AppendLine("using Rocket.Surgery.Blazor.FontAwesome5.Shared;");
                    sb.AppendLine($"namespace {@namespace}");
                    sb.AppendLine("{");
                    sb.Append(str);
                    sb.AppendLine("}");
                    return sb.ToString();
                }

                var sb = new StringBuilder();
                foreach (var style in Enum.GetValues(typeof(FontAwesomeStyle)).OfType<FontAwesomeStyle>())
                {
                    var styleIcons = icons.Where(z => z.Styles.Any(s => s == style));
                    if (!styleIcons.Any()) continue;
                    sb.AppendLine($"    /// <summary>");
                    sb.AppendLine($"    /// Font Awesome {ToPrefix(style).Pascalize()} Icons");
                    sb.AppendLine($"    /// </summary>");
                    sb.AppendLine($"    public enum {ToPrefix(style).Pascalize()}");
                    sb.AppendLine("    {");
                    foreach (var model in styleIcons)
                    {
                        sb.AppendLine($"        /// <summary>");
                        sb.AppendLine($"        /// {model.Label.Titleize()}");
                        sb.AppendLine($"        /// </summary>");
                        sb.AppendLine($"        /// <remarks>");
                        sb.AppendLine($"        /// {model.Name} - Available in {string.Join(", ", model.Styles)}");
                        sb.AppendLine($"        /// </remarks>");
                        sb.AppendLine($"        [FontAwesome(IconStyle.{style}, \"{model.Name}\")]");
                        sb.AppendLine($"        {ToModelName(model).Pascalize()},");
                        sb.AppendLine("");
                    }
                    sb.AppendLine("    }");

                    if (style == FontAwesomeStyle.Brands)
                    {
                        WriteAllText(RootDirectory / $"{sourcePath.ToString().Replace(".Free", "").Replace(".Pro", "")}.{style}" / $"{ToPrefix(style).Pascalize()}.cs", UsingNamespace(@namespace.Replace(".Free", "").Replace(".Pro", "") + "." + style, sb.ToString()));
                    }
                    else
                    {
                        WriteAllText(RootDirectory / $"{sourcePath}.{style}" / $"{ToPrefix(style).Pascalize()}.cs", UsingNamespace(@namespace, sb.ToString()));
                    }

                    sb = new StringBuilder();
                }
            }
        });

    string ToModelName(IconModel model)
    {
        if (model.Name.Equals(nameof(Equals), StringComparison.OrdinalIgnoreCase))
        {
            return "equal";
        }

        if (model.Name.StartsWith("5"))
        {
            return "_" + model.Name.Replace('-', ' ');
        }

        return model.Name.Replace('-', ' ');
    }

    string ToPrefix(FontAwesomeStyle style)
    {
        return style switch
        {
            FontAwesomeStyle.Solid => "fas",
            FontAwesomeStyle.Regular => "far",
            FontAwesomeStyle.Light => "fal",
            FontAwesomeStyle.Duotone => "fad",
            FontAwesomeStyle.Brands => "fab",
            _ => throw new NotSupportedException()
        };
    }

}

enum FontAwesomeStyle
{
    Solid,
    Regular,
    Light,
    Duotone,
    Brands
}


class IconDictionary : Dictionary<string, IconModelBase>
{

    public IEnumerable<IconModel> ToModels()
    {
        foreach (var item in this)
        {
            yield return new IconModel()
            {
                Name = item.Key,
                //Changes = item.Value.Changes,
                Label = item.Value.Label,
                //Search = item.Value.Search,
                Styles = item.Value.Styles.Select(z => Enum.TryParse(typeof(FontAwesomeStyle), z, true, out var style) ? (FontAwesomeStyle)style : throw new KeyNotFoundException(z)).ToArray(),
                Unicode = item.Value.Unicode,
                //Private = item.Value.Private,
                //Voted = item.Value.Voted,
                //Ligatures = item.Value.Ligatures,
            };
        }
    }
}

class IconModel
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

class IconModelBase
{
    public IEnumerable<string> Changes { get; set; }
    public string Label { get; set; }
    public SearchModel Search { get; set; }

    public HashSet<string> Styles { get; set; }
    public string Unicode { get; set; }
    public bool Voted { get; set; }
    public IEnumerable<string> Ligatures { get; set; }
    public bool Private { get; set; }
}

class SearchModel
{
    public IEnumerable<string> Terms { get; set; }
}

class CategoryModel
{
    public HashSet<string> Icons { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
}

class CategoryDictionary : Dictionary<string, CategoryModelBase>
{

    public IEnumerable<CategoryModel> ToModels()
    {
        foreach (var item in this)
        {
            yield return new CategoryModel()
            {
                Name = item.Key,
                Icons = new HashSet<string>(item.Value.Icons, StringComparer.OrdinalIgnoreCase),
                Label = item.Value.Label,
            };
        }
    }
}
class CategoryModelBase
{
    public IEnumerable<string> Icons { get; set; }
    public string Label { get; set; }
}