using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rocket.Surgery.Blazor.FontAwesome5;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public class FaText : ComponentBase, ITransformIcon
{
    [Parameter] public RenderFragment ChildContent { get; set; } = null!;

    [Parameter] public bool Spin { get; set; }

    [Parameter] public bool Pulse { get; set; }

    [Parameter] public bool Inverse { get; set; }

    private double _grow;

    [Parameter]
    public string Grow
    {
        get => _grow.ToString("F2", CultureInfo.InvariantCulture);
        set => _grow = double.Parse(value, CultureInfo.InvariantCulture);
    }

    private double _shrink;

    [Parameter]
    public string Shrink
    {
        get => _shrink.ToString("F2", CultureInfo.InvariantCulture);
        set => _shrink = double.Parse(value, CultureInfo.InvariantCulture);
    }

    private double _up;

    [Parameter]
    public string Up
    {
        get => _up.ToString("F2", CultureInfo.InvariantCulture);
        set => _up = double.Parse(value, CultureInfo.InvariantCulture);
    }

    private double _down;

    [Parameter]
    public string Down
    {
        get => _down.ToString("F2", CultureInfo.InvariantCulture);
        set => _down = double.Parse(value, CultureInfo.InvariantCulture);
    }

    private double _left;

    [Parameter]
    public string Left
    {
        get => _left.ToString("F2", CultureInfo.InvariantCulture);
        set => _left = double.Parse(value, CultureInfo.InvariantCulture);
    }

    private double _right;

    [Parameter]
    public string Right
    {
        get => _right.ToString("F2", CultureInfo.InvariantCulture);
        set => _right = double.Parse(value, CultureInfo.InvariantCulture);
    }

    private double _rotate;

    [Parameter]
    public string Rotate
    {
        get => _rotate.ToString("F2", CultureInfo.InvariantCulture);
        set => _rotate = double.Parse(value, CultureInfo.InvariantCulture);
    }

    [Parameter] public IconFlip? FlipTransform { get; set; }

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
        var transform = this.ToTransform();
        if (!string.IsNullOrWhiteSpace(transform))
            builder.AddAttribute(3, "data-fa-transform", transform);
        builder.AddMultipleAttributes(4, AdditionalAttributes);
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (ChildContent != default)
            builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
