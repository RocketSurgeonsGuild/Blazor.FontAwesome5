﻿#nullable enable
using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Regular Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaRegular
{
    private static SvgIcon? f_AlbumCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-circle-plus?f=classic&amp;s=regular">Album Circle Plus</a>
    /// </summary>
    public static SvgIcon AlbumCirclePlus => f_AlbumCirclePlus ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "album-circle-plus", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_AlbumCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-circle-user?f=classic&amp;s=regular">Album Circle User</a>
    /// </summary>
    public static SvgIcon AlbumCircleUser => f_AlbumCircleUser ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "album-circle-user", "[unicode]", 576, 512, "[path]");
}