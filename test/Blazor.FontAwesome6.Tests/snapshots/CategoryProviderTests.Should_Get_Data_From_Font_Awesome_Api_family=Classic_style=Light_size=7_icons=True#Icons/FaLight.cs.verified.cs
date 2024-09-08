using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Light Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaLight
{
    private static SvgIcon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/down-left-and-up-right-to-center?f=classic&amp;s=light">Down Left And Up Right To Center</a>
    /// </summary>
    public static SvgIcon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new SvgIcon(IconFamily.Classic, IconStyle.Light, "down-left-and-up-right-to-center", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/up-right-and-down-left-from-center?f=classic&amp;s=light">Up Right And Down Left From Center</a>
    /// </summary>
    public static SvgIcon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new SvgIcon(IconFamily.Classic, IconStyle.Light, "up-right-and-down-left-from-center", "[unicode]", 512, 512, "[path]");
}