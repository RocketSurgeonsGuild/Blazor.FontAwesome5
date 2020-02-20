using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rocket.Surgery.Blazor.FontAwesome5.Shared;

namespace Rocket.Surgery.Blazor.FontAwesome5
{
    public class FaIcon : ComponentBase, ITransformIcon
    {
        private Icon _icon;

        [CascadingParameter(Name = "IsInStack")]
        public bool IsInStack { get; set; }

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

                if (Math.Abs(_icon._rotate) < 0.001)
                {
                    _rotate = _icon._rotate;
                }

                if (_icon._flip == IconFlip.None)
                {
                    Flip = _icon._flip;
                }

                if (_icon._scale < -0.001)
                {
                    _shrink = Math.Abs(_icon._scale);
                }
                else if (_icon._scale > 0.001)
                {
                    _grow = Math.Abs(_icon._scale);
                }

                if (_icon._vertical > 0.001)
                {
                    _up = Math.Abs(_icon._vertical);
                }
                else if (_icon._vertical < 0.001)
                {
                    _down = Math.Abs(_icon._vertical);
                }

                if (_icon._horizontal > 0.001)
                {
                    _right = Math.Abs(_icon._horizontal);
                }
                else if (_icon._horizontal < 0.001)
                {
                    _left = Math.Abs(_icon._horizontal);
                }

                if (_icon._mask != null)
                {
                    Mask = _icon._mask;
                }

                if (_icon._mask != null)
                {
                    Class = _icon._cssClass;
                }

                if (_icon._mask != null)
                {
                    Style = _icon._cssStyle;
                }
            }
        }

        [Parameter]
        public IconSize Size { get; set; }

        [Parameter]
        public bool FixedWidth { get; set; }

        [Parameter]
        public IconPull? Pull { get; set; }

        [Parameter]
        public bool Spin { get; set; }

        [Parameter]
        public bool Pulse { get; set; }

        [Parameter]
        public bool Border { get; set; }

        [Parameter]
        public bool Inverse { get; set; }

        private double _grow;

        [Parameter]
        public string Grow
        {
            get => _grow.ToString("F2");
            set => _grow = double.Parse(value);
        }

        private double _shrink;

        [Parameter]
        public string Shrink
        {
            get => _shrink.ToString("F2");
            set => _shrink = double.Parse(value);
        }

        private double _up;

        [Parameter]
        public string Up
        {
            get => _up.ToString("F2");
            set => _up = double.Parse(value);
        }

        private double _down;

        [Parameter]
        public string Down
        {
            get => _down.ToString("F2");
            set => _down = double.Parse(value);
        }

        private double _left;

        [Parameter]
        public string Left
        {
            get => _left.ToString("F2");
            set => _left = double.Parse(value);
        }

        private double _right;

        [Parameter]
        public string Right
        {
            get => _right.ToString("F2");
            set => _right = double.Parse(value);
        }

        private double _rotate;

        [Parameter]
        public string Rotate
        {
            get => _rotate.ToString("F2");
            set => _rotate = double.Parse(value);
        }

        [Parameter]
        public IconFlip? Flip { get; set; }

        [Parameter]
        public Icon? Mask { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter]
        public bool SwapOpacity { get; set; }

        private double? _primaryOpacity;

        [Parameter]
        public string PrimaryOpacity
        {
            get => _primaryOpacity?.ToString("F2");
            set => _primaryOpacity = double.TryParse(value, out var v) ? (double?)v : null;
        }

        private double? _secondaryOpacity;

        [Parameter]
        public string SecondaryOpacity
        {
            get => _secondaryOpacity?.ToString("F2");
            set => _secondaryOpacity = double.TryParse(value, out var v) ? (double?)v : null;
        }

        [Parameter]
        public string PrimaryColor { get; set; }

        [Parameter]
        public string SecondaryColor { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        public string ToStyle()
        {
            var values = new List<string>();
            if (!string.IsNullOrWhiteSpace(Style)) values.Add(Style);

            if (_primaryOpacity.HasValue)
            {
                values.Add($"--fa-primary-opacity: {_primaryOpacity:F2}");
            }

            if (PrimaryColor != null)
            {
                values.Add($"--fa-primary-color: {PrimaryColor}");
            }

            if (_secondaryOpacity.HasValue)
            {
                values.Add($"--fa-secondary-opacity: {_secondaryOpacity:F2}");
            }

            if (SecondaryColor != null)
            {
                values.Add($"--fa-secondary-color: {SecondaryColor}");
            }

            return string.Join(";", values);
        }

        double ITransformIcon.Grow => _grow;

        double ITransformIcon.Shrink => _shrink;

        double ITransformIcon.Rotate => _rotate;

        double ITransformIcon.Up => _up;

        double ITransformIcon.Down => _down;

        double ITransformIcon.Left => _left;

        double ITransformIcon.Right => _right;

        public string ToClass()
        {
            var values = new List<string>()
            {
                Icon.ToPrefix(Icon.Style),
                $"fa-{Icon.Name}",
            };

            if (!string.IsNullOrWhiteSpace(Class))
            {
                values.Add(Class);
            }

            values.Add(Icon.ToString(Size, IsInStack));
            if (FixedWidth) values.Add("fa-fw");
            if (Border) values.Add("fa-border");
            if (Inverse) values.Add("fa-inverse");
            if (SwapOpacity) values.Add("fa-swap-opacity");
            if (Spin) values.Add("fa-spinner");
            else if (Pulse) values.Add("fa-pulse");

            if (Pull.HasValue && Pull != IconPull.None)
            {
                values.Add(Icon.ToString(Pull.Value));
            }

            return string.Join(" ", values);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //<i class="@ToClass()" @attributes="GetAttributes()" style="@AllStyle"></i>
            builder.OpenElement(0, "i");
            builder.AddAttribute(1, "class", ToClass());
            builder.AddAttribute(2, "style", ToStyle());
            builder.AddAttribute(3, "data-fa-transform", this.ToTransform());
            if (Mask != null)
            {
                builder.AddAttribute(4, "data-fa-mask", $"{Icon.ToPrefix(Mask.Style)} fa-{Mask.Name}");
            }
            builder.AddMultipleAttributes(5, AdditionalAttributes);
            builder.CloseElement();
        }
    }
}

