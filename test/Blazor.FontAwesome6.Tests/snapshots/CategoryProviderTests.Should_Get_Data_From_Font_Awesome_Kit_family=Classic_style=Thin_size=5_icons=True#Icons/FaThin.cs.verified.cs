using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Thin Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaThin
{
    private static SvgIcon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=thin">Arrow Down From Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new SvgIcon(IconFamily.Classic, IconStyle.Thin, "arrow-down-from-dotted-line", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=thin">Arrow Down To Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new SvgIcon(IconFamily.Classic, IconStyle.Thin, "arrow-down-to-dotted-line", "[unicode]", 448, 512, "[path]");
}