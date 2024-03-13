using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface ISvgIcon : IIcon, ISvgMaskIcon
{
    int Width { get; }
    int Height { get; }
    string Symbol { get; }
    ImmutableArray<string> VectorData { get; }
}