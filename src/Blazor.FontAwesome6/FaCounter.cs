using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rocket.Surgery.Blazor.FontAwesome5;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public class FaCounter : ComponentBase, ITransformIcon, IAnimationIcon, ISharedIcon
{
    private double _grow;
    private double _shrink;
    private double _up;
    private double _down;
    private double _left;
    private double _right;
    private double _rotate;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public IconSize Size { get; set; }
    [Parameter] public bool FixedWidth { get; set; }
    [Parameter] public bool Border { get; set; }
    [Parameter] public string? BorderWidth { get; set; }
    [Parameter] public string? BorderStyle { get; set; }
    [Parameter] public string? BorderPadding { get; set; }
    [Parameter] public string? BorderColor { get; set; }
    [Parameter] public bool Inverse { get; set; }


    [Parameter]
    public string Grow
    {
        get => _grow.ToString("F2", CultureInfo.InvariantCulture);
        set => _grow = double.Parse(value, CultureInfo.InvariantCulture);
    }


    [Parameter]
    public string Shrink
    {
        get => _shrink.ToString("F2", CultureInfo.InvariantCulture);
        set => _shrink = double.Parse(value, CultureInfo.InvariantCulture);
    }

    [Parameter]
    public string Up
    {
        get => _up.ToString("F2", CultureInfo.InvariantCulture);
        set => _up = double.Parse(value, CultureInfo.InvariantCulture);
    }

    [Parameter]
    public string Down
    {
        get => _down.ToString("F2", CultureInfo.InvariantCulture);
        set => _down = double.Parse(value, CultureInfo.InvariantCulture);
    }

    [Parameter]
    public string Left
    {
        get => _left.ToString("F2", CultureInfo.InvariantCulture);
        set => _left = double.Parse(value, CultureInfo.InvariantCulture);
    }


    [Parameter]
    public string Right
    {
        get => _right.ToString("F2", CultureInfo.InvariantCulture);
        set => _right = double.Parse(value, CultureInfo.InvariantCulture);
    }

    [Parameter]
    public string Rotate
    {
        get => _rotate.ToString("F2", CultureInfo.InvariantCulture);
        set => _rotate = double.Parse(value, CultureInfo.InvariantCulture);
    }
    

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

    [Parameter] public IconFlip? FlipTransform { get; set; }

    [Parameter] public IconCounterPosition? Position { get; set; }

    [Parameter] public string? BackgroundColor { get; set; }
    [Parameter] public string? BorderRadius { get; set; }
    [Parameter] public string? LineHeight { get; set; }
    [Parameter] public string? MaxWidth { get; set; }
    [Parameter] public string? MinWidth { get; set; }
    [Parameter] public string? Padding { get; set; }
    [Parameter] public double? Scale { get; set; }
    [Parameter] public string? TopOffset { get; set; }
    [Parameter] public string? RightOffset { get; set; }
    [Parameter] public string? BottomOffset { get; set; }
    [Parameter] public string? LeftOffset { get; set; }
    [Parameter] public string? InverseColor { get; set; }

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
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Style { get; set; }

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
    
    string? ISharedIcon.CssStyle => Style;
    string? ISharedIcon.CssClass => Class;
    
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

    private string ToClass()
    {
        var sb = new StringBuilder();
        sb.Append("fa-layers-counter");
        this.ApplyClass(sb, false, Class);

        if (Position.HasValue)
        {
            sb.Append(
                Position.Value switch
                {
                    IconCounterPosition.TopRight    => " fa-layers-top-right",
                    IconCounterPosition.TopLeft     => " fa-layers-top-left",
                    IconCounterPosition.BottomRight => " fa-layers-bottom-right",
                    IconCounterPosition.BottomLeft  => " fa-layers-bottom-left",
                    _                               => throw new NotSupportedException()
                }
            );
        }

        if (Inverse)
        {
            sb.Append("fa-inverse");
        }

        return sb.ToString();
    }

    private string ToStyle()
    {
        var values = new StringBuilder();
        this.ApplyStyle(values, Style);

        if (!string.IsNullOrWhiteSpace(BackgroundColor))
        {
            values.Append(";--fa-counter-background-color: ").Append(BackgroundColor);
        }

        if (!string.IsNullOrWhiteSpace(BorderRadius))
        {
            values.Append(";--fa-counter-border-radius: ").Append(BorderRadius);
        }

        if (!string.IsNullOrWhiteSpace(LineHeight))
        {
            values.Append(";--fa-counter-line-height: ").Append(LineHeight);
        }

        if (!string.IsNullOrWhiteSpace(MaxWidth))
        {
            values.Append(";--fa-counter-max-width: ").Append(MaxWidth);
        }

        if (!string.IsNullOrWhiteSpace(MinWidth))
        {
            values.Append(";--fa-counter-min-width: ").Append(MinWidth);
        }

        if (!string.IsNullOrWhiteSpace(Padding))
        {
            values.Append(";--fa-counter-padding: ").Append(Padding);
        }

        if (Scale.HasValue)
        {
            values.Append(";--fa-counter-scale: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", Scale);
        }

        if (!string.IsNullOrWhiteSpace(TopOffset))
        {
            values.Append(";--fa-top: ").Append(TopOffset);
        }

        if (!string.IsNullOrWhiteSpace(RightOffset))
        {
            values.Append(";--fa-right: ").Append(RightOffset);
        }

        if (!string.IsNullOrWhiteSpace(BottomOffset))
        {
            values.Append(";--fa-bottom: ").Append(BottomOffset);
        }

        if (!string.IsNullOrWhiteSpace(LeftOffset))
        {
            values.Append(";--fa-left: ").Append(LeftOffset);
        }

        if (!string.IsNullOrWhiteSpace(InverseColor))
        {
            values.Append(";--fa-inverse: ").Append(InverseColor);
        }

        return values.ToString();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // <span class="@ToClass()" @attributes="GetAttributes()" style="@Style">@ChildContent</span>
        builder.OpenElement(0, "span");
        builder.AddAttribute(1, "class", ToClass());
        builder.AddAttribute(2, "style", ToStyle());
        var transform = this.ToTransform();
        if (!string.IsNullOrWhiteSpace(transform))
            builder.AddAttribute(3, "data-fa-transform", transform);
        builder.AddMultipleAttributes(4, AdditionalAttributes);
        if (ChildContent != null)
            builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
