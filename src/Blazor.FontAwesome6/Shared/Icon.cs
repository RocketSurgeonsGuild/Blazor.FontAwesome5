using System.Diagnostics;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components;
using Rocket.Surgery.Blazor.FontAwesome6;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace

namespace Rocket.Surgery.Blazor.FontAwesome6;

[DebuggerDisplay("{Style} {Name}")]
public sealed record Icon(IconFamily Family, IconStyle Style, string Name) : IIcon
{
    private IconSize _size { get; init; }
    private IconAnimation _animation { get; init; }
    private string? _cssStyle { get; init; }
    private string? _cssClass { get; init; }
    private bool _fixedWidth { get; init; }
    private IconPull _pull { get; init; }
    private bool _border { get; init; }

    private bool _inverse { get; init; }
    private string? _inverseColor { get; init; }
    private Icon? _mask { get; init; }

    private double _shrink { get; init; }
    private double _grow { get; init; }
    private double _right { get; init; }
    private double _left { get; init; }
    private double _up { get; init; }
    private double _down { get; init; }
    private double _rotate { get; init; }
    private IconFlip _flipIcon { get; init; }
    private bool _swapOpacity { get; init; }
    private double? _primaryOpacity { get; init; }
    private double? _secondaryOpacity { get; init; }
    private string? _primaryColor { get; init; }
    private string? _secondaryColor { get; init; }
    private string? _animationDelay { get; init; }
    private string? _animationDirection { get; init; }
    private string? _animationDuration { get; init; }
    private string? _animationIterationCount { get; init; }
    private string? _animationTiming { get; init; }
    private double? _beatScale { get; init; }
    private double? _fadeOpacity { get; init; }
    private double? _beatFadeOpacity { get; init; }
    private double? _beatFadeScale { get; init; }
    private double? _flipX { get; init; }
    private double? _flipY { get; init; }
    private double? _flipZ { get; init; }
    private string? _flipAngle { get; init; }
    private string? _borderColor { get; init; }
    private string? _borderPadding { get; init; }
    private string? _borderRadius { get; init; }
    private string? _borderStyle { get; init; }
    private string? _borderWidth { get; init; }
    private string? _pullMargin { get; init; }
    private string? _stackZIndex { get; init; }
    private string? _rotateBy { get; init; }
    private double? _bounceRebound { get; init; }
    private double? _bounceHeight { get; init; }
    private double? _bounceStartScaleX { get; init; }
    private double? _bounceStartScaleY { get; init; }
    private double? _bounceJumpScaleX { get; init; }
    private double? _bounceJumpScaleY { get; init; }
    private double? _bounceLandScaleX { get; init; }
    private double? _bounceLandScaleY { get; init; }

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
        IconAnimation animation,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    )
    {
        return this with
        {
            _animation = animation,
            _animationDelay = delay,
            _animationDirection = direction,
            _animationDuration = duration,
            _animationIterationCount = iterationCount,
            _animationTiming = timing,
        };
    }

    public Icon AnimationSettings(
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    )
    {
        return this with
        {
            _animationDelay = delay ?? _animationDelay,
            _animationDirection = direction ?? _animationDirection,
            _animationDuration = duration ?? _animationDuration,
            _animationIterationCount = iterationCount ?? _animationIterationCount,
            _animationTiming = timing ?? _animationTiming,
        };
    }

    private Icon InternalAnimationSettings(
        IconAnimation? animation = null,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
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
        double? scale = null,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
                IconAnimation.Beat,
                delay,
                direction,
                duration,
                iterationCount,
                timing
            )
           .BeatScale(scale);


    public Icon Fade(
        double? opacity = null,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
                IconAnimation.Fade,
                delay,
                direction,
                duration,
                iterationCount,
                timing
            )
           .FadeOpacity(opacity);


    public Icon BeatFade(
        double? opacity = null,
        double? scale = null,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
                IconAnimation.BeatFade,
                delay,
                direction,
                duration,
                iterationCount,
                timing
            )
           .BeatFadeOpacity(opacity)
           .BeatFadeScale(scale);


    public Icon Bounce(
        double? rebound = null,
        double? height = null,
        double? startScaleX = null,
        double? startScaleY = null,
        double? jumpScaleX = null,
        double? jumpScaleY = null,
        double? landScaleX = null,
        double? landScaleY = null,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
                IconAnimation.Bounce,
                delay,
                direction,
                duration,
                iterationCount,
                timing
            ) with
            {
                _bounceRebound = rebound,
                _bounceHeight = height,
                _bounceStartScaleX = startScaleX,
                _bounceStartScaleY = startScaleY,
                _bounceJumpScaleX = jumpScaleX,
                _bounceJumpScaleY = jumpScaleY,
                _bounceLandScaleX = landScaleX,
                _bounceLandScaleY = landScaleY
            };


    public Icon Flip(
        double? flipX = null,
        double? flipY = null,
        double? flipZ = null,
        string? flipAngle = null,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
                IconAnimation.Flip,
                delay,
                direction,
                duration,
                iterationCount,
                timing
            ) with
            {
                _flipX = flipX,
                _flipY = flipY,
                _flipZ = flipZ,
                _flipAngle = flipAngle
            };


    public Icon Shake(
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
            IconAnimation.Shake,
            delay,
            direction,
            duration,
            iterationCount,
            timing
        );

    public Icon Spin(
        bool reverse = false,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
            reverse ? IconAnimation.Spin | IconAnimation.Reverse : IconAnimation.Spin,
            delay,
            direction,
            duration,
            iterationCount,
            timing
        );

    public Icon SpinPulse(
        bool reverse = false,
        string? delay = null,
        string? direction = null,
        string? duration = null,
        string? iterationCount = null,
        string? timing = null
    ) =>
        InternalAnimationSettings(
            reverse ? IconAnimation.SpinPulse | IconAnimation.Reverse : IconAnimation.SpinPulse,
            delay,
            direction,
            duration,
            iterationCount,
            timing
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
            _rotate = _rotate - rotate
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
                ( animation ^ IconAnimation.Reverse ) switch { IconAnimation.Spin or IconAnimation.SpinPulse => " fa-spin-reverse", _ => "" }
            );
        }

        return sb.ToString();
    }

    public static string ToString(IconPull pull)
    {
        return pull switch { IconPull.Left => "fa-pull-left", IconPull.Right => "fa-pull-right", _ => throw new NotImplementedException() };
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

    public static string ToPrefix(IconFamily family, IconStyle style)
    {
        return ( family, style ) switch
               {
                   (_, IconStyle.Brands)                   => "fa-brands",
                   (IconFamily.Duotone, _)                 => "fa-duotone",
                   (IconFamily.Classic, IconStyle.Thin)    => "fa-thin",
                   (IconFamily.Classic, IconStyle.Light)   => "fa-light",
                   (IconFamily.Classic, IconStyle.Regular) => "fa-regular",
                   (IconFamily.Classic, IconStyle.Solid)   => "fa-solid",
                   (IconFamily.Sharp, IconStyle.Thin)      => "fa-sharp fa-thin",
                   (IconFamily.Sharp, IconStyle.Light)     => "fa-sharp fa-light",
                   (IconFamily.Sharp, IconStyle.Regular)   => "fa-sharp fa-regular",
                   (IconFamily.Sharp, IconStyle.Solid)     => "fa-sharp fa-solid",
                   _                                       => "fa-solid" // Default in the case no icon was provided
               };
    }

    public static string ToPrefix(Icon icon)
    {
        return ToPrefix(icon.Family, icon.Style);
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
        this.ApplyClass(sb, null, false, _cssClass);
        sb.Append("\"");
        if (this.ApplyStyle(sb, null, _cssStyle, () => sb.Append(" style=\"")))
        {
            sb.Append('"');
        }
        ApplyAttributes(sb);
        sb.Append("></i>");
        return sb.ToString();
    }

    private void ApplyAttributes(StringBuilder sb)
    {
        if (_mask != null)
        {
            sb.Append(" data-fa-mask=\"");
            this.ApplyMask(sb);
            sb.Append('"');
        }

        if (this.ApplyTransform(sb, null, () => sb.Append(" data-fa-transform=\"")))
        {
            sb.Append('"');
        }
    }

    public Icon ApplyChanges(IIcon other)
    {
        var @this = this;
        if (other.Size != IconSize.Normal)
        {
            @this = @this.Size(other.Size);
        }

        if (other.FixedWidth)
        {
            @this = @this.FixedWidth(other.FixedWidth);
        }

        if (other.Animation != IconAnimation.None)
        {
            @this = @this.Animate(
                other.Animation,
                other.AnimationDelay,
                other.AnimationDirection,
                other.AnimationDuration,
                other.AnimationIterationCount,
                other.AnimationTiming
            );

            if (_animation.HasFlag(IconAnimation.Beat))
            {
                if (other.BeatScale.HasValue)
                {
                    @this = @this.BeatScale(other.BeatScale);
                }
            }

            if (_animation.HasFlag(IconAnimation.BeatFade))
            {
                if (other.BeatFadeScale.HasValue)
                {
                    @this = @this.BeatFadeScale(other.BeatFadeScale);
                }

                if (other.BeatFadeOpacity.HasValue)
                {
                    @this = @this.BeatFadeOpacity(other.BeatFadeOpacity);
                }
            }

            if (_animation.HasFlag(IconAnimation.Bounce))
            {
                @this = @this.Bounce(
                    other.BounceRebound,
                    other.BounceHeight,
                    other.BounceStartScaleX,
                    other.BounceStartScaleY,
                    other.BounceJumpScaleX,
                    other.BounceJumpScaleY,
                    other.BounceLandScaleX,
                    other.BounceLandScaleY
                );
            }

            if (_animation.HasFlag(IconAnimation.Fade))
            {
                if (other.FadeOpacity.HasValue)
                {
                    @this = @this.FadeOpacity(other.FadeOpacity);
                }
            }

            if (_animation.HasFlag(IconAnimation.Flip))
            {
                @this = @this.Flip(
                    other.FlipX,
                    other.FlipY,
                    other.FlipZ,
                    other.FlipAngle
                );
            }
        }

        if (other.Pull != IconPull.None)
        {
            @this = @this.Pull(other.Pull);
            if (!string.IsNullOrWhiteSpace(other.PullMargin))
            {
                @this = @this.PullMargin(other.PullMargin);
            }
        }

        if (other.Border)
        {
            @this = @this.Border(other.Border);
            if (!string.IsNullOrWhiteSpace(other.BorderColor))
            {
                @this = @this.BorderColor(other.BorderColor);
            }

            if (!string.IsNullOrWhiteSpace(other.BorderPadding))
            {
                @this = @this.BorderPadding(other.BorderPadding);
            }

            if (!string.IsNullOrWhiteSpace(other.BorderRadius))
            {
                @this = @this.BorderRadius(other.BorderRadius);
            }

            if (!string.IsNullOrWhiteSpace(other.BorderStyle))
            {
                @this = @this.BorderStyle(other.BorderStyle);
            }

            if (!string.IsNullOrWhiteSpace(other.BorderWidth))
            {
                @this = @this.BorderWidth(other.BorderWidth);
            }
        }

        if (other.Inverse)
        {
            @this = @this.Inverse(other.Inverse);
        }

        if (!string.IsNullOrWhiteSpace(other.StackZIndex))
        {
            @this = @this.StackZIndex(other.StackZIndex);
        }

        if (!string.IsNullOrWhiteSpace(other.RotateBy))
        {
            @this = @this.RotateBy(other.RotateBy);
        }

        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (other.Rotate is > 0.001 or < -0.001)
        {
            @this = @this.Rotate(other.Rotate);
        }

        if (other.FlipTransform.HasValue)
        {
            @this = @this.FlipIcon(other.FlipTransform.Value);
        }

        if (other.Shrink is > 0.001 or < -0.001)
        {
            @this = @this.Shrink(other.Shrink);
        }

        if (other.Grow is > 0.001 or < -0.001)
        {
            @this = @this.Grow(other.Grow);
        }

        if (other.Up is > 0.001 or < -0.001)
        {
            @this = @this.Up(other.Up);
        }

        if (other.Down is > 0.001 or < -0.001)
        {
            @this = @this.Down(other.Down);
        }

        if (other.Left is > 0.001 or < -0.001)
        {
            @this = @this.Left(other.Left);
        }

        if (other.Right is > 0.001 or < -0.001)
        {
            @this = @this.Right(other.Right);
        }

        if (other.Mask != null)
        {
            @this = @this.Mask(other.Mask);
        }

        if (!string.IsNullOrWhiteSpace(other.CssClass))
        {
            @this = @this.CssClass(other.CssClass);
        }

        if (!string.IsNullOrWhiteSpace(other.CssStyle))
        {
            @this = @this.CssStyle(other.CssStyle);
        }

        return @this;
    }

    double ITransformIcon.Grow => _grow;
    double ITransformIcon.Shrink => _shrink;
    double ITransformIcon.Rotate => _rotate;
    double ITransformIcon.Up => _up;
    double ITransformIcon.Down => _down;
    double ITransformIcon.Left => _left;
    double ITransformIcon.Right => _right;
    IconFlip? ITransformIcon.FlipTransform => _flipIcon;

    IconSize ISharedIcon.Size => _size;
    string? ISharedIcon.CssStyle => _cssStyle;
    string? ISharedIcon.CssClass => _cssClass;
    bool ISharedIcon.FixedWidth => _fixedWidth;

    IconPull IIcon.Pull => _pull;
    IconAnimation IAnimationIcon.Animation => _animation;
    bool ISharedIcon.Border => _border;
    bool IIcon.Inverse => _inverse;
    Icon? IIcon.Mask => _mask;

    bool IIcon.SwapOpacity => _swapOpacity;
    double? IIcon.PrimaryOpacity => _primaryOpacity;
    double? IIcon.SecondaryOpacity => _secondaryOpacity;
    string? IIcon.PrimaryColor => _primaryColor;
    string? IIcon.SecondaryColor => _secondaryColor;
    string? IAnimationIcon.AnimationDelay => _animationDelay;
    string? IAnimationIcon.AnimationDirection => _animationDirection;
    string? IAnimationIcon.AnimationDuration => _animationDuration;
    string? IAnimationIcon.AnimationIterationCount => _animationIterationCount;
    string? IAnimationIcon.AnimationTiming => _animationTiming;
    double? IAnimationIcon.BeatScale => _beatScale;
    double? IAnimationIcon.FadeOpacity => _fadeOpacity;
    double? IAnimationIcon.BeatFadeOpacity => _beatFadeOpacity;
    double? IAnimationIcon.BeatFadeScale => _beatFadeScale;
    double? IAnimationIcon.BounceRebound => _bounceRebound;
    double? IAnimationIcon.BounceHeight => _bounceHeight;
    double? IAnimationIcon.BounceStartScaleX => _bounceStartScaleX;
    double? IAnimationIcon.BounceStartScaleY => _bounceStartScaleY;
    double? IAnimationIcon.BounceJumpScaleX => _bounceJumpScaleX;
    double? IAnimationIcon.BounceJumpScaleY => _bounceJumpScaleY;
    double? IAnimationIcon.BounceLandScaleX => _bounceLandScaleX;
    double? IAnimationIcon.BounceLandScaleY => _bounceLandScaleY;
    double? IAnimationIcon.FlipX => _flipX;
    double? IAnimationIcon.FlipY => _flipY;
    double? IAnimationIcon.FlipZ => _flipZ;
    string? IAnimationIcon.FlipAngle => _flipAngle;
    string? ISharedIcon.BorderColor => _borderColor;
    string? ISharedIcon.BorderPadding => _borderPadding;
    string? ISharedIcon.BorderRadius => _borderRadius;
    string? ISharedIcon.BorderStyle => _borderStyle;
    string? ISharedIcon.BorderWidth => _borderWidth;
    string? IIcon.PullMargin => _pullMargin;
    string? IIcon.StackZIndex => _stackZIndex;
    string? IIcon.InverseColor => _inverseColor;
    string? IIcon.RotateBy => _rotateBy;
}
