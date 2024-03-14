using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6.Vector;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public sealed record SvgIcon : Icon, ISvgIcon
{
    private int _width;
    private int _height;
    private SvgIcon? _mask;
    private ImmutableArray<string> _vectorData;

    public SvgIcon(IconFamily family, IconStyle style, string name, int width, int height, string[] vectorData) : base(
        family,
        style,
        name
    )
    {
        _width = width;
        _height = height;
        _vectorData = vectorData.ToImmutableArray();
    }

    public SvgIcon Width(int width)
    {
        return this with { _width = width };
    }

    public SvgIcon Height(int width)
    {
        return this with { _height = width };
    }

    public SvgIcon Mask(SvgIcon mask)
    {
        return this with { _mask = mask };
    }

    public SvgIcon VectorData(ImmutableArray<string> vectorData)
    {
        return this with { _vectorData = vectorData };
    }

    public override string ToIcon()
    {
        var icon = (ISvgIcon)this;
        return Renderer.Instance.RenderToHtml(
            icon,
            new SvgParameters()
            {
                Styles = icon
                        .ToStyle(null)
                        .Split(';', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Split(':'))
                        .ToImmutableDictionary(x => x[0], x => x[1]),
                Classes = icon.ToClass(null)?.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToImmutableArray() ?? ImmutableArray<string>.Empty,
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
    ImmutableArray<string> ISvgIcon.VectorData => _vectorData;
}
