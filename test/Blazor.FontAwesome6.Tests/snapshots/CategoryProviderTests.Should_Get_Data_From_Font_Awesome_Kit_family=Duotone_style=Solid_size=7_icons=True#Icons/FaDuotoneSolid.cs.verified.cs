using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Duotone solid Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaDuotoneSolid
{
    private static SvgIcon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=duotone&s=solid">Down Left And Up Right To Center</a>
    /// </summary>
    public static SvgIcon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new SvgIcon(IconFamily.Duotone, IconStyle.Solid, "down-left-and-up-right-to-center", "[unicode]", 512, 512, "[path]");
    private static SvgIcon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=duotone&s=solid">Up Right And Down Left From Center</a>
    /// </summary>
    public static SvgIcon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new SvgIcon(IconFamily.Duotone, IconStyle.Solid, "up-right-and-down-left-from-center", "[unicode]", 512, 512, "[path]");
}