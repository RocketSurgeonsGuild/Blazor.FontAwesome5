﻿#nullable enable
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
    private static SvgIcon? f_AlbumCollectionCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-collection-circle-plus?f=classic&amp;s=thin">Album Collection Circle Plus</a>
    /// </summary>
    public static SvgIcon AlbumCollectionCirclePlus => f_AlbumCollectionCirclePlus ??= new SvgIcon(IconFamily.Classic, IconStyle.Thin, "album-collection-circle-plus", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_AlbumCollectionCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-collection-circle-user?f=classic&amp;s=thin">Album Collection Circle User</a>
    /// </summary>
    public static SvgIcon AlbumCollectionCircleUser => f_AlbumCollectionCircleUser ??= new SvgIcon(IconFamily.Classic, IconStyle.Thin, "album-collection-circle-user", "[unicode]", 640, 512, "[path]");
}