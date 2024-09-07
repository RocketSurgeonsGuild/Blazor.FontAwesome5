﻿using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp regular Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpRegular
{
    private static SvgIcon? f_ArrowDownFromDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">Arrow Down From Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownFromDottedLine => f_ArrowDownFromDottedLine ??= new SvgIcon(IconFamily.Sharp, IconStyle.Regular, "arrow-down-from-dotted-line", "[unicode]", 448, 512, "[path]");
    private static SvgIcon? f_ArrowDownToDottedLine;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">Arrow Down To Dotted Line</a>
    /// </summary>
    public static SvgIcon ArrowDownToDottedLine => f_ArrowDownToDottedLine ??= new SvgIcon(IconFamily.Sharp, IconStyle.Regular, "arrow-down-to-dotted-line", "[unicode]", 448, 512, "[path]");
}