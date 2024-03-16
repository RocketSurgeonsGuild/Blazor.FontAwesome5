namespace Rocket.Surgery.Blazor.FontAwesome6.Vector;

public record SvgTransform
{
    public static SvgTransform None { get; } = new SvgTransform();
    public double Size { get; init; } = 16;
    public double X { get; init; } = 0;
    public double Y { get; set; } = 0;
    public double Rotate { get; init; } = 0;
    public bool FlipX { get; init; } = false;
    public bool FlipY { get; init; } = false;
}
