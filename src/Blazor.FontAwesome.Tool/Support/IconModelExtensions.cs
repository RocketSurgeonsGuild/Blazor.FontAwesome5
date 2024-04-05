using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Humanizer;
using PrettyCode;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

internal static class IconModelExtensions
{
    internal static (string FileName, string Content) GetIconFileContent(
        this IGrouping<(string family, string style), IconModel> models,
        bool svgMode,
        string @namespace
    )
    {
        var label = GetStyleName(models.Key.family, models.Key.style);
        var sb = new StringBuilder(new(), 4, ' ', "\n", 0);

        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Immutable;");
        sb.AppendLine($"using Rocket.Surgery.Blazor.FontAwesome6;");
        sb.AppendLine($"namespace {@namespace};");
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Font Awesome {label} Icons");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
        sb.AppendLine($"public static partial class Fa{label.Pascalize()}");
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var s in models.OrderBy(z => z.Id))
            {
                s.AppendIconProperties(sb, svgMode, @namespace);
            }
        }

        sb.AppendLine("}");

        return ( $"Fa{label.Pascalize()}.cs", sb.ToString() );
    }

    internal static (string FileName, string Content) GetCategoryFileContent(
        this IEnumerable<IconModel> models,
        CategoryModel categoryModel,
        bool svgMode,
        string @namespace
    )
    {
        var sb = new StringBuilder(new(), 4, ' ', "\n", 0);

        sb.AppendLine("using System;");
        sb.AppendLine("using System.Collections.Immutable;");
        sb.AppendLine($"using Rocket.Surgery.Blazor.FontAwesome6;");
        sb.AppendLine($"namespace {@namespace}.Categories;");
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Font Awesome {categoryModel.Label} Category Icons");
        sb.AppendLine("/// </summary>");
        sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
        sb.AppendLine($"public static partial class Fa{categoryModel.Name.Humanize().Pascalize()}");
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var s in models.GroupBy(z => z.Id).OrderBy(z => z.Key))
            {
                AppendIconCategoryProperties(s, categoryModel, sb, svgMode, @namespace);
            }
        }

        sb.AppendLine("}");

        return ( $"Fa{categoryModel.Name.Humanize().Pascalize()}.cs", sb.ToString() );
    }

    private static void AppendIconProperties(this IconModel icon, StringBuilder sb, bool svgMode, string @namespace)
    {
        sb.AppendLine($"private static {GetIconClass(svgMode)}? f_{ToModelName(icon)};");
        EmitSummaryComment(icon, sb);
        if (svgMode)
        {
            string pathData = "ImmutableArray<string>.Empty";
            if (icon is { PathData.Length: 1 })
            {
                pathData = $"ImmutableArray.Create(\"{icon.PathData[0]}\"u8.ToArray().ToImmutableArray())";
            }
            else if (icon is { PathData.Length: 2 })
            {
                pathData =
                    $"ImmutableArray.Create(\"{icon.PathData[0]}\"u8.ToArray().ToImmutableArray(), \"{icon.PathData[1]}\"u8.ToArray().ToImmutableArray())";
            }

            sb.AppendLine(
                $"public static SvgIcon {ToModelName(icon)} => f_{ToModelName(icon)} ??= new SvgIcon(IconFamily.{icon.Family}, IconStyle.{icon.Style}, \"{icon.Id}\", \"{icon.Unicode}\", {icon.Width}, {icon.Height}, {pathData});"
            );
        }
        else
        {
            sb.AppendLine(
                $"public static Icon {ToModelName(icon)} => f_{ToModelName(icon)} ??= new Icon(IconFamily.{icon.Family}, IconStyle.{icon.Style}, \"{icon.Id}\", \"{icon.Unicode}\");"
            );
        }
        foreach (var alias in icon.Aliases)
        {
            EmitSummaryComment(icon, sb);
            sb.AppendLine($"public static {GetIconClass(svgMode)} {ToModelName(alias)} => global::{@namespace}.Fa{GetStyleName(icon)}.{ToModelName(icon)};");
        }
    }

    private static void AppendIconCategoryProperties(
        this IEnumerable<IconModel> icons,
        CategoryModel categoryModel,
        StringBuilder sb,
        bool svgMode,
        string @namespace
    )
    {
        IconModel rootIcon;
        {
            var icon = rootIcon = icons.First();
            sb.AppendLine("/// <summary>");
            sb.AppendLine($"/// {icon.Label}");
            sb.AppendLine($"/// <a href=\"{GetRootHref(icon)}\">{icon.Label}</a>");
            sb.AppendLine("/// </summary>");
            sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
            sb.AppendLine(
                $"public static partial class {ToModelName(icon)}{( categoryModel.Name.Equals(icon.Id, StringComparison.OrdinalIgnoreCase) ? "Icon" : "" )}"
            );
        }
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var style in icons
                                 .OrderBy(z => z.RawFamily)
                                 .ThenBy(z => z.Style))
            {
                var styleName = GetStyleName(style);
                sb.AppendLine("/// <summary>");
                sb.AppendLine($"/// <a href=\"{GetHref(style)}\">{style.Label}</a>");
                sb.AppendLine("/// </summary>");
                sb.AppendLine("[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]");
                sb.AppendLine($"public static {GetIconClass(svgMode)} {styleName} => global::{@namespace}.Fa{styleName}.{ToModelName(rootIcon)};");
            }
        }

        sb.AppendLine("}");
    }

    private static void EmitSummaryComment(IconModel icon, StringBuilder sb)
    {
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// <a href=\"{GetHref(icon)}\">{icon.Label}</a>");
        sb.AppendLine("/// </summary>");
    }

    static string GetStyleName(IconModel iconModel)
    {
        return GetStyleName(iconModel.RawFamily, iconModel.RawStyle);
    }

    static string GetIconClass(bool svgMode) => svgMode ? "SvgIcon" : "Icon";

    public static string GetStyleName(string rawFamily, string rawStyle)
    {
        if (rawFamily.Equals(Family.Duotone.ToString(), StringComparison.OrdinalIgnoreCase)) return Family.Duotone.ToString();
        var styleName = rawStyle.Pascalize();
        if (!rawFamily.Equals(Family.Classic.ToString(), StringComparison.OrdinalIgnoreCase)) styleName = rawFamily.Pascalize() + styleName;
        return styleName;
    }

    static string GetHref(IconModel icon)
    {
        var styleName = icon.RawFamily.Equals(Family.Duotone.ToString(), StringComparison.OrdinalIgnoreCase) ? Family.Duotone.ToString() : icon.RawStyle;
        return
            $"https://fontawesome.com/icons/{icon.Id}?f={( icon.Family == Family.Duotone ? "classic" : icon.RawFamily.ToLower() )}&amp;s={styleName.ToLower()}";
    }

    static string GetRootHref(IconModel icon) => $"https://fontawesome.com/icons/{icon.Id}";

    private static readonly Regex startsWithDigit = new Regex(@"^\d", RegexOptions.Compiled);

    private static string ToModelName(IconModel model) => ToModelName(model.Id);

    private static string ToModelName(string id)
    {
        if (id.Equals(nameof(Equals), StringComparison.OrdinalIgnoreCase))
        {
            return "equal".Pascalize();
        }

        if (startsWithDigit.IsMatch(id))
        {
            return "_" + id.Replace('-', ' ').Humanize().Pascalize();
        }

        return id.Replace('-', ' ').Humanize().Pascalize();
    }
}
