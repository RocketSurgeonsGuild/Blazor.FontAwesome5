#nullable enable
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
    private static Icon? f_CreativeCommonsNcEu;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/creative-commons-nc-eu?f=classic&amp;s=brands">Creative Commons Noncommercial (Euro Sign)</a>
    /// </summary>
    public static Icon CreativeCommonsNcEu => f_CreativeCommonsNcEu ??= new Icon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-eu", "[unicode]");
    private static Icon? f_CreativeCommonsNcJp;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/creative-commons-nc-jp?f=classic&amp;s=brands">Creative Commons Noncommercial (Yen Sign)</a>
    /// </summary>
    public static Icon CreativeCommonsNcJp => f_CreativeCommonsNcJp ??= new Icon(IconFamily.Classic, IconStyle.Brands, "creative-commons-nc-jp", "[unicode]");
}