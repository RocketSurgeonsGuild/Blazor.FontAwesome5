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
    private static SvgIcon? f__360Degrees;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">360 Degrees</a>
    /// </summary>
    public static SvgIcon _360Degrees => f__360Degrees ??= new SvgIcon(IconFamily.Sharp, IconStyle.Light, "360-degrees", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_AccentGrave;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Accent Grave</a>
    /// </summary>
    public static SvgIcon AccentGrave => f_AccentGrave ??= new SvgIcon(IconFamily.Sharp, IconStyle.Light, "accent-grave", "[unicode]", 192, 512, "[path]");
}