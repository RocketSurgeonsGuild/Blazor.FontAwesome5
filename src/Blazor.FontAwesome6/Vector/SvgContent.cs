using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public record SvgContent
{
    public string? Tag { get; init; }
    public ImmutableArray<SvgContent> Children { get; init; } = ImmutableArray<SvgContent>.Empty;
    public ImmutableDictionary<string, string> Attributes { get; init; } = ImmutableDictionary<string, string>.Empty;
    public ImmutableArray<string> Classes { get; set; } = ImmutableArray<string>.Empty;
    public ImmutableDictionary<string, string> Styles { get; set; } = ImmutableDictionary<string, string>.Empty;
    public string? Text { get; init; }

    public string ToHtml()
    {
        var styles = string.Join(";", Styles.OrderBy(z => z.Key).Select(x => $"{x.Key}:{x.Value}"));
        var classes = string.Join(" ", Classes.OrderBy(z => z));
        var attributes = string.Join(" ", Attributes
                                         .SetItem("style", Attributes.TryGetValue("style", out var s) ? $"{s};{styles}" : styles)
                                         .SetItem("class", Attributes.TryGetValue("class", out var c) ? $"{c} {classes}".Trim() : classes)
                                         .OrderBy(z => z.Key)
                                         .Select(x => $"{x.Key}=\"{x.Value}\""));
        var content = string.Join("", Children.Select(x => x.ToHtml()));
        return $"<{Tag} {attributes}>{Text}{content}</{Tag}>";
    }
}
