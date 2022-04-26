using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rocket.Surgery.Blazor.FontAwesome5;

namespace Rocket.Surgery.Blazor.FontAwesome6;

[PublicAPI]
public sealed class FaIcon : ComponentBase, IIcon
{
    private Icon _icon = new Icon(IconStyle.Unknown, "");

    [CascadingParameter] private FaStack? Stack { get; set; }

    [Parameter]
    public Icon Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            if (_icon._size != IconSize.Normal)
            {
                Size = _icon._size;
            }

            if (_icon._fixedWidth)
            {
                FixedWidth = _icon._fixedWidth;
            }

            if (_icon._animation != IconAnimation.None)
            {
                Animation = _icon._animation;
                AnimationDelay = _icon._animationDelay;
                AnimationDirection = _icon._animationDirection;
                AnimationDuration = _icon._animationDuration;
                AnimationIterationCount = _icon._animationIterationCount;
                AnimationTiming = _icon._animationTiming;

                if (Beat)
                {
                    if (_icon._beatScale.HasValue)
                    {
                        BeatScale = _icon._beatScale.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }
                }

                if (BeatFade)
                {
                    if (_icon._beatFadeScale.HasValue)
                    {
                        BeatFadeScale = _icon._beatFadeScale.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._beatFadeOpacity.HasValue)
                    {
                        BeatFadeOpacity = _icon._beatFadeOpacity.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }
                }

                if (Bounce)
                {
                    if (_icon._bounceHeight.HasValue)
                    {
                        BounceHeight = _icon._bounceHeight.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceRebound.HasValue)
                    {
                        BounceRebound = _icon._bounceRebound.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceStartScaleX.HasValue)
                    {
                        BounceStartScaleX = _icon._bounceStartScaleX.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceStartScaleY.HasValue)
                    {
                        BounceStartScaleY = _icon._bounceStartScaleY.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceJumpScaleX.HasValue)
                    {
                        BounceJumpScaleX = _icon._bounceJumpScaleX.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceJumpScaleY.HasValue)
                    {
                        BounceJumpScaleY = _icon._bounceJumpScaleY.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceLandScaleX.HasValue)
                    {
                        BounceLandScaleX = _icon._bounceLandScaleX.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._bounceLandScaleY.HasValue)
                    {
                        BounceLandScaleY = _icon._bounceLandScaleY.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }
                }

                if (Fade)
                {
                    if (_icon._fadeOpacity.HasValue)
                    {
                        FadeOpacity = _icon._fadeOpacity.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }
                }

                if (Flip)
                {
                    if (_icon._flipX.HasValue)
                    {
                        FlipX = _icon._flipX.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._flipY.HasValue)
                    {
                        FlipY = _icon._flipY.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (_icon._flipZ.HasValue)
                    {
                        FlipZ = _icon._flipZ.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (!string.IsNullOrWhiteSpace(_icon._flipAngle))
                    {
                        FlipAngle = _icon._flipAngle;
                    }
                }
            }

            if (_icon._pull != IconPull.None)
            {
                Pull = _icon._pull;
                if (!string.IsNullOrWhiteSpace(_icon._pullMargin))
                {
                    PullMargin = _icon._pullMargin;
                }
            }

            if (_icon._border)
            {
                Border = _icon._border;
                if (!string.IsNullOrWhiteSpace(_icon._borderColor))
                {
                    BorderColor = _icon._borderColor;
                }

                if (!string.IsNullOrWhiteSpace(_icon._borderPadding))
                {
                    BorderPadding = _icon._borderPadding;
                }

                if (!string.IsNullOrWhiteSpace(_icon._borderRadius))
                {
                    BorderRadius = _icon._borderRadius;
                }

                if (!string.IsNullOrWhiteSpace(_icon._borderStyle))
                {
                    BorderStyle = _icon._borderStyle;
                }

                if (!string.IsNullOrWhiteSpace(_icon._borderWidth))
                {
                    BorderWidth = _icon._borderWidth;
                }
            }

            if (_icon._inverse)
            {
                Inverse = _icon._inverse;
            }

            if (!string.IsNullOrWhiteSpace(_icon._stackZIndex))
            {
                StackZIndex = _icon._stackZIndex;
            }

            if (!string.IsNullOrWhiteSpace(_icon._rotateBy))
            {
                RotateBy = _icon._rotateBy;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_icon._rotate is > 0.001 or < -0.001)
            {
                _rotate = _icon._rotate;
            }

            if (_icon._flipIcon == IconFlip.None)
            {
                FlipTransform = _icon._flipIcon;
            }

            void assignIfGreaterThan0(ref double lhs, double value)
            {
                if (value > 0.001)
                {
                    lhs = value;
                }
            }

            assignIfGreaterThan0(ref _shrink, _icon._shrink);
            assignIfGreaterThan0(ref _grow, _icon._grow);
            assignIfGreaterThan0(ref _up, _icon._up);
            assignIfGreaterThan0(ref _down, _icon._down);
            assignIfGreaterThan0(ref _left, _icon._left);
            assignIfGreaterThan0(ref _right, _icon._right);

            if (_icon._mask != null)
            {
                Mask = _icon._mask;
            }

            if (!string.IsNullOrWhiteSpace(_icon._cssClass))
            {
                Class = _icon._cssClass;
            }

            if (!string.IsNullOrWhiteSpace(_icon._cssStyle))
            {
                Style = _icon._cssStyle;
            }
        }
    }

    [Parameter] public string? StackZIndex { get; set; }
    [Parameter] public string? RotateBy { get; set; }
    [Parameter] public string? PullMargin { get; set; }
    [Parameter] public string? BorderWidth { get; set; }
    [Parameter] public string? BorderStyle { get; set; }
    [Parameter] public string? BorderRadius { get; set; }
    [Parameter] public string? BorderPadding { get; set; }
    [Parameter] public string? BorderColor { get; set; }

    private double _bounceLandScaleY;

    [Parameter]
    public string BounceLandScaleY
    {
        get => _bounceLandScaleY.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceLandScaleY = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceLandScaleX;

    [Parameter]
    public string BounceLandScaleX
    {
        get => _bounceLandScaleX.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceLandScaleX = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceJumpScaleY;

    [Parameter]
    public string BounceJumpScaleY
    {
        get => _bounceJumpScaleY.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceJumpScaleY = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceJumpScaleX;

    [Parameter]
    public string BounceJumpScaleX
    {
        get => _bounceJumpScaleX.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceJumpScaleX = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceStartScaleY;

    [Parameter]
    public string BounceStartScaleY
    {
        get => _bounceStartScaleY.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceStartScaleY = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceStartScaleX;

    [Parameter]
    public string BounceStartScaleX
    {
        get => _bounceStartScaleX.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceStartScaleX = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceRebound;

    [Parameter]
    public string BounceRebound
    {
        get => _bounceRebound.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceRebound = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _bounceHeight;

    [Parameter]
    public string BounceHeight
    {
        get => _bounceHeight.ToString("F2", CultureInfo.InvariantCulture);
        set => _bounceHeight = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    [Parameter] public IconAnimation Animation { get; set; }
    [Parameter] public string? AnimationDelay { get; set; }
    [Parameter] public string? AnimationDirection { get; set; }
    [Parameter] public string? AnimationDuration { get; set; }
    [Parameter] public string? AnimationIterationCount { get; set; }
    [Parameter] public string? AnimationTiming { get; set; }

    [Parameter] public string? FlipAngle { get; set; }

    private double _flipX;

    [Parameter]
    public string FlipX
    {
        get => _flipX.ToString("F2", CultureInfo.InvariantCulture);
        set => _flipX = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _flipY;

    [Parameter]
    public string FlipY
    {
        get => _flipY.ToString("F2", CultureInfo.InvariantCulture);
        set => _flipY = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _flipZ;

    [Parameter]
    public string FlipZ
    {
        get => _flipZ.ToString("F2", CultureInfo.InvariantCulture);
        set => _flipZ = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _beatFadeOpacity;

    [Parameter]
    public string BeatFadeOpacity
    {
        get => _beatFadeOpacity.ToString("F2", CultureInfo.InvariantCulture);
        set => _beatFadeOpacity = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _beatFadeScale;

    [Parameter]
    public string BeatFadeScale
    {
        get => _beatFadeScale.ToString("F2", CultureInfo.InvariantCulture);
        set => _beatFadeScale = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _fadeOpacity;

    [Parameter]
    public string FadeOpacity
    {
        get => _fadeOpacity.ToString("F2", CultureInfo.InvariantCulture);
        set => _fadeOpacity = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _beatScale;

    [Parameter]
    public string BeatScale
    {
        get => _beatScale.ToString("F2", CultureInfo.InvariantCulture);
        set => _beatScale = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    [Parameter] public IconSize Size { get; set; }
    [Parameter] public bool FixedWidth { get; set; }
    [Parameter] public IconPull? Pull { get; set; }

    [Parameter]
    public bool Beat
    {
        get => ( Animation & IconAnimation.Beat ) == IconAnimation.Beat;
        set => Animation = value ? IconAnimation.Beat | ( Animation & IconAnimation.Reverse ) : Animation & ~ IconAnimation.Beat;
    }

    [Parameter]
    public bool BeatFade
    {
        get => ( Animation & IconAnimation.BeatFade ) == IconAnimation.BeatFade;
        set => Animation = value ? IconAnimation.BeatFade | ( Animation & IconAnimation.Reverse ) : Animation & ~ IconAnimation.BeatFade;
    }

    [Parameter]
    public bool Bounce
    {
        get => ( Animation & IconAnimation.Bounce ) == IconAnimation.Bounce;
        set => Animation = value ? IconAnimation.Bounce | ( Animation & IconAnimation.Reverse ) : Animation & ~ IconAnimation.Bounce;
    }

    [Parameter]
    public bool Spin
    {
        get => ( Animation & IconAnimation.Spin ) == IconAnimation.Spin;
        set => Animation = value ? IconAnimation.Spin | ( Animation & IconAnimation.Reverse ) : Animation & ~ IconAnimation.Spin;
    }

    [Parameter]
    public bool Flip
    {
        get => ( Animation & IconAnimation.Flip ) == IconAnimation.Flip;
        set => Animation = value ? IconAnimation.Flip | ( Animation & IconAnimation.Reverse ) : Animation & ~ IconAnimation.Flip;
    }

    [Parameter]
    public bool Shake
    {
        get => ( Animation & IconAnimation.Shake ) == IconAnimation.Shake;
        set => Animation = value ? IconAnimation.Shake | ( Animation & IconAnimation.Reverse ) : Animation & ~ IconAnimation.Shake;
    }

    [Parameter]
    public bool SpinPulse
    {
        get => ( Animation & IconAnimation.SpinPulse ) == IconAnimation.SpinPulse;
        set => Animation = value ? IconAnimation.SpinPulse | ( Animation & IconAnimation.Reverse ) : Animation & ~IconAnimation.SpinPulse;
    }

    [Parameter]
    public bool Fade
    {
        get => ( Animation & IconAnimation.Fade ) == IconAnimation.Fade;
        set => Animation = value ? IconAnimation.Fade | ( Animation & IconAnimation.Reverse ) : Animation & ~IconAnimation.Fade;
    }

    [Parameter]
    public bool SpinReverse
    {
        get => ( Animation & IconAnimation.Reverse ) == IconAnimation.Reverse;
        set => Animation = value ? Animation | IconAnimation.Reverse : Animation & ~IconAnimation.Reverse;
    }

    [Parameter] public bool Border { get; set; }
    [Parameter] public bool Inverse { get; set; }
    [Parameter] public string? InverseColor { get; set; }

    private double _grow;

    [Parameter]
    public string Grow
    {
        get => _grow.ToString("F2", CultureInfo.InvariantCulture);
        set => _grow = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _shrink;

    [Parameter]
    public string Shrink
    {
        get => _shrink.ToString("F2", CultureInfo.InvariantCulture);
        set => _shrink = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _up;

    [Parameter]
    public string Up
    {
        get => _up.ToString("F2", CultureInfo.InvariantCulture);
        set => _up = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _down;

    [Parameter]
    public string Down
    {
        get => _down.ToString("F2", CultureInfo.InvariantCulture);
        set => _down = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _left;

    [Parameter]
    public string Left
    {
        get => _left.ToString("F2", CultureInfo.InvariantCulture);
        set => _left = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _right;

    [Parameter]
    public string Right
    {
        get => _right.ToString("F2", CultureInfo.InvariantCulture);
        set => _right = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    private double _rotate;

    [Parameter]
    public string Rotate
    {
        get => _rotate.ToString("F2", CultureInfo.InvariantCulture);
        set => _rotate = double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var d) ? d : 0;
    }

    [Parameter] public IconFlip? FlipTransform { get; set; }

    [Parameter] public Icon? Mask { get; set; }

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }

    [Parameter] public bool SwapOpacity { get; set; }

    private double? _primaryOpacity;

    [Parameter]
    public string? PrimaryOpacity
    {
        get => _primaryOpacity?.ToString("F2", CultureInfo.InvariantCulture);
        set => _primaryOpacity = value is null ? null : double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : null;
    }

    private double? _secondaryOpacity;

    [Parameter]
    public string? SecondaryOpacity
    {
        get => _secondaryOpacity?.ToString("F2", CultureInfo.InvariantCulture);
        set => _secondaryOpacity = value is null ? null : double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var v) ? v : null;
    }

    [Parameter] public string? PrimaryColor { get; set; }

    [Parameter] public string? SecondaryColor { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
#pragma warning disable CA2227
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new();
#pragma warning restore CA2227

    double ITransformIcon.Grow => _grow;
    double ITransformIcon.Shrink => _shrink;
    double ITransformIcon.Rotate => _rotate;
    double ITransformIcon.Up => _up;
    double ITransformIcon.Down => _down;
    double ITransformIcon.Left => _left;
    double ITransformIcon.Right => _right;

    IconStyle IIcon.Style => _icon.Style;
    string? ISharedIcon.CssStyle => Style;
    string? ISharedIcon.CssClass => Class;

    string IIcon.Name => _icon.Name;

    double? IIcon.PrimaryOpacity => _primaryOpacity;
    double? IIcon.SecondaryOpacity => _secondaryOpacity;
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

    IconPull IIcon.Pull => Pull ?? IconPull.None;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        //<i class="@ToClass()" @attributes="GetAttributes()" style="@AllStyle"></i>
        builder.OpenElement(0, "i");

        builder.AddAttribute(1, "class", this.ToClass(Stack != null, Class));
        var style = this.ToStyle(Style);
        if (!string.IsNullOrWhiteSpace(style))
            builder.AddAttribute(2, "style", style);
        var transform = this.ToTransform();
        if (!string.IsNullOrWhiteSpace(transform))
            builder.AddAttribute(3, "data-fa-transform", transform);
        if (Mask != null)
        {
            builder.AddAttribute(4, "data-fa-mask", this.ToMask());
        }

        builder.AddMultipleAttributes(5, AdditionalAttributes);
        builder.CloseElement();
    }
}
