using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Rocket.Surgery.Blazor.FontAwesome5;

namespace Rocket.Surgery.Blazor.FontAwesome6;

#pragma warning disable CA1711
public class FaStack : ComponentBase
#pragma warning restore CA1711
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public IconSize Size { get; set; }

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }
    [Parameter] public string? StackZIndex { get; set; }
    [Parameter] public string? InverseColor { get; set; }

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

                {
                    var sb = new StringBuilder();

                    if (!string.IsNullOrWhiteSpace(StackZIndex))
                    {
                        sb.Append(";--fa-stack-z-index: ").Append(StackZIndex);
                    }

                    if (!string.IsNullOrWhiteSpace(InverseColor ))
                    {
                        sb.Append(";--fa-inverse: ").Append(InverseColor);
                    }

                    if (!string.IsNullOrWhiteSpace(Style))
                    {
                        sb.Append(sb);
                    }

                    var styleV = sb.ToString();
                    if (!string.IsNullOrWhiteSpace(styleV))
                    {
                        b.AddAttribute(1, "style", styleV);
                    }
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
