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

public static class IconModelExtensions
{
    public static (string FileName, string Content) GetIconFileContent(this IEnumerable<IconModel> models, string family, string style, string @namespace) =>
        GetIconFileContentInternal(models, family, style, false, @namespace);

    public static (string FileName, string Content) GetSvgIconFileContent(this IEnumerable<IconModel> models, string family, string style, string @namespace) =>
        GetIconFileContentInternal(models, family, style, true, @namespace);

    private static (string FileName, string Content) GetIconFileContentInternal(this IEnumerable<IconModel> models, string family, string style, bool svgMode, string @namespace)
    {
        var label = GetStyleName(family, style);
        var sb = new StringBuilder(new(), 4, ' ', "\n", 0);

        sb.AppendLine("using System;");
        sb.AppendLine($"using Rocket.Surgery.Blazor.FontAwesome6;");
        sb.AppendLine($"namespace {@namespace};");
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// Font Awesome {label} Icons");
        sb.AppendLine("/// </summary>");
        sb.AppendLine($"public static partial class Fa{label.Pascalize()}");
        sb.AppendLine("{");
        using (sb.Indent())
        {
            foreach (var s in models)
            {
                if (svgMode)
                    s.AppendSvgIconProperties(sb, @namespace);
                else
                    s.AppendIconProperties(sb, @namespace);
            }
        }

        sb.AppendLine("}");

        return ($"Fa{label.Pascalize()}.cs", sb.ToString());
    }

    public static void AppendIconProperties(this IconModel icon, StringBuilder sb, string @namespace)
    {
        EmitSummaryComment(icon, sb);
        sb.AppendLine(
            $"public static Icon {ToModelName(icon)} => {ToModelName(icon)}f ??= new Icon(IconFamily.{icon.Family}, IconStyle.{icon.Style}, \"{icon.Id}\", \"{icon.Unicode}\");"
        );
        foreach (var alias in icon.Aliases)
        {
            EmitSummaryComment(icon, sb);
            EmitAlias(icon, alias, "Icon", sb, @namespace);
        }
    }

    public static void AppendSvgIconProperties(this IconModel icon, StringBuilder sb, string @namespace)
    {
        EmitSummaryComment(icon, sb);
        sb.AppendLine(
            $"public static SvgIcon {ToModelName(icon)} => {ToModelName(icon)}f ??= new SvgIcon(IconFamily.{icon.Family}, IconStyle.{icon.Style}, \"{icon.Id}\", \"{icon.Unicode}\", {icon.Width}, {icon.Height}, [\"{string.Join("\", \"", icon.PathData)}\"]);"
        );
        foreach (var alias in icon.Aliases)
        {
            EmitSummaryComment(icon, sb);
            EmitAlias(icon, alias, "SvgIcon", sb, @namespace);
        }
    }

    static void EmitSummaryComment(IconModel icon, StringBuilder sb)
    {
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// <a href=\"{GetHref(icon)}\">{icon.Label}</a>");
        sb.AppendLine("/// </summary>");
    }

    static void EmitAlias(IconModel icon, string alias, string type, StringBuilder sb, string @namespace)
    {
        sb.AppendLine($"public static {type} {alias.Pascalize()} => global::{@namespace}.Fa{GetStyleName(icon)}.{ToModelName(icon)};");
    }

    static string GetStyleName(IconModel iconModel)
    {
        var styleName = iconModel.Family == Family.Duotone ? "Duotone" : iconModel.RawStyle;
        if (iconModel.Family != Family.Classic) styleName = iconModel.Family + styleName;
        return styleName;
    }

    public static string GetStyleName(string rawFamily, string rawStyle)
    {
        var styleName = Enum.TryParse<Family>(rawFamily, out var f) && f == Family.Duotone ? "Duotone" : rawStyle;
        if (Enum.TryParse<Family>(rawFamily, out var f_) && f_ != Family.Classic) styleName = rawFamily + styleName;
        return styleName;
    }

    static string GetHref(IconModel icon)
    {
        var styleName = icon.Family == Family.Duotone ? "Duotone" : icon.RawStyle;
        return
            $"https://fontawesome.com/icons/{icon.Id}?f={( icon.Family == Family.Duotone ? "classic" : icon.RawFamily.ToLower() )}&amp;s={styleName.ToLower()}";
    }

    static string GetRootHref(IconModel icon) => $"https://fontawesome.com/icons/{icon.Id}";

    private static readonly Regex startsWithDigit = new Regex(@"^\d", RegexOptions.Compiled);

    private static string ToModelName(IconModel model)
    {
        if (model.Id.Equals(nameof(Equals), StringComparison.OrdinalIgnoreCase))
        {
            return "equal".Dehumanize();
        }

        if (startsWithDigit.IsMatch(model.Id))
        {
            return "_" + model.Id.Replace('-', ' ').Dehumanize();
        }

        return model.Id.Replace('-', ' ').Dehumanize();
    }
}
