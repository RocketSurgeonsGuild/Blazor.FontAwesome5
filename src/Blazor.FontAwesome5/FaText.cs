using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome5
{
    public class FaText : ComponentBase, ITransformIcon
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Spin { get; set; }

        [Parameter]
        public bool Pulse { get; set; }

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
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

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
                sb.Append(" ");
                sb.Append(Class);
            }

            if (Inverse)
                sb.Append(" fa-inverse");
            if (Spin)
                sb.Append(" fa-spinner");
            else if (Pulse)
                sb.Append(" fa-pulse");

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
            if (ChildContent != null)
                builder.AddContent(5, ChildContent);
            builder.CloseElement();
        }
    }
}