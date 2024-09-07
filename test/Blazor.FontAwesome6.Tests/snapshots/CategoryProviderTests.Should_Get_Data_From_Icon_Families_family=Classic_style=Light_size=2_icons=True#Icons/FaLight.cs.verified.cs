using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Light Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaLight
{
    private static SvgIcon? f__360Degrees;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">360 Degrees</a>
    /// </summary>
    public static SvgIcon _360Degrees => f__360Degrees ??= new SvgIcon(IconFamily.Classic, IconStyle.Light, "360-degrees", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_AccentGrave;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">Accent Grave</a>
    /// </summary>
    public static SvgIcon AccentGrave => f_AccentGrave ??= new SvgIcon(IconFamily.Classic, IconStyle.Light, "accent-grave", "[unicode]", 192, 512, "[path]");
}