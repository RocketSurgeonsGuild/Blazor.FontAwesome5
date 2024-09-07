using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp thin Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpThin
{
    private static Icon? f_ArrowDownLeftAndArrowUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Arrow Down Left And Arrow Up Right To Center</a>
    /// </summary>
    public static Icon ArrowDownLeftAndArrowUpRightToCenter => f_ArrowDownLeftAndArrowUpRightToCenter ??= new Icon(IconFamily.Sharp, IconStyle.Thin, "arrow-down-left-and-arrow-up-right-to-center", "[unicode]");
    private static Icon? f_ArrowUpRightAndArrowDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Arrow Up Right And Arrow Down Left From Center</a>
    /// </summary>
    public static Icon ArrowUpRightAndArrowDownLeftFromCenter => f_ArrowUpRightAndArrowDownLeftFromCenter ??= new Icon(IconFamily.Sharp, IconStyle.Thin, "arrow-up-right-and-arrow-down-left-from-center", "[unicode]");
}