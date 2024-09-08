using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Brands Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaBrands
{
    private static SvgIcon? f_CreativeCommonsNcEu;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/creative-commons-nc-eu?f=classic&amp;s=brands">Creative Commons Noncommercial (Euro Sign)</a>
    /// </summary>
    public static SvgIcon CreativeCommonsNcEu => f_CreativeCommonsNcEu ??= new SvgIcon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-eu", "[unicode]", 496, 512, "[path]");
    private static SvgIcon? f_CreativeCommonsNcJp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/creative-commons-nc-jp?f=classic&amp;s=brands">Creative Commons Noncommercial (Yen Sign)</a>
    /// </summary>
    public static SvgIcon CreativeCommonsNcJp => f_CreativeCommonsNcJp ??= new SvgIcon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-jp", "[unicode]", 496, 512, "[path]");
}