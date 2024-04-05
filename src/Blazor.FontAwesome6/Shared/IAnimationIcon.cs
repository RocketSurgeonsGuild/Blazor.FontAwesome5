// ReSharper disable once CheckNamespace

namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface IAnimationIcon
{
    IconAnimation Animation { get; }
    string? AnimationDelay { get; }
    string? AnimationDirection { get; }
    string? AnimationDuration { get; }
    string? AnimationIterationCount { get; }
    string? AnimationTiming { get; }

    double? BeatScale { get; }
    double? FadeOpacity { get; }
    double? BeatFadeOpacity { get; }
    double? BeatFadeScale { get; }

    double? BounceRebound { get; }
    double? BounceHeight { get; }
    double? BounceStartScaleX { get; }
    double? BounceStartScaleY { get; }
    double? BounceJumpScaleX { get; }
    double? BounceJumpScaleY { get; }
    double? BounceLandScaleX { get; }
    double? BounceLandScaleY { get; }

    double? FlipX { get; }
    double? FlipY { get; }
    double? FlipZ { get; }
    string? FlipAngle { get; }
}