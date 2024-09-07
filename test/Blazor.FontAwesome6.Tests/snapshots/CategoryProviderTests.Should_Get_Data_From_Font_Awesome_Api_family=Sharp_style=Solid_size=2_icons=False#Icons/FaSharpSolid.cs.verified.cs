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
    private static Icon? f__360Degrees;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=solid">360 Degrees</a>
    /// </summary>
    public static Icon _360Degrees => f__360Degrees ??= new Icon(IconFamily.Sharp, IconStyle.Solid, "360-degrees", "[unicode]");
    private static Icon? f_AccentGrave;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=solid">Accent Grave</a>
    /// </summary>
    public static Icon AccentGrave => f_AccentGrave ??= new Icon(IconFamily.Sharp, IconStyle.Solid, "accent-grave", "[unicode]");
}