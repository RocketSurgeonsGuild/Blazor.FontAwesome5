#nullable enable
using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Duotone light Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaDuotoneLight
{
    private static SvgIcon? f_ArrowDownLeftAndArrowUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-left-and-arrow-up-right-to-center?f=duotone&amp;s=light">Arrow Down Left And Arrow Up Right To Center</a>
    /// </summary>
    public static SvgIcon ArrowDownLeftAndArrowUpRightToCenter => f_ArrowDownLeftAndArrowUpRightToCenter ??= new SvgIcon(IconFamily.Duotone, IconStyle.Light, "arrow-down-left-and-arrow-up-right-to-center", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_ArrowUpRightAndArrowDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-up-right-and-arrow-down-left-from-center?f=duotone&amp;s=light">Arrow Up Right And Arrow Down Left From Center</a>
    /// </summary>
    public static SvgIcon ArrowUpRightAndArrowDownLeftFromCenter => f_ArrowUpRightAndArrowDownLeftFromCenter ??= new SvgIcon(IconFamily.Duotone, IconStyle.Light, "arrow-up-right-and-arrow-down-left-from-center", "[unicode]", 512, 512, "[path]");
}