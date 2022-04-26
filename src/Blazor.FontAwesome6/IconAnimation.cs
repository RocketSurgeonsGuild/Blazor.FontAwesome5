namespace Rocket.Surgery.Blazor.FontAwesome6;

/*
 
    bool Spin { get; }
    bool SpinPulse { get; }
    bool Beat { get; }
    bool BeatFade { get; }
    bool Fade { get; }
    bool SpinReverse { get; }
 */

[Flags]
public enum IconAnimation
{
    None = 0,
    Beat = 1 << 1,
    Fade = 1 <<2,
    BeatFade = 1 <<3,
    Bounce = 1 <<4,
    Flip = 1 <<5,
    Shake = 1 <<6,
    Spin = 1 <<7,
    SpinPulse = 1 <<8,
    Reverse = 1 <<9
}
