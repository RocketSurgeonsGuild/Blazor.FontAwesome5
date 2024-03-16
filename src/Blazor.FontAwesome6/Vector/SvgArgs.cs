using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public record SvgArgs
{
    public required ImmutableArray<SvgContent> Children { get; init; } = ImmutableArray<SvgContent>.Empty;
    public ImmutableDictionary<string, string> Attributes { get; init; } = ImmutableDictionary<string, string>.Empty;
    public ImmutableArray<string> Classes { get; set; } = ImmutableArray<string>.Empty;
    public ImmutableDictionary<string, string> Styles { get; set; } = ImmutableDictionary<string, string>.Empty;
    public required ISvgIcon Icon { get; init; }
    public required SvgContent IconContent { get; init; }
    public ISvgIcon? Mask { get; init; }
    public required SvgContent? MaskContent { get; init; }
    public SvgTransform Transform { get; init; } = SvgTransform.None;
}

