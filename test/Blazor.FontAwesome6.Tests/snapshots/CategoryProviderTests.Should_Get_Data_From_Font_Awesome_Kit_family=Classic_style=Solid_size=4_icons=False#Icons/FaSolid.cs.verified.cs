using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Solid Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSolid
{
    private static Icon? f_AlbumCollectionCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=solid">Album Collection Circle Plus</a>
    /// </summary>
    public static Icon AlbumCollectionCirclePlus => f_AlbumCollectionCirclePlus ??= new Icon(IconFamily.Classic, IconStyle.Solid, "album-collection-circle-plus", "[unicode]");
    private static Icon? f_AlbumCollectionCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=solid">Album Collection Circle User</a>
    /// </summary>
    public static Icon AlbumCollectionCircleUser => f_AlbumCollectionCircleUser ??= new Icon(IconFamily.Classic, IconStyle.Solid, "album-collection-circle-user", "[unicode]");
}