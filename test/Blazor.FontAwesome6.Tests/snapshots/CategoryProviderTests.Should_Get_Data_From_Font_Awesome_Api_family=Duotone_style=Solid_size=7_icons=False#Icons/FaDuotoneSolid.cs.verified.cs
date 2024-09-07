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
    private static Icon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=duotone&s=solid">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new Icon(IconFamily.Duotone, IconStyle.Solid, "down-left-and-up-right-to-center", "[unicode]");
    private static Icon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=duotone&s=solid">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new Icon(IconFamily.Duotone, IconStyle.Solid, "up-right-and-down-left-from-center", "[unicode]");
}