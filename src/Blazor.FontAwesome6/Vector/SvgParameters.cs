using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public record SvgParameters
{
    public SvgTransform Transform { get; init; } = SvgTransform.None;
    public string? Symbol { get; init; }
    public string? Title { get; init; }
    public string? TitleId { get; init; }
    public ImmutableArray<string> Classes { get; init; } = ImmutableArray<string>.Empty;
    public ImmutableDictionary<string, string> Attributes { get; init; } = ImmutableDictionary<string, string>.Empty;
    public ImmutableDictionary<string, string> Styles { get; init; } = ImmutableDictionary<string, string>.Empty;
}
