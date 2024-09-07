using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp regular Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpRegular
{
    private static SvgIcon? f_ArrowDownLeftAndArrowUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">Arrow Down Left And Arrow Up Right To Center</a>
    /// </summary>
    public static SvgIcon ArrowDownLeftAndArrowUpRightToCenter => f_ArrowDownLeftAndArrowUpRightToCenter ??= new SvgIcon(IconFamily.Sharp, IconStyle.Regular, "arrow-down-left-and-arrow-up-right-to-center", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ArrowUpRightAndArrowDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">Arrow Up Right And Arrow Down Left From Center</a>
    /// </summary>
    public static SvgIcon ArrowUpRightAndArrowDownLeftFromCenter => f_ArrowUpRightAndArrowDownLeftFromCenter ??= new SvgIcon(IconFamily.Sharp, IconStyle.Regular, "arrow-up-right-and-arrow-down-left-from-center", "[unicode]", 512, 512, "[path]");
}