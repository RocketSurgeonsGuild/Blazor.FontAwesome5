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
    private static Icon? f__360Degrees;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">360 Degrees</a>
    /// </summary>
    public static Icon _360Degrees => f__360Degrees ??= new Icon(IconFamily.Classic, IconStyle.Light, "360-degrees", "[unicode]");
    private static Icon? f_AccentGrave;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">Accent Grave</a>
    /// </summary>
    public static Icon AccentGrave => f_AccentGrave ??= new Icon(IconFamily.Classic, IconStyle.Light, "accent-grave", "[unicode]");
}