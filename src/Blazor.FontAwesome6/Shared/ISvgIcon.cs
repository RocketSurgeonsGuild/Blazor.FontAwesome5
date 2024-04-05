using System.Collections.Immutable;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface ISvgIcon : IIcon, ISvgMaskIcon
{
    int Width { get; }
    int Height { get; }
    ImmutableArray<ImmutableArray<byte>> VectorData { get; }
}
