﻿#nullable enable
using System;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Solid Icons
/// </summary>
[ExcludeFromCodeCoverage, CompilerGenerated, GeneratedCode("Rocket.Surgery.Blazor.FontAwesome6", "")]
public static partial class FaSolid
{
    private static Icon? f_AlbumCollectionCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-collection-circle-plus?f=classic&amp;s=solid">Album Collection Circle Plus</a>
    /// </summary>
    public static Icon AlbumCollectionCirclePlus => f_AlbumCollectionCirclePlus ??= new Icon(IconFamily.Classic, IconStyle.Solid, "album-collection-circle-plus", "[unicode]");
    private static Icon? f_AlbumCollectionCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/album-collection-circle-user?f=classic&amp;s=solid">Album Collection Circle User</a>
    /// </summary>
    public static Icon AlbumCollectionCircleUser => f_AlbumCollectionCircleUser ??= new Icon(IconFamily.Classic, IconStyle.Solid, "album-collection-circle-user", "[unicode]");
}