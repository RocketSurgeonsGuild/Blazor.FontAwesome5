using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome5;

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

            if (_icon._spin)
            {
                Spin = _icon._spin;
            }

            if (_icon._pulse)
            {
                Pulse = _icon._pulse;
            }

            if (_icon._pull != IconPull.None)
            {
                Pull = _icon._pull;
            }

            if (_icon._border)
            {
                Border = _icon._border;
            }

            if (_icon._inverse)
            {
                Inverse = _icon._inverse;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (_icon._rotate > 0.001 || _icon._rotate < -0.001)
            {
                _rotate = _icon._rotate;
            }

            if (_icon._flip == IconFlip.None)
            {
                Flip = _icon._flip;
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

    [Parameter] public IconSize Size { get; set; }

    [Parameter] public bool FixedWidth { get; set; }

    [Parameter] public IconPull? Pull { get; set; }

    [Parameter] public bool Spin { get; set; }

    [Parameter] public bool Pulse { get; set; }

    [Parameter] public bool Border { get; set; }

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

    [Parameter] public IconFlip? Flip { get; set; }

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

    public string ToStyle()
    {
        var sb = new StringBuilder();
        if (!string.IsNullOrWhiteSpace(Style))
        {
            sb.Append(Style);
        }

        if (_primaryOpacity.HasValue)
        {
            sb.Append(";--fa-primary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", _primaryOpacity);
        }

        if (PrimaryColor != null)
        {
            sb.Append(";--fa-primary-color: ").Append(PrimaryColor);
        }

        if (_secondaryOpacity.HasValue)
        {
            sb.Append(";--fa-secondary-opacity: ").AppendFormat(CultureInfo.InvariantCulture, "{0:F2}", _secondaryOpacity);
        }

        if (SecondaryColor != null)
        {
            sb.Append(";--fa-secondary-color: ").Append(SecondaryColor);
        }

        return sb.ToString();
    }

    double ITransformIcon.Grow => _grow;

    double ITransformIcon.Shrink => _shrink;

    double ITransformIcon.Rotate => _rotate;

    double ITransformIcon.Up => _up;

    double ITransformIcon.Down => _down;

    double ITransformIcon.Left => _left;

    double ITransformIcon.Right => _right;

    IconStyle IIcon.Style => _icon.Style;

    string? IIcon.CssStyle => Style;

    string? IIcon.CssClass => Class;

    string IIcon.Name => _icon.Name;

    IconPull IIcon.Pull => Pull ?? IconPull.None;

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        //<i class="@ToClass()" @attributes="GetAttributes()" style="@AllStyle"></i>
        builder.OpenElement(0, "i");

        builder.AddAttribute(1, "class", this.ToClass(Stack != null, Class));
        var style = ToStyle();
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
