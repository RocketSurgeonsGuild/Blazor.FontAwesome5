using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components;
using Rocket.Surgery.Blazor.FontAwesome6;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace

namespace Rocket.Surgery.Blazor.FontAwesome5;

[DebuggerDisplay("{Style} {Name}")]
public sealed record Icon(IconStyle Style, string Name) : IIcon
{
    public static implicit operator Icon(Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var member = enumType.GetMember(Enum.GetName(enumType, enumValue)!)[0];
        var faa = member.GetCustomAttribute<FontAwesomeAttribute>(true);
        return new Icon(faa?.IconStyle ?? IconStyle.Unknown, faa?.Name ?? string.Empty);
    }

    internal IconSize _size { get; private init; }
    internal IconAnimation _animation { get; private init; }
    internal string? _cssStyle { get; private init; }
    internal string? _cssClass { get; private init; }
    internal bool _fixedWidth { get; private init; }
    internal IconPull _pull { get; private init; }
    internal bool _border { get; private init; }

    internal bool _inverse { get; private init; }
    internal string? _inverseColor { get; private init; }
    internal Icon? _mask { get; private init; }

    internal double _shrink { get; private init; }
    internal double _grow { get; private init; }
    internal double _right { get; private init; }
    internal double _left { get; private init; }
    internal double _up { get; private init; }
    internal double _down { get; private init; }
    internal double _rotate { get; private init; }
    internal IconFlip _flipIcon { get; private init; }
    internal bool _swapOpacity { get; private init; }
    internal double? _primaryOpacity { get; private init; }
    internal double? _secondaryOpacity { get; private init; }
    internal string? _primaryColor { get; private init; }
    internal string? _secondaryColor { get; private init; }
    internal string? _animationDelay { get; private init; }
    internal string? _animationDirection { get; private init; }
    internal string? _animationDuration { get; private init; }
    internal string? _animationIterationCount { get; private init; }
    internal string? _animationTiming { get; private init; }
    internal double? _beatScale { get; private init; }
    internal double? _fadeOpacity { get; private init; }
    internal double? _beatFadeOpacity { get; private init; }
    internal double? _beatFadeScale { get; private init; }
    internal double? _flipX { get; private init; }
    internal double? _flipY { get; private init; }
    internal double? _flipZ { get; private init; }
    internal string? _flipAngle { get; private init; }
    internal string? _borderColor { get; private init; }
    internal string? _borderPadding { get; private init; }
    internal string? _borderRadius { get; private init; }
    internal string? _borderStyle { get; private init; }
    internal string? _borderWidth { get; private init; }
    internal string? _pullMargin { get; private init; }
    internal string? _stackZIndex { get; private init; }
    internal string? _rotateBy { get; private init; }
    internal double? _bounceRebound { get; private init; }
    internal double? _bounceHeight { get; private init; }
    internal double? _bounceStartScaleX { get; private init; }
    internal double? _bounceStartScaleY { get; private init; }
    internal double? _bounceJumpScaleX { get; private init; }
    internal double? _bounceJumpScaleY { get; private init; }
    internal double? _bounceLandScaleX { get; private init; }
    internal double? _bounceLandScaleY { get; private init; }

    public Icon Size(IconSize size)
    {
        return this with
        {
            _size = size
        };
    }

    public Icon FixedWidth(bool fixedWith = true)
    {
        return this with { _fixedWidth = fixedWith };
    }

    public Icon Animate(
        IconAnimation animation, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    )
    {
        return AnimationSettings(animation, delay, direction, duration, iterationCount, timing);
    }

    public Icon AnimationSettings(
        IconAnimation? animation = null, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null,
        string? timing = null
    )
    {
        return this with
        {
            _animation = animation ?? _animation,
            _animationDelay = delay ?? _animationDelay,
            _animationDirection = direction ?? _animationDirection,
            _animationDuration = duration ?? _animationDuration,
            _animationIterationCount = iterationCount ?? _animationIterationCount,
            _animationTiming = timing ?? _animationTiming,
        };
    }

    public Icon Beat(
        double? scale = null, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
            IconAnimation.Beat,
            delay, direction, duration, iterationCount, timing
        ).BeatScale(scale);


    public Icon Fade(
        double? opacity = null, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
            IconAnimation.Fade,
            delay, direction, duration, iterationCount, timing
        ).FadeOpacity(opacity);


    public Icon BeatFade(
        double? opacity = null, double? scale = null, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null,
        string? timing = null
    ) =>
        AnimationSettings(
            IconAnimation.BeatFade,
            delay, direction, duration, iterationCount, timing
        ).BeatFadeOpacity(opacity).BeatFadeScale(scale);


    public Icon Bounce(
        double? rebound = null,
        double? height = null,
        double? startScaleX = null,
        double? startScaleY = null,
        double? jumpScaleX = null,
        double? jumpScaleY = null,
        double? landScaleX = null,
        double? landScaleY = null,
        string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
                IconAnimation.Bounce,
                delay, direction, duration, iterationCount, timing
            ) with
            {
                _bounceRebound = rebound ?? _bounceRebound,
                _bounceHeight = height ?? _bounceHeight,
                _bounceStartScaleX = startScaleX ?? _bounceStartScaleX,
                _bounceStartScaleY = startScaleY ?? _bounceStartScaleY,
                _bounceJumpScaleX = jumpScaleX ?? _bounceJumpScaleX,
                _bounceJumpScaleY = jumpScaleY ?? _bounceJumpScaleY,
                _bounceLandScaleX = landScaleX ?? _bounceLandScaleX,
                _bounceLandScaleY = landScaleY ?? _bounceLandScaleY
            };


    public Icon Flip(
        double? flipX = null,
        double? flipY = null,
        double? flipZ = null,
        string? flipAngle = null,
        string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
                IconAnimation.Flip,
                delay, direction, duration, iterationCount, timing
            ) with
            {
                _flipX = flipX,
                _flipY = flipY,
                _flipZ = flipZ,
                _flipAngle = flipAngle
            };


    public Icon Shake(
        string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
            IconAnimation.Shake,
            delay, direction, duration, iterationCount, timing
        );

    public Icon Spin(
        bool reverse = false, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
            reverse ? IconAnimation.Spin & IconAnimation.Reverse : IconAnimation.Spin,
            delay, direction, duration, iterationCount, timing
        );

    public Icon SpinPulse(
        bool reverse = false, string? delay = null, string? direction = null, string? duration = null, string? iterationCount = null, string? timing = null
    ) =>
        AnimationSettings(
            reverse ? IconAnimation.SpinPulse & IconAnimation.Reverse : IconAnimation.SpinPulse,
            delay, direction, duration, iterationCount, timing
        );

    public Icon Pull(IconPull pull = IconPull.Left, string? margin = null)
    {
        return this with
        {
            _pull = pull,
            _pullMargin = margin ?? _pullMargin
        };
    }

    public Icon PullLeft(string? margin = null) => Pull(IconPull.Left, margin);
    public Icon PullRight(string? margin = null) => Pull(IconPull.Right, margin);
    public Icon PullNone() => Pull(IconPull.None, "");

    public Icon Border(bool border = true, string? color = null, string? padding = null, string? radius = null, string? style = null, string? width = null)
    {
        return this with
        {
            _border = border,
            _borderColor = color ?? _borderColor,
            _borderPadding = padding ?? _borderPadding,
            _borderRadius = radius ?? _borderRadius,
            _borderStyle = style ?? _borderStyle,
            _borderWidth = width ?? _borderWidth,
        };
    }

    public Icon Inverse(bool inverse = true)
    {
        return this with
        {
            _inverse = inverse
        };
    }

    public Icon Scale(double scale = 0)
    {
        return this with
        {
            _grow =
            scale > 0 ? scale : 0,
            _shrink =
            scale < 0 ? scale : 0,
        };
    }

    public Icon Grow(double scale = 0)
    {
        return this with { _grow = scale };
    }

    public Icon Shrink(double scale = 0)
    {
        return this with { _shrink = scale };
    }

    public Icon Horizontal(double horizontal = 0)
    {
        return this with
        {
            _left = horizontal < 0 ? horizontal : 0,
            _right = horizontal > 0 ? horizontal : 0
        };
    }

    public Icon Left(double left = 0)
    {
        return this with { _left = left };
    }

    public Icon Right(double right = 0)
    {
        return this with { _right = right };
    }

    public Icon Vertical(double vertical = 0)
    {
        return this with
        {
            _up =
            vertical > 0 ? vertical : 0,
            _down =
            vertical < 0 ? vertical : 0,
        };
    }

    public Icon Up(double up = 0)
    {
        return this with { _up = up };
    }

    public Icon Down(double down = 0)
    {
        return this with { _down = down };
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
        return this with
        {
            _rotate = rotate
        };
    }

    public Icon RotateRight(double rotate = 0)
    {
        return this with
        {
            _rotate = _rotate + rotate
        };
    }

    public Icon RotateLeft(double rotate = 0)
    {
        return this with
        {
            _rotate = _rotate + rotate
        };
    }

    public Icon FlipIcon(IconFlip flip = IconFlip.None)
    {
        return this with
        {
            _flipIcon = flip
        };
    }

    public Icon Mask(Icon? mask)
    {
        return this with
        {
            _mask = mask
        };
    }

    public Icon RemoveMask()
    {
        return this with
        {
            _mask = null
        };
    }

    public Icon CssClass(string? cssClass)
    {
        return this with
        {
            _cssClass = cssClass
        };
    }

    public Icon CssStyle(string? cssStyle)
    {
        return this with
        {
            _cssStyle = cssStyle
        };
    }

    public Icon SwapOpacity(bool swapOpacity)
    {
        return this with
        {
            _swapOpacity = swapOpacity
        };
    }

    public Icon PrimaryOpacity(double? primaryOpacity)
    {
        return this with
        {
            _primaryOpacity = primaryOpacity
        };
    }

    public Icon SecondaryOpacity(double? secondaryOpacity)
    {
        return this with
        {
            _secondaryOpacity = secondaryOpacity
        };
    }

    public Icon PrimaryColor(string? primaryColor)
    {
        return this with
        {
            _primaryColor = primaryColor
        };
    }

    public Icon SecondaryColor(string? secondaryColor)
    {
        return this with
        {
            _secondaryColor = secondaryColor
        };
    }

    public Icon AnimationDelay(string? animationDelay)
    {
        return this with
        {
            _animationDelay = animationDelay
        };
    }

    public Icon AnimationDirection(string? animationDirection)
    {
        return this with
        {
            _animationDirection = animationDirection
        };
    }

    public Icon AnimationDuration(string? animationDuration)
    {
        return this with
        {
            _animationDuration = animationDuration
        };
    }

    public Icon AnimationIterationCount(string? animationIterationCount)
    {
        return this with
        {
            _animationIterationCount = animationIterationCount
        };
    }

    public Icon AnimationTiming(string? animationTiming)
    {
        return this with
        {
            _animationTiming = animationTiming
        };
    }

    public Icon BeatScale(double? beatScale)
    {
        return this with
        {
            _beatScale = beatScale
        };
    }

    public Icon FadeOpacity(double? fadeOpacity)
    {
        return this with
        {
            _fadeOpacity = fadeOpacity
        };
    }

    public Icon BeatFadeOpacity(double? beatFadeOpacity)
    {
        return this with
        {
            _beatFadeOpacity = beatFadeOpacity
        };
    }

    public Icon BeatFadeScale(double? beatFadeScale)
    {
        return this with
        {
            _beatFadeScale = beatFadeScale
        };
    }

    public Icon FlipX(double? flipX)
    {
        return this with
        {
            _flipX = flipX
        };
    }

    public Icon FlipY(double? flipY)
    {
        return this with
        {
            _flipY = flipY
        };
    }

    public Icon FlipZ(double? flipZ)
    {
        return this with
        {
            _flipZ = flipZ
        };
    }

    public Icon FlipAngle(string? flipAngle)
    {
        return this with
        {
            _flipAngle = flipAngle
        };
    }

    public Icon BorderColor(string? borderColor)
    {
        return this with
        {
            _borderColor = borderColor
        };
    }

    public Icon BorderPadding(string? borderPadding)
    {
        return this with
        {
            _borderPadding = borderPadding
        };
    }

    public Icon BorderRadius(string? borderRadius)
    {
        return this with
        {
            _borderRadius = borderRadius
        };
    }

    public Icon BorderStyle(string? borderStyle)
    {
        return this with
        {
            _borderStyle = borderStyle
        };
    }

    public Icon BorderWidth(string? borderWidth)
    {
        return this with
        {
            _borderWidth = borderWidth
        };
    }

    public Icon PullMargin(string? pullMargin)
    {
        return this with
        {
            _pullMargin = pullMargin
        };
    }

    public Icon StackZIndex(string? stackZIndex)
    {
        return this with
        {
            _stackZIndex = stackZIndex
        };
    }

    public Icon RotateBy(string? rotateBy)
    {
        return this with
        {
            _rotateBy = rotateBy
        };
    }

    public Icon InverseColor(string? color)
    {
        return this with { _inverseColor = color };
    }

    public static string ToString(IconSize size, bool stack)
    {
        return ( size, stack ) switch
        {
            (IconSize.ExtraExtraSmall, false) => " fa-2xs",
            (IconSize.ExtraSmall, false)      => " fa-xs",
            (IconSize.Small, false)           => " fa-sm",
            (IconSize.Large, false)           => " fa-lg",
            (IconSize.ExtraLarge, false)      => " fa-xl",
            (IconSize.ExtraExtraLarge, false) => " fa-2xl",
            (IconSize._2X, true)              => " fa-stack-2x",
            (IconSize._2X, false)             => " fa-2x",
            (IconSize._3X, false)             => " fa-3x",
            (IconSize._4X, false)             => " fa-4x",
            (IconSize._5X, false)             => " fa-5x",
            (IconSize._6X, false)             => " fa-6x",
            (IconSize._7X, false)             => " fa-7x",
            (IconSize._8X, false)             => " fa-8x",
            (IconSize._9X, false)             => " fa-9x",
            (IconSize._10X, false)            => " fa-10x",
            (_, true)                         => " fa-stack-1x",
            (_, _)                            => "",
        };
    }


    public static string ToString(IconAnimation animation)
    {
        var sb = new StringBuilder();
        sb.Append(
            ( animation & ~IconAnimation.Reverse ) switch
            {
                IconAnimation.Beat      => " fa-beat",
                IconAnimation.BeatFade  => " fa-beat-fade",
                IconAnimation.Bounce    => " fa-bounce",
                IconAnimation.Fade      => " fa-fade",
                IconAnimation.Flip      => " fa-flip",
                IconAnimation.Shake     => " fa-shake",
                IconAnimation.Spin      => " fa-spin",
                IconAnimation.SpinPulse => " fa-spin-pulse",
                _                       => ""
            }
        );

        if (( animation & IconAnimation.Reverse ) == IconAnimation.Reverse)
        {
            sb.Append(
                ( animation ^ IconAnimation.Reverse ) switch
                {
                    IconAnimation.Spin or IconAnimation.SpinPulse => " fa-spin-reverse",
                    _                                             => ""
                }
            );
        }

        return sb.ToString();
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
            IconStyle.Solid   => "fa-solid",
            IconStyle.Regular => "fa-regular",
            IconStyle.Light   => "fa-light",
            IconStyle.Duotone => "fa-duotone",
            IconStyle.Brands  => "fa-brands",
            _                 => "fa-solid" // Default in the case no icon was provided
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
    IconFlip? ITransformIcon.FlipTransform => _flipIcon;

    IconSize IIcon.Size => _size;
    string? IIcon.CssStyle => _cssStyle;
    string? IIcon.CssClass => _cssClass;
    bool IIcon.FixedWidth => _fixedWidth;

    IconPull IIcon.Pull => _pull;
    IconAnimation IIcon.Animation => _animation;
    bool IIcon.Border => _border;
    bool IIcon.Inverse => _inverse;
    Icon? IIcon.Mask => _mask;

    bool IIcon.SwapOpacity => _swapOpacity;
    double? IIcon.PrimaryOpacity => _primaryOpacity;
    double? IIcon.SecondaryOpacity => _secondaryOpacity;
    string? IIcon.PrimaryColor => _primaryColor;
    string? IIcon.SecondaryColor => _secondaryColor;
    string? IIcon.AnimationDelay => _animationDelay;
    string? IIcon.AnimationDirection => _animationDirection;
    string? IIcon.AnimationDuration => _animationDuration;
    string? IIcon.AnimationIterationCount => _animationIterationCount;
    string? IIcon.AnimationTiming => _animationTiming;
    double? IIcon.BeatScale => _beatScale;
    double? IIcon.FadeOpacity => _fadeOpacity;
    double? IIcon.BeatFadeOpacity => _beatFadeOpacity;
    double? IIcon.BeatFadeScale => _beatFadeScale;
    double? IIcon.BounceRebound => _bounceRebound;
    double? IIcon.BounceHeight => _bounceHeight;
    double? IIcon.BounceStartScaleX => _bounceStartScaleX;
    double? IIcon.BounceStartScaleY => _bounceStartScaleY;
    double? IIcon.BounceJumpScaleX => _bounceJumpScaleX;
    double? IIcon.BounceJumpScaleY => _bounceJumpScaleY;
    double? IIcon.BounceLandScaleX => _bounceLandScaleX;
    double? IIcon.BounceLandScaleY => _bounceLandScaleY;
    double? IIcon.FlipX => _flipX;
    double? IIcon.FlipY => _flipY;
    double? IIcon.FlipZ => _flipZ;
    string? IIcon.FlipAngle => _flipAngle;
    string? IIcon.BorderColor => _borderColor;
    string? IIcon.BorderPadding => _borderPadding;
    string? IIcon.BorderRadius => _borderRadius;
    string? IIcon.BorderStyle => _borderStyle;
    string? IIcon.BorderWidth => _borderWidth;
    string? IIcon.PullMargin => _pullMargin;
    string? IIcon.StackZIndex => _stackZIndex;
    string? IIcon.InverseColor => _inverseColor;
    string? IIcon.RotateBy => _rotateBy;
}
