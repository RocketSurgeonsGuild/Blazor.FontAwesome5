using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp light Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpLight
{
    private static Icon? f_ArrowDownLeftAndArrowUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Arrow Down Left And Arrow Up Right To Center</a>
    /// </summary>
    public static Icon ArrowDownLeftAndArrowUpRightToCenter => f_ArrowDownLeftAndArrowUpRightToCenter ??= new Icon(IconFamily.Sharp, IconStyle.Light, "arrow-down-left-and-arrow-up-right-to-center", "[unicode]");
    private static Icon? f_ArrowUpRightAndArrowDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Arrow Up Right And Arrow Down Left From Center</a>
    /// </summary>
    public static Icon ArrowUpRightAndArrowDownLeftFromCenter => f_ArrowUpRightAndArrowDownLeftFromCenter ??= new Icon(IconFamily.Sharp, IconStyle.Light, "arrow-up-right-and-arrow-down-left-from-center", "[unicode]");
}