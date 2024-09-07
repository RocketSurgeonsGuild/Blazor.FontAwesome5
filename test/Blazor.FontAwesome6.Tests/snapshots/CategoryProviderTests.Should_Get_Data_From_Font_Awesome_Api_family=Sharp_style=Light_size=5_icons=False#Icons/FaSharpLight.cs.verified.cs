using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp light Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpLight
{
    private static Icon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Arrow Down From Dotted Line</a>
    /// </summary>
    public static Icon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new Icon(IconFamily.Sharp, IconStyle.Light, "arrow-down-from-dotted-line", "[unicode]");
    private static Icon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Arrow Down To Dotted Line</a>
    /// </summary>
    public static Icon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new Icon(IconFamily.Sharp, IconStyle.Light, "arrow-down-to-dotted-line", "[unicode]");
}