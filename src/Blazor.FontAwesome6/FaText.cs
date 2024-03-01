using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public class FaText : ComponentBase, ITransformIcon
{
    [Parameter] public RenderFragment ChildContent { get; set; } = null!;

    [Parameter] public bool Spin { get; set; }

    [Parameter] public bool Pulse { get; set; }

    [Parameter] public bool Inverse { get; set; }

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

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
#pragma warning disable CA2227
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new();
#pragma warning restore CA2227

    public string ToClass()
    {
        var sb = new StringBuilder();
        sb.Append("fa-layers-text");

        if (!string.IsNullOrWhiteSpace(Class))
        {
            sb.Append(' ');
            sb.Append(Class);
        }

        if (Inverse)
            sb.Append(" fa-inverse");
        if (Spin)
            sb.Append(" fa-spinner");
        else if (Pulse)
            sb.Append(" fa-spinPulse");

        return sb.ToString();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // <span class="@ToClass()" @attributes="GetAttributes()" style="@Style">@ChildContent</span>
        builder.OpenElement(0, "span");
        builder.AddAttribute(1, "class", ToClass());
        if (!string.IsNullOrWhiteSpace(Style))
            builder.AddAttribute(2, "style", Style);
        var transform = this.ToTransform(null);
        if (!string.IsNullOrWhiteSpace(transform))
            builder.AddAttribute(3, "data-fa-transform", transform);
        builder.AddMultipleAttributes(4, AdditionalAttributes);
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (ChildContent != default)
            builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
