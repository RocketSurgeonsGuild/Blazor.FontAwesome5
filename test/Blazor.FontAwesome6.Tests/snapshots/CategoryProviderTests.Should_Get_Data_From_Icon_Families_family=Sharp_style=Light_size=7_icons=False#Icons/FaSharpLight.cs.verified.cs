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
    private static Icon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new Icon(IconFamily.Sharp, IconStyle.Light, "down-left-and-up-right-to-center", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon CompressAlt => global::Someplace.FaSharpLight.DownLeftAndUpRightToCenter;
    private static Icon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new Icon(IconFamily.Sharp, IconStyle.Light, "up-right-and-down-left-from-center", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon ExpandAlt => global::Someplace.FaSharpLight.UpRightAndDownLeftFromCenter;
}