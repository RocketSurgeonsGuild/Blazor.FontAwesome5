﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Rocket.Surgery.Blazor.FontAwesome6;

public class FaLayer : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public bool FixedWidth { get; set; } = true;

    [Parameter] public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
#pragma warning disable CA2227
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new();
#pragma warning restore CA2227

    public string ToClass()
    {
        var values = new List<string>
        {
            "fa-layers"
        };

        if (!string.IsNullOrWhiteSpace(Class))
        {
            values.Add(Class);
        }

        if (FixedWidth)
            values.Add("fa-fw");

        return string.Join(" ", values);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // <span class="@ToClass()" style="@Style">@ChildContent</span>
        builder.OpenElement(0, "span");
        builder.AddAttribute(1, "class", ToClass());
        if (!string.IsNullOrWhiteSpace(Style))
            builder.AddAttribute(2, "style", Style);
        builder.AddMultipleAttributes(3, AdditionalAttributes);
        if (ChildContent != null)
            builder.AddContent(4, ChildContent);
        builder.CloseElement();
    }
}
