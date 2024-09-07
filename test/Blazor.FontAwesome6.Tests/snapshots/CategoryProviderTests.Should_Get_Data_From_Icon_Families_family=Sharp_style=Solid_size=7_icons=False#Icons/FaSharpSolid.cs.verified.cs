using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp solid Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpSolid
{
    private static Icon? f_DownLeftAndUpRightToCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=solid">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon DownLeftAndUpRightToCenter => f_DownLeftAndUpRightToCenter ??= new Icon(IconFamily.Sharp, IconStyle.Solid, "down-left-and-up-right-to-center", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=solid">Down Left And Up Right To Center</a>
    /// </summary>
    public static Icon CompressAlt => global::Someplace.FaSharpSolid.DownLeftAndUpRightToCenter;
    private static Icon? f_UpRightAndDownLeftFromCenter;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=solid">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon UpRightAndDownLeftFromCenter => f_UpRightAndDownLeftFromCenter ??= new Icon(IconFamily.Sharp, IconStyle.Solid, "up-right-and-down-left-from-center", "[unicode]");
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=solid">Up Right And Down Left From Center</a>
    /// </summary>
    public static Icon ExpandAlt => global::Someplace.FaSharpSolid.UpRightAndDownLeftFromCenter;
}