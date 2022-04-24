using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace Rocket.Surgery.Blazor.FontAwesome5;

[DebuggerDisplay("{Style} {Name}")]
public sealed class Icon : IIcon
{
    public static implicit operator Icon(Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var member = enumType.GetMember(Enum.GetName(enumType, enumValue)!)[0];
        var faa = member.GetCustomAttribute<FontAwesomeAttribute>(true);
        return new Icon(faa?.IconStyle ?? IconStyle.Unknown, faa?.Name ?? string.Empty);
    }

    public Icon(IconStyle style, string name)
    {
        Style = style;
        Name = name;
        _size = IconSize.Normal;
        _fixedWidth = false;
        _spin = false;
        _pulse = false;
        _pull = IconPull.None;
        _border = false;
        _inverse = false;
        _grow = 0;
        _shrink = 0;
        _up = 0;
        _down = 0;
        _left = 0;
        _right = 0;
        _rotate = 0;
        _flip = IconFlip.None;
        _mask = default;
    }

    private Icon(
        IconStyle style,
        string name,
        IconSize iconSize,
        bool fixedWidth,
        bool spin,
        bool pulse,
        IconPull pull,
        bool border,
        bool inverse,
        double grow,
        double shrink,
        double up,
        double down,
        double left,
        double right,
        double rotate,
        IconFlip flip,
        Icon? mask,
        string? cssClass,
        string? cssStyle
    )
    {
        Style = style;
        Name = name;
        _size = iconSize;
        _fixedWidth = fixedWidth;
        _spin = spin;
        _pulse = pulse;
        _pull = pull;
        _border = border;
        _inverse = inverse;
        _grow = grow;
        _shrink = shrink;
        _up = up;
        _down = down;
        _left = left;
        _right = right;
        _rotate = rotate;
        _flip = flip;
        _mask = mask;
        _cssClass = cssClass;
        _cssStyle = cssStyle;
    }

    public IconStyle Style { get; }
    public string Name { get; }

    internal readonly IconSize _size;
    internal readonly string? _cssStyle;
    internal readonly string? _cssClass;
    internal readonly bool _fixedWidth;
    internal readonly bool _spin;
    internal readonly bool _pulse;
    internal readonly IconPull _pull;
    internal readonly bool _border;

    internal readonly bool _inverse;
    internal readonly Icon? _mask;

    internal readonly double _shrink;
    internal readonly double _grow;
    internal readonly double _right;
    internal readonly double _left;
    internal readonly double _up;
    internal readonly double _down;
    internal readonly double _rotate;
    internal readonly IconFlip _flip;

    public Icon Size(IconSize size)
    {
        return new Icon(
            Style,
            Name,
            size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon FixedWidth(bool fixedWith = true)
    {
        return new Icon(
            Style,
            Name,
            _size,
            fixedWith,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Spin(bool spin = true)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Pulse(bool pulse = true)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Pull(IconPull pull = IconPull.Left)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Border(bool border = true)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Inverse(bool inverse = true)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Scale(double scale = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            scale > 0 ? scale : 0,
            scale < 0 ? scale : 0,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Grow(double scale = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            scale,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Shrink(double scale = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            scale,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Horizontal(double horizontal = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            horizontal < 0 ? horizontal : 0,
            horizontal > 0 ? horizontal : 0,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Left(double left = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Right(double right = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Vertical(double vertical = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            vertical > 0 ? vertical : 0,
            vertical < 0 ? vertical : 0,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Up(double up = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Down(double down = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Rotate(IconRotate rotate)
    {
        return rotate switch
        {
            IconRotate._0Deg   => Rotate(),
            IconRotate._90Deg  => Rotate(90),
            IconRotate._180Deg => Rotate(180),
            IconRotate._270Deg => Rotate(270),
            _                  => throw new NotSupportedException(),
        };
    }

    public Icon Rotate(double rotate = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon RotateRight(double rotate = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate + rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon RotateLeft(double rotate = 0)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate - rotate,
            _flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Flip(IconFlip flip = IconFlip.None)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            flip,
            _mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon Mask(Icon? mask)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            mask,
            _cssClass,
            _cssStyle
        );
    }

    public Icon RemoveMask()
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            null,
            _cssClass,
            _cssStyle
        );
    }

    public Icon CssClass(string? cssClass)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            cssClass,
            _cssStyle
        );
    }

    public Icon CssStyle(string? cssStyle)
    {
        return new Icon(
            Style,
            Name,
            _size,
            _fixedWidth,
            _spin,
            _pulse,
            _pull,
            _border,
            _inverse,
            _grow,
            _shrink,
            _up,
            _down,
            _left,
            _right,
            _rotate,
            _flip,
            _mask,
            _cssClass,
            cssStyle
        );
    }

    public static string ToString(IconSize size, bool stack)
    {
        return ( size, stack ) switch
        {
            (IconSize.ExtraSmall, true)  => " fa-stack-xs",
            (IconSize.ExtraSmall, false) => " fa-xs",
            (IconSize.Small, true)       => " fa-stack-sm",
            (IconSize.Small, false)      => " fa-sm",
            (IconSize.Large, true)       => " fa-stack-lg",
            (IconSize.Large, false)      => " fa-lg",
            (IconSize._2X, true)         => " fa-stack-2x",
            (IconSize._2X, false)        => " fa-2x",
            (IconSize._3X, true)         => " fa-stack-3x",
            (IconSize._3X, false)        => " fa-3x",
            (IconSize._4X, true)         => " fa-stack-4x",
            (IconSize._4X, false)        => " fa-4x",
            (IconSize._5X, true)         => " fa-stack-5x",
            (IconSize._5X, false)        => " fa-5x",
            (IconSize._6X, true)         => " fa-stack-6x",
            (IconSize._6X, false)        => " fa-6x",
            (IconSize._7X, true)         => " fa-stack-7x",
            (IconSize._7X, false)        => " fa-7x",
            (IconSize._8X, true)         => " fa-stack-8x",
            (IconSize._8X, false)        => " fa-8x",
            (IconSize._9X, true)         => " fa-stack-9x",
            (IconSize._9X, false)        => " fa-9x",
            (IconSize._10X, true)        => " fa-stack-10x",
            (IconSize._10X, false)       => " fa-10x",
            (_, true)                    => " fa-stack-1x",
            (_, false)                   => "",
        };
    }

    public static string ToString(IconPull pull)
    {
        return pull switch
        {
            IconPull.Left  => "fa-pull-left",
            IconPull.Right => "fa-pull-right",
            _              => throw new NotImplementedException()
        };
    }

    public static string ToString(IconFlip flip)
    {
        if (flip == IconFlip.Both)
        {
            return "flip-h flip-v";
        }

        if (( flip & IconFlip.Horizontal ) == IconFlip.Horizontal)
        {
            return "flip-h";
        }

        if (( flip & IconFlip.Vertical ) == IconFlip.Vertical)
        {
            return "flip-v";
        }

        return "";
    }

    public static string ToPrefix(IconStyle style)
    {
        return style switch
        {
            IconStyle.Solid   => "fas",
            IconStyle.Regular => "far",
            IconStyle.Light   => "fal",
            IconStyle.Duotone => "fad",
            IconStyle.Brands  => "fab",
            _                 => "fas" // Default in the case no icon was provided
        };
    }

    public static string ToPrefix(Icon icon)
    {
        return ToPrefix(icon.Style);
    }

    public static string ToName(Icon icon)
    {
        var sb = new StringBuilder();
        IconExtensions.ApplyName(sb, icon.Name);
        return sb.ToString();
    }

    public MarkupString ToMarkup()
    {
        return (MarkupString)( ToString() ?? "" );
    }

    public string ToIcon()
    {
        var sb = new StringBuilder();
        sb.Append("<i class=\"");
        this.ApplyClass(sb);
        sb.Append('"');
        ApplyAttributes(sb);
        sb.Append("></i>");
        return sb.ToString();
    }

    private void ApplyAttributes(StringBuilder sb)
    {
        if (!string.IsNullOrWhiteSpace(_cssStyle))
        {
            sb.Append(" style=\"");
            sb.Append(_cssStyle);
            sb.Append('"');
        }

        if (_mask != null)
        {
            sb.Append(" data-fa-mask=\"");
            this.ApplyMask(sb);
            sb.Append('"');
        }

        if (this.ApplyTransform(sb, () => sb.Append(" data-fa-transform=\"")))
        {
            sb.Append('"');
        }
    }

    double ITransformIcon.Grow => _grow;
    double ITransformIcon.Shrink => _shrink;
    double ITransformIcon.Rotate => _rotate;
    double ITransformIcon.Up => _up;
    double ITransformIcon.Down => _down;
    double ITransformIcon.Left => _left;
    double ITransformIcon.Right => _right;
    IconFlip? ITransformIcon.Flip => _flip;

    IconSize IIcon.Size => _size;
    string? IIcon.CssStyle => _cssStyle;
    string? IIcon.CssClass => _cssClass;
    bool IIcon.FixedWidth => _fixedWidth;
    bool IIcon.Spin => _spin;
    bool IIcon.Pulse => _pulse;
    IconPull IIcon.Pull => _pull;
    bool IIcon.Border => _border;
    bool IIcon.Inverse => _inverse;
    Icon? IIcon.Mask => _mask;
}
