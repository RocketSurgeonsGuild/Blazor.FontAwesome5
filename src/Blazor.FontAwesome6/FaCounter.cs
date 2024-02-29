using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public class FaCounter : ComponentBase, ITransformIcon, IAnimationIcon, ISharedIcon, IAnimationComponent
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public IconSize Size { get; set; }

    [Parameter]
    public bool FixedWidth { get; set; }

    [Parameter]
    public bool Border { get; set; }

    [Parameter]
    public string? BorderWidth { get; set; }

    [Parameter]
    public string? BorderStyle { get; set; }

    [Parameter]
    public string? BorderPadding { get; set; }

    [Parameter]
    public string? BorderColor { get; set; }

    [Parameter]
    public bool Inverse { get; set; }


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


    [Parameter]
    public double BounceLandScaleY { get; set; }


    [Parameter]
    public double BounceLandScaleX { get; set; }


    [Parameter]
    public double BounceJumpScaleY { get; set; }


    [Parameter]
    public double BounceJumpScaleX { get; set; }


    [Parameter]
    public double BounceStartScaleY { get; set; }


    [Parameter]
    public double BounceStartScaleX { get; set; }


    [Parameter]
    public double BounceRebound { get; set; }


    [Parameter]
    public double BounceHeight { get; set; }

    [Parameter]
    public IconAnimation Animation { get; set; }

    [Parameter]
    public string? AnimationDelay { get; set; }

    [Parameter]
    public string? AnimationDirection { get; set; }

    [Parameter]
    public string? AnimationDuration { get; set; }

    [Parameter]
    public string? AnimationIterationCount { get; set; }

    [Parameter]
    public string? AnimationTiming { get; set; }

    [Parameter]
    public bool Beat { get; set; }

    [Parameter]
    public bool BeatFade { get; set; }

    [Parameter]
    public bool Bounce { get; set; }

    [Parameter]
    public bool Spin { get; set; }

    [Parameter]
    public bool Flip { get; set; }

    [Parameter]
    public bool Shake { get; set; }

    [Parameter]
    public bool SpinPulse { get; set; }

    [Parameter]
    public bool Fade { get; set; }

    [Parameter]
    public bool Reverse { get; set; }

    [Parameter]
    public IconFlip? FlipTransform { get; set; }

    [Parameter]
    public IconCounterPosition? Position { get; set; }

    [Parameter]
    public string? BackgroundColor { get; set; }

    [Parameter]
    public string? BorderRadius { get; set; }

    [Parameter]
    public string? LineHeight { get; set; }

    [Parameter]
    public string? MaxWidth { get; set; }

    [Parameter]
    public string? MinWidth { get; set; }

    [Parameter]
    public string? Padding { get; set; }

    [Parameter]
    public double? Scale { get; set; }

    [Parameter]
    public string? TopOffset { get; set; }

    [Parameter]
    public string? RightOffset { get; set; }

    [Parameter]
    public string? BottomOffset { get; set; }

    [Parameter]
    public string? LeftOffset { get; set; }

    [Parameter]
    public string? InverseColor { get; set; }

    [Parameter]
    public string? FlipAngle { get; set; }


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

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    #pragma warning disable CA2227
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new();
    #pragma warning restore CA2227

    string? ISharedIcon.CssStyle => Style;
    string? ISharedIcon.CssClass => Class;

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

    private string ToClass()
    {
        var sb = new StringBuilder();
        sb.Append("fa-layers-counter");
        this.ApplyClass(sb, null, false, Class);

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
        this.ApplyStyle(values, null, Style);

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
        var transform = this.ToTransform(null);
        if (!string.IsNullOrWhiteSpace(transform))
            builder.AddAttribute(3, "data-fa-transform", transform);
        builder.AddMultipleAttributes(4, AdditionalAttributes);
        if (ChildContent != null)
            builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
