#nullable enable
using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp light Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaSharpLight
{
    private static SvgIcon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-from-dotted-line?f=sharp&amp;s=light">Arrow Down From Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new SvgIcon(IconFamily.Sharp, IconStyle.Light, "arrow-down-from-dotted-line", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/arrow-down-to-dotted-line?f=sharp&amp;s=light">Arrow Down To Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new SvgIcon(IconFamily.Sharp, IconStyle.Light, "arrow-down-to-dotted-line", "[unicode]", 448, 512, "[path]");
}