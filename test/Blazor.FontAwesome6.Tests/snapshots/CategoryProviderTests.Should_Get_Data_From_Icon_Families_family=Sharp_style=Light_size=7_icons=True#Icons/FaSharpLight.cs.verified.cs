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
    private static SvgIcon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Down Left And Up Right To Center</a>
    /// </summary>
    public static SvgIcon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new SvgIcon(IconFamily.Sharp, IconStyle.Light, "down-left-and-up-right-to-center", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Down Left And Up Right To Center</a>
    /// </summary>
    public static SvgIcon CompressAlt => global::Someplace.FaSharpLight.DownLeftAndUpRightToCenter;
    private static SvgIcon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Up Right And Down Left From Center</a>
    /// </summary>
    public static SvgIcon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new SvgIcon(IconFamily.Sharp, IconStyle.Light, "up-right-and-down-left-from-center", "[unicode]", 512, 512, "[path]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Up Right And Down Left From Center</a>
    /// </summary>
    public static SvgIcon ExpandAlt => global::Someplace.FaSharpLight.UpRightAndDownLeftFromCenter;
}