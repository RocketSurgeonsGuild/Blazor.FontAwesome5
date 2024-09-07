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
    private static Icon? f__500px;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">500px</a>
    /// </summary>
    public static Icon _500px => f__500px ??= new Icon(IconFamily.Classic, IconStyle.Brands, "500px", "[unicode]");
    private static Icon? f_Accusoft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">Accusoft</a>
    /// </summary>
    public static Icon Accusoft => f_Accusoft ??= new Icon(IconFamily.Classic, IconStyle.Brands, "accusoft", "[unicode]");
}