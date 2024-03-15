using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Humanizer;
using PrettyCode;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public record IconModel
{
    /// <summary>
    /// The identifying name of an icon, like "coffee" or "bicycle".
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Usually, a more human readable representation of this icon.
    ///
    /// For example, the icon with id "coffee-pot" has a label of "Coffee Pot".
    /// </summary>
    public required string Label { get; init; }

    /// <summary>
    /// The family of the icon, like "solid" or "brands".
    /// </summary>
    public Family Family => Enum.TryParse<Family>(RawFamily, true, out var family) ? family : default;

    /// <summary>
    /// The family of the icon, like "solid" or "brands".
    /// </summary>
    public required string RawFamily { get; init; }

    /// <summary>
    /// The style of the icon, like "solid" or "light".
    /// </summary>
    public Style Style => Enum.TryParse<Style>(RawStyle, true, out var style) ? style : default;

    /// <summary>
    /// The style of the icon, like "solid" or "light".
    /// </summary>
    public required string RawStyle { get; init; }

    /// <summary>
    /// Unicode by which this icon can be identified--just the hex digits as a string.
    ///
    /// For example, the value of this field for the coffee icon is "f0f4".
    /// </summary>
    public required string Unicode { get; init; }

    /// <summary>
    /// The SVG's viewBox height. It can be used as the fourth parameter
    /// in an `<svg>` `viewBox` attribute, like this:
    ///
    /// ```
    /// <svg viewBox="0 0 {{ width }} {{ height }}" . . .>
    ///   ...
    /// </svg>
    /// ```
    /// </summary>
    public required int Height { get; init; }

    /// <summary>
    /// The SVG's viewBox width. It can be used as the third parameter
    /// in an `<svg>` `viewBox` attribute, like this:
    ///
    /// ```
    /// <svg viewBox="0 0 {{ width }} {{ height }}" . . .>
    ///   ...
    /// </svg>
    /// ```
    /// </summary>
    public required int Width { get; init; }

    /// <summary>
    /// A monotone icon has exactly one SVG path, the primary path.
    ///
    /// A duotone icon always has two `pathData` elements, and the following rules apply:
    /// - The first list element corresponds to the icon's secondary path, and the second
    /// list element corresponds to the icon's primary path.
    ///
    ///     Heads up! This might seem counterintuitive: the first path (at list index 0)
    /// is the _second_ layer for a duotone icon.
    ///
    /// - Either path may be an empty string, indicating no path for
    /// that layer.
    ///
    ///     Some duotone icons have only a primary path, while other duotone
    /// icons have only a secondary path.
    /// </summary>
    public required ImmutableArray<string> PathData { get; init; }

    /// <summary>
    /// A single term that fully-specifies a familyStyle. This can be used in the Font Awesome JavaScript API
    /// where a `prefix` is expected. It can also be used as a CSS class.
    /// </summary>
    public required string Prefix { get; init; }

    /// <summary>
    /// A single term that fully-specifies a familyStyle. This can be used in the Font Awesome JavaScript API
    /// where a `prefix` is expected. It can also be used as a CSS class. This is the longer version fa-xyz
    /// </summary>
    public required string LongPrefix { get; init; }

    /// <summary>
    /// The aliases for the icon
    /// </summary>
    public required ImmutableArray<string> Aliases { get; init; }

    /// <summary>
    /// The categories the icon belongs to
    /// </summary>
    public required ImmutableHashSet<CategoryModel> Categories { get; init; }
}

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
        sb.AppendLine($"private static {GetIconClass(svgMode)}? {ToModelName(icon)}f;");
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
                pathData = $"ImmutableArray.Create(\"{icon.PathData[0]}\"u8.ToArray().ToImmutableArray(), \"{icon.PathData[1]}\"u8.ToArray().ToImmutableArray())";
            }
            sb.AppendLine(
                $"public static SvgIcon {ToModelName(icon)} => {ToModelName(icon)}f ??= new SvgIcon(IconFamily.{icon.Family}, IconStyle.{icon.Style}, \"{icon.Id}\", \"{icon.Unicode}\", {icon.Width}, {icon.Height}, {pathData});"
            );
        }
        else
        {
            sb.AppendLine(
                $"public static Icon {ToModelName(icon)} => {ToModelName(icon)}f ??= new Icon(IconFamily.{icon.Family}, IconStyle.{icon.Style}, \"{icon.Id}\", \"{icon.Unicode}\");"
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
        var icon = icons.First();
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// {icon.Label}");
        sb.AppendLine($"/// <a href=\"{GetRootHref(icon)}\">{icon.Label}</a>");
        sb.AppendLine("/// </summary>");
        sb.AppendLine(
            $"public static partial class {ToModelName(icon)}{( categoryModel.Name.Equals(icon.Id, StringComparison.OrdinalIgnoreCase) ? "Icon" : "" )}"
        );
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var style in icons
                                 .OrderBy(z => z.RawFamily)
                                 .ThenBy(z => z.Style))
            {
                var styleName = GetStyleName(style);
                sb.AppendLine("/// <summary>");
                sb.AppendLine($"/// <a href=\"{GetHref(icon)}\">{icon.Label}</a>");
                sb.AppendLine("/// </summary>");
                sb.AppendLine($"public static {GetIconClass(svgMode)} {styleName} => global::{@namespace}.Fa{styleName}.{ToModelName(icon)};");
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
            return "equal".Dehumanize();
        }

        if (startsWithDigit.IsMatch(id))
        {
            return "_" + id.Replace('-', ' ').Dehumanize();
        }

        return id.Replace('-', ' ').Dehumanize();
    }
}
