#nullable enable
using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Duotone regular Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaDuotoneRegular
{
    private static SvgIcon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-from-dotted-line?f=duotone&amp;s=regular">Arrow Down From Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new SvgIcon(IconFamily.Duotone, IconStyle.Regular, "arrow-down-from-dotted-line", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-to-dotted-line?f=duotone&amp;s=regular">Arrow Down To Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new SvgIcon(IconFamily.Duotone, IconStyle.Regular, "arrow-down-to-dotted-line", "[unicode]", 448, 512, "[path]");
}