using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rocket.Surgery.Blazor.FontAwesome5.Shared;

namespace Rocket.Surgery.Blazor.FontAwesome5
{
    public class FaStack : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public IconSize Size { get; set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        public string ToClass()
        {
            var values = new List<string>()
            {
                "fa-stack"
            };

            if (!string.IsNullOrWhiteSpace(Class))
            {
                values.Add(Class);
            }

            values.Add(Icon.ToString(Size));

            return string.Join(" ", values);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            // <CascadingValue Value = "true" Name="IsInStack">
            //     <span class="@ToClass()" style="@Style">@ChildContent</span>
            // </CascadingValue>
            builder.OpenComponent<CascadingValue<bool>>(0);
            builder.AddAttribute(1, nameof(CascadingValue<bool>.Value), true);
            builder.AddAttribute(2, nameof(CascadingValue<bool>.Name), nameof(FaIcon.IsInStack));
            builder.AddContent(3, (b) =>
            {
                b.OpenElement(0, "span");
                b.AddAttribute(1, "class", ToClass());
                b.AddAttribute(2, "style", Style);
                b.AddContent(3, ChildContent);
                b.CloseElement();
            });
            builder.CloseComponent();
        }
    }
}