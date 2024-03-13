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
}