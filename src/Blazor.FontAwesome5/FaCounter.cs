using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome5;

public class FaCounter : ComponentBase, ITransformIcon
{
    private double _grow;
    private double _shrink;
    private double _up;
    private double _down;
    private double _left;
    private double _right;
    private double _rotate;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public bool Spin { get; set; }

    [Parameter] public bool Pulse { get; set; }

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

    [Parameter] public IconFlip? Flip { get; set; }

    [Parameter] public IconCounterPosition? Position { get; set; }

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

    private string ToClass()
    {
        var values = new List<string>
        {
            "fa-layers-counter"
        };

        if (!string.IsNullOrWhiteSpace(Class))
        {
            values.Add(Class);
        }

        if (Position.HasValue)
        {
            values.Add(
                Position.Value switch
                {
                    IconCounterPosition.TopRight => "fa-layers-top-right",
                    IconCounterPosition.TopLeft => "fa-layers-top-left",
                    IconCounterPosition.BottomRight => "fa-layers-bottom-right",
                    IconCounterPosition.BottomLeft => "fa-layers-bottom-left",
                    _ => throw new NotSupportedException()
                }
            );
        }

        if (Inverse)
            values.Add("fa-inverse");
        if (Spin)
            values.Add("fa-spinner");
        else if (Pulse)
            values.Add("fa-pulse");

        return string.Join(" ", values);
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
        if (ChildContent != null)
            builder.AddContent(5, ChildContent);
        builder.CloseElement();
    }
}
