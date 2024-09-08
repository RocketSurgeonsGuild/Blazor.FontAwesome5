using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp thin Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpThin
{
    private static Icon? f_AlbumCollectionCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Album Collection Circle Plus</a>
    /// </summary>
    public static Icon AlbumCollectionCirclePlus => f_AlbumCollectionCirclePlus ??= new Icon(IconFamily.Sharp, IconStyle.Thin, "album-collection-circle-plus", "[unicode]");
    private static Icon? f_AlbumCollectionCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Album Collection Circle User</a>
    /// </summary>
    public static Icon AlbumCollectionCircleUser => f_AlbumCollectionCircleUser ??= new Icon(IconFamily.Sharp, IconStyle.Thin, "album-collection-circle-user", "[unicode]");
}