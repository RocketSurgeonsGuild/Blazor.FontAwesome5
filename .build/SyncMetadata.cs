using System.Collections.Immutable;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Humanizer;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Npm.NpmTasks;
using StringBuilder = PrettyCode.StringBuilder;

public partial class Pipeline
{
    [Parameter]
    private string FontAwesomeToken { get; set; }

    private Target RegenerateFromMetadata =>
        _ => _
//            .Requires(() => FontAwesomeToken)
           .Executes(
                () =>
                {
                    foreach (var version in Enum.GetValues<FontAwesomeVersion>())
                    {
                        var stringV = version switch { FontAwesomeVersion.V6 => "6", };
                        var packageDirectory = TemporaryDirectory / version.ToString();
                        packageDirectory.CreateDirectory();
                        ( packageDirectory / "package.json" ).WriteAllText("{}");
                        ( packageDirectory / ".npmrc" ).WriteAllText(
                            $@"@fortawesome:registry=https://npm.fontawesome.com/
//npm.fontawesome.com/:_authToken={FontAwesomeToken}"
                        );

//                        Npm($"install @fortawesome/fontawesome-pro@{stringV} --no-package-lock", packageDirectory);
                        var iconsData = packageDirectory / "node_modules" / "@fortawesome/fontawesome-pro" / "metadata" / "icon-families.json";
                        var categoriesData = packageDirectory / "node_modules" / "@fortawesome/fontawesome-pro" / "metadata" / "categories.yml";

                        var icons = JsonConvert.DeserializeObject<IconDictionary>(iconsData.ReadAllText()!).ToModels().ToImmutableArray();
                        var categories = new DeserializerBuilder()
                                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                                        .Build()
                                        .Deserialize<CategoryDictionary>(categoriesData.ReadAllText())
                                        .ToModels()
                                        .ToImmutableArray();

                        ( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Icons" ).CreateOrCleanDirectory();
                        ( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Categories" ).CreateOrCleanDirectory();
                        ( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Icons" ).CreateOrCleanDirectory();
                        ( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Categories" ).CreateOrCleanDirectory();

                        GenerateFiles(stringV, version, icons, categories);
                    }

                    static void GenerateFiles(
                        string stringV,
                        FontAwesomeVersion version,
                        ImmutableArray<IconModel> icons,
                        ImmutableArray<CategoryModel> categories
                    )
                    {
                        var freeFileBuilders = new Dictionary<string, StringBuilder>();
                        var proFileBuilders = new Dictionary<string, StringBuilder>();
                        var svgFileBuilders = new Dictionary<string, StringBuilder>();

                        StringBuilder GetFileBuilder(FontAwesomeKind kind, string name)
                        {
                            var d = kind switch
                                    {
                                        FontAwesomeKind.Free => freeFileBuilders,
                                        FontAwesomeKind.Pro => proFileBuilders,
                                        FontAwesomeKind.Svg => svgFileBuilders,
                                        _ => throw new NotSupportedException()
                                    };
                            if (d.TryGetValue(name, out var builder))
                            {
                                return builder;
                            }

                            return d[name] = new StringBuilder(new(), 4, ' ', "\n", 0);
                        }

                        static string UsingNamespaceWithClass(string @namespace, string str, string stringV, string name, string label)
                        {
                            var sb = new StringBuilder();
                            sb.AppendLine("using System;");
                            sb.AppendLine($"using Rocket.Surgery.Blazor.FontAwesome{stringV};");
                            sb.AppendLine($"namespace {@namespace};");
                            sb.AppendLine("/// <summary>");
                            sb.AppendLine($"/// Font Awesome {label} Icons");
                            sb.AppendLine("/// </summary>");
                            sb.AppendLine($"public static partial class Fa{name}");
                            sb.AppendLine("{");
                            using (sb.Indent())
                            {
                                sb.AppendLine(str);
                            }

                            sb.AppendLine("}");
                            return sb.ToString();
                        }

                        foreach (var icon in icons)
                        {
                            ProcessIcon(icon);
                        }

                        foreach (var (name, sb) in freeFileBuilders)
                        {
                            ( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Icons" / $"Fa{name}.cs" ).WriteAllText(
                                UsingNamespaceWithClass($"Rocket.Surgery.Blazor.FontAwesome{stringV}.Free", sb.ToString(), stringV, name, name)
                            );
                        }

                        foreach (var (name, sb) in svgFileBuilders)
                        {
                            ( RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg" / "Icons" / $"Fa{name}.cs" ).WriteAllText(
                                UsingNamespaceWithClass($"Rocket.Surgery.Blazor.FontAwesome{stringV}.Free", sb.ToString(), stringV, name, name)
                            );
                        }

                        foreach (var (name, sb) in proFileBuilders)
                        {
                            ( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Icons" / $"Fa{name}.cs" ).WriteAllText(
                                UsingNamespaceWithClass($"Rocket.Surgery.Blazor.FontAwesome{stringV}.Pro", sb.ToString(), stringV, name, name)
                            );
                        }

                        foreach (var category in categories)
                        {
                            var freeIcons = category
                                           .Icons.Join(icons, z => z, z => z.Name, (a, b) => b)
                                           .Where(z => z.FamilyStylesByLicense.Free.Any())
                                           .ToArray();
                            var proIcons = category.Icons.Join(icons, z => z, z => z.Name, (a, b) => b).Where(z => z.FamilyStylesByLicense.Pro.Any()).ToArray();
                            if (freeIcons.Any())
                            {
                                var sb = new StringBuilder(new(), 4, ' ', "\n", 0);
                                foreach (var icon in freeIcons)
                                {
                                    ProcessCategory(sb, icon, icon.FamilyStylesByLicense.Free, category, $"Rocket.Surgery.Blazor.FontAwesome{stringV}.Free");
                                }

                                ( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Categories" / $"Fa{category.Label.Dehumanize()}.cs" ).WriteAllText(
                                    UsingNamespaceWithClass(
                                        $"Rocket.Surgery.Blazor.FontAwesome{stringV}.Free.Categories",
                                        sb.ToString(),
                                        stringV,
                                        category.Label.Dehumanize(),
                                        category.Label
                                    )
                                );
                            }

                            if (proIcons.Any())
                            {
                                var sb = new StringBuilder(new(), 4, ' ', "\n", 0);
                                foreach (var icon in proIcons)
                                {
                                    ProcessCategory(sb, icon, icon.FamilyStylesByLicense.Pro, category, $"Rocket.Surgery.Blazor.FontAwesome{stringV}.Pro");
                                }

                                ( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Categories" / $"Fa{category.Label.Dehumanize()}.cs" ).WriteAllText(
                                    UsingNamespaceWithClass(
                                        $"Rocket.Surgery.Blazor.FontAwesome{stringV}.Pro.Categories",
                                        sb.ToString(),
                                        stringV,
                                        category.Label.Dehumanize(),
                                        category.Label
                                    )
                                );
                            }
                        }

                        void ProcessIcon(IconModel icon)
                        {
                            if (icon.FamilyStylesByLicense.Free.Any())
                            {
                                var fqnamespace = $"Rocket.Surgery.Blazor.FontAwesome{stringV}.Free";
                                foreach (var family in icon.FamilyStylesByLicense.Free)
                                {
                                    ProcessIconFamily(FontAwesomeKind.Free, icon, family, fqnamespace);
                                }
                            }

                            if (icon.FamilyStylesByLicense.Pro.Any())
                            {
                                var fqnamespace = $"Rocket.Surgery.Blazor.FontAwesome{stringV}.Pro";
                                foreach (var family in icon.FamilyStylesByLicense.Pro)
                                {
                                    ProcessIconFamily(FontAwesomeKind.Pro, icon, family, fqnamespace);
                                }
                            }
                        }

                        void ProcessIconFamily(FontAwesomeKind kind, IconModel icon, FontAwesomeFamilyStyle family, string fqnamespace)
                        {
                            var builder = GetFileBuilder(kind, GetStyleName(family));
                            if (kind == FontAwesomeKind.Free)
                            {
                                WriteIcon(builder, icon, family, fqnamespace);
                                WriteSvgIcon(GetFileBuilder(FontAwesomeKind.Svg, GetStyleName(family)), icon, family, fqnamespace);
                                return;
                            }
                            // we won't write the svg for the pro icons because that would break the license
                            // a source generator will be built to allow you to get the svg icons in your project or a custom library
                            WriteIcon(builder, icon, family, fqnamespace);
                        }

                        void ProcessCategory(
                            StringBuilder sb,
                            IconModel icon,
                            IEnumerable<FontAwesomeFamilyStyle> styles,
                            CategoryModel category,
                            string fqnamespace
                        )
                        {
                            // https://fontawesome.com/icons/sparkles?f=classic&s=duotone
                            var modelName = ToModelName(icon);
                            sb.AppendLine("/// <summary>");
                            sb.AppendLine($"/// {icon.Label}");
                            sb.AppendLine($"/// <a href=\"{GetHref(icon)}\">{icon.Label}</a>");
                            sb.AppendLine("/// </summary>");
                            sb.AppendLine($"public static partial class {modelName}Icon");
                            sb.AppendLine("{");
                            using (sb.Indent())
                            {
                                foreach (var style in styles)
                                {
                                    var styleName = GetStyleName(style);
                                    sb.AppendLine("/// <summary>");
                                    sb.AppendLine($"/// <a href=\"{GetHref(icon, style)}\">{icon.Label}</a>");
                                    sb.AppendLine("/// </summary>");
                                    sb.AppendLine($"public static Icon {styleName} => global::{fqnamespace}.Fa{styleName}.{modelName};");
                                }
                            }

                            sb.AppendLine("}");
                        }

                        static void WriteIcon(StringBuilder sb, IconModel icon, FontAwesomeFamilyStyle style, string fqnamespace)
                        {
                            var modelName = ToModelName(icon);
                            var styleName = GetStyleName(style);
                            if (icon.Alias == icon.Name)
                            {
                                sb.AppendLine($"private static Icon? {modelName}f;");
                                sb.AppendLine("/// <summary>");
                                sb.AppendLine($"/// <a href=\"{GetHref(icon, style)}\">{icon.Label}</a>");
                                sb.AppendLine("/// </summary>");
                                sb.AppendLine(
                                    $"public static Icon {modelName} => {modelName}f ??= new Icon(IconFamily.{style.Family}, IconStyle.{style.Style}, \"{icon.Name}\", \"\");"
                                );
                            }
                            else
                            {
                                sb.AppendLine("/// <summary>");
                                sb.AppendLine($"/// <a href=\"{GetHref(icon, style)}\">{icon.Label}</a>");
                                sb.AppendLine("/// </summary>");
                                sb.AppendLine(
                                    $"public static Icon {modelName} => global::{fqnamespace}.Fa{styleName}.{ToAliasName(icon)};"
                                );
                            }
                        }

                        static void WriteSvgIcon(StringBuilder sb, IconModel icon, FontAwesomeFamilyStyle style, string fqnamespace)
                        {
                            var modelName = ToModelName(icon);
                            var styleName = GetStyleName(style);
                            if (icon.Alias == icon.Name)
                            {
                            var svg = GetSvgData(icon, style);
                            string[] paths = svg.Path as string[] ?? [(string)svg.Path,];
                            var vectorData = paths is { Length: 1 } ? $"new string[] {{\"{paths[0]}\"}}" : $"new string[] {{\"{string.Join("\", \"", paths)}\"}}";
                                sb.AppendLine($"private static SvgIcon? {modelName}f;");
                                sb.AppendLine("/// <summary>");
                                sb.AppendLine($"/// <a href=\"{GetHref(icon, style)}\">{icon.Label}</a>");
                                sb.AppendLine("/// </summary>");
                                sb.AppendLine(
                                    $"public static SvgIcon {modelName} => {modelName}f ??= new SvgIcon(IconFamily.{style.Family}, IconStyle.{style.Style}, \"{icon.Name}\", \"\", {svg.Width}, {svg.Height}, {vectorData});"
                                );
                            }
                            else
                            {
                                sb.AppendLine("/// <summary>");
                                sb.AppendLine($"/// <a href=\"{GetHref(icon, style)}\">{icon.Label}</a>");
                                sb.AppendLine("/// </summary>");
                                sb.AppendLine(
                                    $"public static SvgIcon {modelName} => global::{fqnamespace}.Fa{styleName}.{ToAliasName(icon)};"
                                );
                            }
                        }
                    }

                    static SvgData GetSvgData(IconModel icon, FontAwesomeFamilyStyle style)
                    {
                        return icon.Svgs[style.Family][style.Style];
                    }

                    static string GetStyleName(FontAwesomeFamilyStyle style)
                    {
                        var styleName = style.Family == FontAwesomeFamily.Duotone ? "Duotone" : style.Style.ToString();
                        if (style.Family == FontAwesomeFamily.Sharp) styleName = "Sharp" + styleName;
                        return styleName;
                    }

                    static string GetHref(IconModel icon, FontAwesomeFamilyStyle? style = null)
                    {
                        if (style is null)
                        {
                            return $"https://fontawesome.com/icons/{icon.Alias}";
                        }
                        var styleName = style.Family == FontAwesomeFamily.Duotone ? "Duotone" : style.Style.ToString();
                        return
                            $"https://fontawesome.com/icons/{icon.Alias}?f={( style.Family == FontAwesomeFamily.Duotone ? "classic" : style.Family.ToString().ToLower() )}&amp;s={styleName.ToLower()}";
                    }
                }
            );


    private static readonly Regex startsWithDigit = new Regex(@"^\d", RegexOptions.Compiled);

    private static string ToModelName(IconModel model)
    {
        if (model.Alias.Equals(nameof(Equals), StringComparison.OrdinalIgnoreCase))
        {
            return "equal".Dehumanize();
        }

        if (startsWithDigit.IsMatch(model.Name))
        {
            return "_" + model.Name.Replace('-', ' ').Dehumanize();
        }

        return model.Name.Replace('-', ' ').Dehumanize();
    }

    private static string ToAliasName(IconModel model)
    {
        if (model.Alias.Equals(nameof(Equals), StringComparison.OrdinalIgnoreCase))
        {
            return "equal".Dehumanize();
        }

        if (startsWithDigit.IsMatch(model.Alias))
        {
            return "_" + model.Alias.Replace('-', ' ').Dehumanize();
        }

        return model.Alias.Replace('-', ' ').Dehumanize();
    }

    enum FontAwesomeVersion
    {
        V6
    }

    private static string ToPrefix(FontAwesomeFamilyStyle style, FontAwesomeVersion version)
    {
        return ( style.Family, style.Style, version ) switch
               {
                   (_, FontAwesomeStyle.Brands, FontAwesomeVersion.V6)                          => "fa-brands",
                   (FontAwesomeFamily.Duotone, _, FontAwesomeVersion.V6)                        => "fa-duotone",
                   (FontAwesomeFamily.Classic, FontAwesomeStyle.Thin, FontAwesomeVersion.V6)    => "fa-thin",
                   (FontAwesomeFamily.Classic, FontAwesomeStyle.Light, FontAwesomeVersion.V6)   => "fa-light",
                   (FontAwesomeFamily.Classic, FontAwesomeStyle.Regular, FontAwesomeVersion.V6) => "fa-regular",
                   (FontAwesomeFamily.Classic, FontAwesomeStyle.Solid, FontAwesomeVersion.V6)   => "fa-solid",
                   (FontAwesomeFamily.Sharp, FontAwesomeStyle.Thin, FontAwesomeVersion.V6)      => "fa-sharp fa-thin",
                   (FontAwesomeFamily.Sharp, FontAwesomeStyle.Light, FontAwesomeVersion.V6)     => "fa-sharp fa-light",
                   (FontAwesomeFamily.Sharp, FontAwesomeStyle.Regular, FontAwesomeVersion.V6)   => "fa-sharp fa-regular",
                   (FontAwesomeFamily.Sharp, FontAwesomeStyle.Solid, FontAwesomeVersion.V6)     => "fa-sharp fa-solid",
                   _                                                                            => throw new NotSupportedException()
               };
    }

    private static string ToClassName(FontAwesomeFamilyStyle style, FontAwesomeVersion version)
    {
        return ( style.Family, style.Style, version ) switch
               {
                   (_, FontAwesomeStyle.Brands, FontAwesomeVersion.V6)   => "Brands",
                   (FontAwesomeFamily.Duotone, _, FontAwesomeVersion.V6) => "Duotone",
                   (_, FontAwesomeStyle.Thin, FontAwesomeVersion.V6)     => "Thin",
                   (_, FontAwesomeStyle.Light, FontAwesomeVersion.V6)    => "Light",
                   (_, FontAwesomeStyle.Regular, FontAwesomeVersion.V6)  => "Regular",
                   (_, FontAwesomeStyle.Solid, FontAwesomeVersion.V6)    => "Solid",
                   _                                                     => throw new NotSupportedException()
               };
    }
}

public enum FontAwesomeKind
{
    Free, Pro, Svg
}

public enum FontAwesomeFamily
{
    Classic,
    Duotone,
    Sharp
}

public enum FontAwesomeStyle
{
    Solid,
    Regular,
    Light,
    Thin,
    Brands
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
                Alias = item.Key,
                Label = item.Value.Label,
                FamilyStylesByLicense = item.Value.FamilyStylesByLicense,
                Unicode = item.Value.Unicode,
                Svgs = item.Value.Svgs,
            };
            if (item.Value.Aliases is { } aliases)
            {
                foreach (var alias in aliases.Names ?? Enumerable.Empty<string>())
                {
                    yield return new IconModel
                    {
                        Name = alias,
                        Alias = item.Key,
                        Label = item.Value.Label,
                        FamilyStylesByLicense = item.Value.FamilyStylesByLicense,
                        Unicode = item.Value.Unicode,
                        Svgs = item.Value.Svgs,
                    };
                }
            }
        }
    }
}

internal class IconModel
{
    public string Name { get; set; }
    public string Alias { get; set; }
    public string Label { get; set; }
    public FamilyStylesByLicense FamilyStylesByLicense { get; set; } = new FamilyStylesByLicense();
    public string Unicode { get; set; }

    public Dictionary<FontAwesomeFamily, IDictionary<FontAwesomeStyle, SvgData>> Svgs { get; set; } = new ();
}

internal class IconModelBase
{
    public string Label { get; set; }
    public SearchModel Search { get; set; } = new SearchModel();
    public FamilyStylesByLicense FamilyStylesByLicense { get; set; } = new FamilyStylesByLicense();
    public string? Unicode { get; set; }
    public IEnumerable<string> Ligatures { get; set; } = Enumerable.Empty<string>();
    public bool Private { get; set; }
    public IconAliases Aliases { get; set; } = new IconAliases();

    public Dictionary<FontAwesomeFamily, IDictionary<FontAwesomeStyle, SvgData>> Svgs { get; set; } = new ();
}
internal class SvgData
{
    public int LastModified { get; set; }
    public string Raw { get; set; }
    public int[] ViewBox { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public object Path { get; set; }
}


public class FamilyStylesByLicense
{
    public IEnumerable<FontAwesomeFamilyStyle> Free { get; set; } = Enumerable.Empty<FontAwesomeFamilyStyle>();
    public IEnumerable<FontAwesomeFamilyStyle> Pro { get; set; } = Enumerable.Empty<FontAwesomeFamilyStyle>();
}

public class FontAwesomeFamilyStyle
{
    public FontAwesomeFamily Family { get; set; }
    public FontAwesomeStyle Style { get; set; }
}

class IconAliases
{
    public IEnumerable<string> Names { get; set; } = Enumerable.Empty<string>();
    public IconUnicodes Unicodes { get; set; } = new IconUnicodes();
}

class IconUnicodes
{
    public IEnumerable<string> Composite { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> Primary { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> Secondary { get; set; } = Enumerable.Empty<string>();
}

internal class SearchModel
{
    public IEnumerable<string> Terms { get; set; } = Enumerable.Empty<string>();
}

internal class CategoryModel
{
    public HashSet<string> Icons { get; set; } = new();
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
