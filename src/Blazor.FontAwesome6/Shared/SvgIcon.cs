using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public sealed record SvgIcon : Icon, ISvgIcon
{
    private int _width;
    private int _height;
    private string _symbol;
    private SvgIcon? _mask;
    private ImmutableArray<string> _vectorData;

    public SvgIcon(IconFamily family, IconStyle style, string name, int width, int height, string symbol, ImmutableArray<string> vectorData) : base(
        family,
        style,
        name
    )
    {
        _width = width;
        _height = height;
        _symbol = symbol;
        _vectorData = vectorData;
    }

    public SvgIcon Width(int width)
    {
        return this with { _width = width };
    }

    public SvgIcon Height(int width)
    {
        return this with { _height = width };
    }

    public SvgIcon Symbol(string symbol)
    {
        return this with { _symbol = symbol };
    }

    public SvgIcon Mask(SvgIcon mask)
    {
        return this with { _mask = mask };
    }

    public SvgIcon VectorData(ImmutableArray<string> vectorData)
    {
        return this with { _vectorData = vectorData };
    }

    int ISvgIcon.Width => _width;
    int ISvgIcon.Height => _height;
    string ISvgIcon.Symbol => _symbol;
    SvgIcon? ISvgMaskIcon.Mask => _mask;
    ImmutableArray<string> ISvgIcon.VectorData => _vectorData;
}