using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Light Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaLight
{
    private static Icon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">Arrow Down From Dotted Line</a>
    /// </summary>
    public static Icon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new Icon(IconFamily.Classic, IconStyle.Light, "arrow-down-from-dotted-line", "[unicode]");
    private static Icon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">Arrow Down To Dotted Line</a>
    /// </summary>
    public static Icon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new Icon(IconFamily.Classic, IconStyle.Light, "arrow-down-to-dotted-line", "[unicode]");
}