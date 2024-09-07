using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Brands Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaBrands
{
    private static SvgIcon? f_CreativeCommonsNcEu;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">Creative Commons Noncommercial (Euro Sign)</a>
    /// </summary>
    public static SvgIcon CreativeCommonsNcEu => f_CreativeCommonsNcEu ??= new SvgIcon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-eu", "[unicode]", 496, 512, "[path]");
    private static SvgIcon? f_CreativeCommonsNcJp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">Creative Commons Noncommercial (Yen Sign)</a>
    /// </summary>
    public static SvgIcon CreativeCommonsNcJp => f_CreativeCommonsNcJp ??= new SvgIcon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-jp", "[unicode]", 496, 512, "[path]");
}