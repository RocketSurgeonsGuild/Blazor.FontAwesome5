using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6.Vector;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome6;

public sealed record SvgIcon : Icon, ISvgIcon
{
    private readonly int _width;
    private readonly int _height;
    private SvgIcon? _mask;
    private readonly ImmutableArray<ImmutableArray<byte>> _vectorData;

    public SvgIcon(IconFamily family, IconStyle style, string name, string unicode, int width, int height, ImmutableArray<ImmutableArray<byte>> vectorData) : base(
        family,
        style,
        name,
        unicode
    )
    {
        _width = width;
        _height = height;
        _vectorData = vectorData;
    }

    public SvgIcon Mask(SvgIcon mask)
    {
        return this with { _mask = mask };
    }

    public override string ToIcon()
    {
        var icon = (ISvgIcon)this;
        return Renderer.Instance.RenderToHtml(
            icon,
            new SvgParameters()
            {
                Styles = icon.ApplyStyle(null),
                Classes = icon.ApplyClass(null),
                Transform = new SvgTransform()
                {
                    Rotate = icon.Rotate,
                    Size = 16 + icon.Scale,
                    X = icon.X,
                    Y = icon.Y,
                    FlipX = icon.FlipTransform is IconFlip.Horizontal or IconFlip.Both,
                    FlipY = icon.FlipTransform is IconFlip.Vertical or IconFlip.Both,
                },
//                Symbol = icon.Symbol,
                Title = icon.Title,
            }
        );
    }

    int ISvgIcon.Width => _width;
    int ISvgIcon.Height => _height;
    SvgIcon? ISvgMaskIcon.Mask => _mask;
    ImmutableArray<ImmutableArray<byte>> ISvgIcon.VectorData => _vectorData;
}
