using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

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
