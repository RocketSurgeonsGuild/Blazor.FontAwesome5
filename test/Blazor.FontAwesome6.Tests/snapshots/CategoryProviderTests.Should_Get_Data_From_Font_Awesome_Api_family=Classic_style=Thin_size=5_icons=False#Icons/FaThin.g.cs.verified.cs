#nullable enable
using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Thin Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaThin
{
    private static Icon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-from-dotted-line?f=classic&amp;s=thin">Arrow Down From Dotted Line</a>
    /// </summary>
    public static Icon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new Icon(IconFamily.Classic, IconStyle.Thin, "arrow-down-from-dotted-line", "[unicode]");
    private static Icon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-to-dotted-line?f=classic&amp;s=thin">Arrow Down To Dotted Line</a>
    /// </summary>
    public static Icon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new Icon(IconFamily.Classic, IconStyle.Thin, "arrow-down-to-dotted-line", "[unicode]");
}