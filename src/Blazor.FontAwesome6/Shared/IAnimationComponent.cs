// ReSharper disable once CheckNamespace

namespace Rocket.Surgery.Blazor.FontAwesome6;

public interface IAnimationComponent
{
    bool? Beat { get; }
    bool? BeatFade { get; }
    bool? Bounce { get; }
    bool? Spin { get; }
    bool? Flip { get; }
    bool? Shake { get; }
    bool? SpinPulse { get; }
    bool? Fade { get; }
    bool? Reverse { get; }
}