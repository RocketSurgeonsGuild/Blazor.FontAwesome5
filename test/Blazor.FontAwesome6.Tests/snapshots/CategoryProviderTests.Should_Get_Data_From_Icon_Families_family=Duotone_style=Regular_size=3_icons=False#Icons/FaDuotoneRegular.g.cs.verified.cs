﻿#nullable enable
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
    private static Icon? f_AlbumCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-circle-plus?f=duotone&amp;s=regular">Album Circle Plus</a>
    /// </summary>
    public static Icon AlbumCirclePlus => f_AlbumCirclePlus ??= new Icon(IconFamily.Duotone, IconStyle.Regular, "album-circle-plus", "[unicode]");
    private static Icon? f_AlbumCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-circle-user?f=duotone&amp;s=regular">Album Circle User</a>
    /// </summary>
    public static Icon AlbumCircleUser => f_AlbumCircleUser ??= new Icon(IconFamily.Duotone, IconStyle.Regular, "album-circle-user", "[unicode]");
}