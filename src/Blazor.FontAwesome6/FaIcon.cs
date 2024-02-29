using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome6;

[PublicAPI]
public sealed class FaIcon : ComponentBase, IIcon, IAnimationComponent
{
    [CascadingParameter] private FaStack? Stack { get; set; }

    [Parameter, EditorRequired] public required Icon Icon { get; set; }

    [Parameter] public string? StackZIndex { get; set; }
    [Parameter] public string? RotateBy { get; set; }
    [Parameter] public string? PullMargin { get; set; }
    [Parameter] public string? BorderWidth { get; set; }
    [Parameter] public string? BorderStyle { get; set; }
    [Parameter] public string? BorderRadius { get; set; }
    [Parameter] public string? BorderPadding { get; set; }
    [Parameter] public string? BorderColor { get; set; }

    [Parameter] public double BounceLandScaleY{ get; set; }

    [Parameter] public double BounceLandScaleX{ get; set; }

    [Parameter] public double BounceJumpScaleY{ get; set; }

    [Parameter] public double BounceJumpScaleX{ get; set; }

    [Parameter] public double BounceStartScaleY{ get; set; }

    [Parameter] public double BounceStartScaleX{ get; set; }

    [Parameter] public double BounceRebound{ get; set; }

    [Parameter] public double BounceHeight{ get; set; }

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

    IconFamily IIcon.Family => Icon.Family;
    IconStyle IIcon.Style => Icon.Style;
    string? ISharedIcon.CssStyle => Style;
    string? ISharedIcon.CssClass => Class;

    string IIcon.Name => Icon.Name;

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

        builder.AddAttribute(1, "class", Icon.ToClass(this, Stack != null, Class));
        var style = Icon.ToStyle(this, Style);
        if (!string.IsNullOrWhiteSpace(style))
            builder.AddAttribute(2, "style", style);
        var transform = Icon.ToTransform(this);
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
