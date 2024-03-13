namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public record SvgTransform
{
    public static SvgTransform None { get; } = new SvgTransform();
    public int Size { get; init; } = 16;
    public int X { get; init; } = 0;
    public int Y { get; set; } = 0;
    public int Rotate { get; init; } = 0;
    public bool FlipX { get; init; } = false;
    public bool FlipY { get; init; } = false;
}