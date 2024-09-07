using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Regular Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaRegular
{
    private static Icon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=regular">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new Icon(IconFamily.Classic, IconStyle.Regular, "down-left-and-up-right-to-center", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=regular">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon CompressAlt => global::Someplace.FaRegular.DownLeftAndUpRightToCenter;
    private static Icon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=regular">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new Icon(IconFamily.Classic, IconStyle.Regular, "up-right-and-down-left-from-center", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=regular">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon ExpandAlt => global::Someplace.FaRegular.UpRightAndDownLeftFromCenter;
}