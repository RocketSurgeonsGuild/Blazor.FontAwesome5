namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface IIcon : ITransformIcon, IAnimationIcon, ISharedIcon
{
    IconFamily Family { get; }
    IconStyle Style { get; }
    string Name { get; }
    IconPull Pull { get; }
    bool Inverse { get; }
    string? InverseColor { get; }
    Icon? Mask { get; }
    bool SwapOpacity { get; }
    double? PrimaryOpacity { get; }
    double? SecondaryOpacity { get; }
    string? PrimaryColor { get; }
    string? SecondaryColor { get; }

    string? PullMargin { get; }

    string? StackZIndex { get; }
    string? RotateBy { get; }
}
