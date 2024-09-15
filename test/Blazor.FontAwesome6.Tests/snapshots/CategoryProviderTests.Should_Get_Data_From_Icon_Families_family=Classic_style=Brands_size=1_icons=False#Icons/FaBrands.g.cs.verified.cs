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
    private static Icon? f__500px;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/500px?f=classic&amp;s=brands">500px</a>
    /// </summary>
    public static Icon _500px => f__500px ??= new Icon(IconFamily.Classic, IconStyle.Brands, "500px", "[unicode]");
    private static Icon? f_Accusoft;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/accusoft?f=classic&amp;s=brands">Accusoft</a>
    /// </summary>
    public static Icon Accusoft => f_Accusoft ??= new Icon(IconFamily.Classic, IconStyle.Brands, "accusoft", "[unicode]");
}