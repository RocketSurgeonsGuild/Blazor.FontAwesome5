using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome5;

#pragma warning disable CA1711
public class FaStack : ComponentBase
#pragma warning restore CA1711
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public IconSize Size { get; set; }

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }

    public string ToClass()
    {
        var sb = new StringBuilder();
        sb.Append("fa-stack");

        if (!string.IsNullOrWhiteSpace(Class))
        {
            sb.Append(' ');
            sb.Append(Class);
        }

        sb.Append(Icon.ToString(Size, false));
        return sb.ToString();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // <CascadingValue Value = "true" Name="IsInStack">
        //     <span class="@ToClass()" style="@Style">@ChildContent</span>
        // </CascadingValue>
        builder.OpenComponent<CascadingValue<FaStack>>(0);
        builder.AddAttribute(1, nameof(CascadingValue<FaStack>.Value), this);
        builder.AddAttribute(
            2,
            nameof(CascadingValue<FaStack>.ChildContent),
            (RenderFragment)( b =>
            {
                b.OpenElement(0, "span");
                b.AddAttribute(1, "class", ToClass());

                if (!string.IsNullOrWhiteSpace(Style))
                {
                    b.AddAttribute(2, "style", Style);
                }

                if (ChildContent != null)
                {
                    b.AddContent(3, ChildContent);
                }

                b.CloseElement();
            } )
        );
        builder.CloseComponent();
    }
}
