using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome6;

[PublicAPI]
public sealed class FaIcon : ComponentBase, IIcon
{
    private Icon _icon = new Icon(IconFamily.Classic, IconStyle.Solid, "bomb");

    [CascadingParameter] private FaStack? Stack { get; set; }

    [Parameter]
    public Icon Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            var iIcon = (IIcon)_icon;
            if (iIcon.Size != IconSize.Normal)
            {
                Size = iIcon.Size;
            }

            if (iIcon.FixedWidth)
            {
                FixedWidth = iIcon.FixedWidth;
            }

            if (iIcon.Animation != IconAnimation.None)
            {
                Animation = iIcon.Animation;
                AnimationDelay = iIcon.AnimationDelay;
                AnimationDirection = iIcon.AnimationDirection;
                AnimationDuration = iIcon.AnimationDuration;
                AnimationIterationCount = iIcon.AnimationIterationCount;
                AnimationTiming = iIcon.AnimationTiming;

                if (Beat)
                {
                    if (iIcon.BeatScale.HasValue)
                    {
                        BeatScale = iIcon.BeatScale.Value;
                    }
                }

                if (BeatFade)
                {
                    if (iIcon.BeatFadeScale.HasValue)
                    {
                        BeatFadeScale = iIcon.BeatFadeScale.Value;
                    }

                    if (iIcon.FadeOpacity.HasValue)
                    {
                        BeatFadeOpacity = iIcon.FadeOpacity.Value;
                    }
                }

                if (Bounce)
                {
                    if (iIcon.BounceHeight.HasValue)
                    {
                        BounceHeight = iIcon.BounceHeight.Value;
                    }

                    if (iIcon.BounceRebound.HasValue)
                    {
                        BounceRebound = iIcon.BounceRebound.Value;
                    }

                    if (iIcon.BounceStartScaleX.HasValue)
                    {
                        BounceStartScaleX = iIcon.BounceStartScaleX.Value;
                    }

                    if (iIcon.BounceStartScaleY.HasValue)
                    {
                        BounceStartScaleY = iIcon.BounceStartScaleY.Value;
                    }

                    if (iIcon.BounceJumpScaleX.HasValue)
                    {
                        BounceJumpScaleX = iIcon.BounceJumpScaleX.Value;
                    }

                    if (iIcon.BounceJumpScaleY.HasValue)
                    {
                        BounceJumpScaleY = iIcon.BounceJumpScaleY.Value;
                    }

                    if (iIcon.BounceLandScaleX.HasValue)
                    {
                        BounceLandScaleX = iIcon.BounceLandScaleX.Value;
                    }

                    if (iIcon.BounceLandScaleY.HasValue)
                    {
                        BounceLandScaleY = iIcon.BounceLandScaleY.Value;
                    }
                }

                if (Fade)
                {
                    if (iIcon.FadeOpacity.HasValue)
                    {
                        FadeOpacity = iIcon.FadeOpacity.Value;
                    }
                }

                if (Flip)
                {
                    if (iIcon.FlipX.HasValue)
                    {
                        FlipX = iIcon.FlipX.Value;
                    }

                    if (iIcon.FlipY.HasValue)
                    {
                        FlipY = iIcon.FlipY.Value;
                    }

                    if (iIcon.FlipZ.HasValue)
                    {
                        FlipZ = iIcon.FlipZ.Value;
                    }

                    if (!string.IsNullOrWhiteSpace(iIcon.FlipAngle))
                    {
                        FlipAngle = iIcon.FlipAngle;
                    }
                }
            }

            if (iIcon.Pull != IconPull.None)
            {
                Pull = iIcon.Pull;
                if (!string.IsNullOrWhiteSpace(iIcon.PullMargin))
                {
                    PullMargin = iIcon.PullMargin;
                }
            }

            if (iIcon.Border)
            {
                Border = iIcon.Border;
                if (!string.IsNullOrWhiteSpace(iIcon.BorderColor))
                {
                    BorderColor = iIcon.BorderColor;
                }

                if (!string.IsNullOrWhiteSpace(iIcon.BorderPadding))
                {
                    BorderPadding = iIcon.BorderPadding;
                }

                if (!string.IsNullOrWhiteSpace(iIcon.BorderRadius))
                {
                    BorderRadius = iIcon.BorderRadius;
                }

                if (!string.IsNullOrWhiteSpace(iIcon.BorderStyle))
                {
                    BorderStyle = iIcon.BorderStyle;
                }

                if (!string.IsNullOrWhiteSpace(iIcon.BorderWidth))
                {
                    BorderWidth = iIcon.BorderWidth;
                }
            }

            if (iIcon.Inverse)
            {
                Inverse = iIcon.Inverse;
            }

            if (!string.IsNullOrWhiteSpace(iIcon.StackZIndex))
            {
                StackZIndex = iIcon.StackZIndex;
            }

            if (!string.IsNullOrWhiteSpace(iIcon.RotateBy))
            {
                RotateBy = iIcon.RotateBy;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (iIcon.Rotate is > 0.001 or < -0.001)
            {
                Rotate = iIcon.Rotate;
            }

            if (iIcon.FlipTransform == IconFlip.None)
            {
                FlipTransform = iIcon.FlipTransform;
            }

            double assignIfGreaterThan0(double lhs, double value) => value > 0.001 ? value : lhs;

            Shrink = assignIfGreaterThan0(Shrink, iIcon.Shrink);
            Grow = assignIfGreaterThan0(Grow, iIcon.Grow);
            Up = assignIfGreaterThan0(Up, iIcon.Up);
            Down = assignIfGreaterThan0(Down, iIcon.Down);
            Left = assignIfGreaterThan0(Left, iIcon.Left);
            Right = assignIfGreaterThan0(Right, iIcon.Right);

            if (iIcon.Mask != null)
            {
                Mask = iIcon.Mask;
            }

            if (!string.IsNullOrWhiteSpace(iIcon.CssClass))
            {
                Class = iIcon.CssClass;
            }

            if (!string.IsNullOrWhiteSpace(iIcon.CssStyle))
            {
                Style = iIcon.CssStyle;
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

    [Parameter]
    public double BounceLandScaleY{ get; set; }

    [Parameter]
    public double BounceLandScaleX{ get; set; }

    [Parameter]
    public double BounceJumpScaleY{ get; set; }

    [Parameter]
    public double BounceJumpScaleX{ get; set; }

    [Parameter]
    public double BounceStartScaleY{ get; set; }

    [Parameter]
    public double BounceStartScaleX{ get; set; }

    [Parameter]
    public double BounceRebound{ get; set; }

    [Parameter]
    public double BounceHeight{ get; set; }

    [Parameter] public IconAnimation Animation { get; set; }
    [Parameter] public string? AnimationDelay { get; set; }
    [Parameter] public string? AnimationDirection { get; set; }
    [Parameter] public string? AnimationDuration { get; set; }
    [Parameter] public string? AnimationIterationCount { get; set; }
    [Parameter] public string? AnimationTiming { get; set; }

    [Parameter] public string? FlipAngle { get; set; }

    [Parameter]
    public double FlipX { get; set; }

    [Parameter]
    public double FlipY { get; set; }

    [Parameter]
    public double FlipZ { get; set; }

    [Parameter]
    public double BeatFadeOpacity { get; set; }

    [Parameter]
    public double BeatFadeScale { get; set; }

    [Parameter]
    public double FadeOpacity { get; set; }

    [Parameter]
    public double BeatScale { get; set; }

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

    [Parameter]
    public double Grow { get; set; }

    [Parameter]
    public double Shrink { get; set; }

    [Parameter]
    public double Up { get; set; }

    [Parameter]
    public double Down { get; set; }

    [Parameter]
    public double Left { get; set; }

    [Parameter]
    public double Right { get; set; }

    [Parameter]
    public double Rotate { get; set; }

    [Parameter] public IconFlip? FlipTransform { get; set; }

    [Parameter] public Icon? Mask { get; set; }

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }

    [Parameter] public bool SwapOpacity { get; set; }

    [Parameter]
    public double? PrimaryOpacity { get; set; }

    [Parameter]
    public double? SecondaryOpacity { get; set; }

    [Parameter] public string? PrimaryColor { get; set; }

    [Parameter] public string? SecondaryColor { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
#pragma warning disable CA2227
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new();
#pragma warning restore CA2227

    IconFamily IIcon.Family => _icon.Family;
    IconStyle IIcon.Style => _icon.Style;
    string? ISharedIcon.CssStyle => Style;
    string? ISharedIcon.CssClass => Class;

    string IIcon.Name => _icon.Name;

    double? IIcon.PrimaryOpacity => PrimaryOpacity;
    double? IIcon.SecondaryOpacity => SecondaryOpacity;
    double? IAnimationIcon.BeatScale => BeatScale;
    double? IAnimationIcon.FadeOpacity => FadeOpacity;
    double? IAnimationIcon.BeatFadeOpacity => BeatFadeOpacity;
    double? IAnimationIcon.BeatFadeScale => BeatFadeScale;

    double? IAnimationIcon.BounceRebound => BounceRebound;
    double? IAnimationIcon.BounceHeight => BounceHeight;
    double? IAnimationIcon.BounceStartScaleX => BounceStartScaleX;
    double? IAnimationIcon.BounceStartScaleY => BounceStartScaleY;
    double? IAnimationIcon.BounceJumpScaleX => BounceJumpScaleX;
    double? IAnimationIcon.BounceJumpScaleY => BounceJumpScaleY;
    double? IAnimationIcon.BounceLandScaleX => BounceLandScaleX;
    double? IAnimationIcon.BounceLandScaleY => BounceLandScaleY;

    double? IAnimationIcon.FlipX => FlipX;
    double? IAnimationIcon.FlipY => FlipY;
    double? IAnimationIcon.FlipZ => FlipZ;

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
