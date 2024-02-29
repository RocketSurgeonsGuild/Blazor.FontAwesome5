using Rocket.Surgery.Blazor.FontAwesome6;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface ITransformIcon
{
    double Grow { get; }
    double Shrink { get; }
    double Rotate { get; }
    double Up { get; }
    double Down { get; }
    double Left { get; }
    double Right { get; }
    IconFlip? FlipTransform { get; }
}
