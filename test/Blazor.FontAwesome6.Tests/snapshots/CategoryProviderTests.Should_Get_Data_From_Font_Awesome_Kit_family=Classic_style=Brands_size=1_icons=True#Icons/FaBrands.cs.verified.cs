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
    private static SvgIcon? f__500px;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">500px</a>
    /// </summary>
    public static SvgIcon _500px => f__500px ??= new SvgIcon(IconFamily.Classic, IconStyle.Brands, "500px", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_Accusoft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=brands">Accusoft</a>
    /// </summary>
    public static SvgIcon Accusoft => f_Accusoft ??= new SvgIcon(IconFamily.Classic, IconStyle.Brands, "accusoft", "[unicode]", 640, 512, "[path]");
}