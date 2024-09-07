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
    private static Icon? f_CreativeCommonsNcEu;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">Creative Commons Noncommercial (Euro Sign)</a>
    /// </summary>
    public static Icon CreativeCommonsNcEu => f_CreativeCommonsNcEu ??= new Icon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-eu", "[unicode]");
    private static Icon? f_CreativeCommonsNcJp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">Creative Commons Noncommercial (Yen Sign)</a>
    /// </summary>
    public static Icon CreativeCommonsNcJp => f_CreativeCommonsNcJp ??= new Icon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-jp", "[unicode]");
}