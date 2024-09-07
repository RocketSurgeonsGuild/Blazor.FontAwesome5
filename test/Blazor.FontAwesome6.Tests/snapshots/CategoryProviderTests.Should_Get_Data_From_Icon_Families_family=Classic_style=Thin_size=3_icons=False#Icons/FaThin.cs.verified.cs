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
    private static Icon? f_AlbumCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=thin">Album Circle Plus</a>
    /// </summary>
    public static Icon AlbumCirclePlus => f_AlbumCirclePlus ??= new Icon(IconFamily.Classic, IconStyle.Thin, "album-circle-plus", "[unicode]");
    private static Icon? f_AlbumCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=thin">Album Circle User</a>
    /// </summary>
    public static Icon AlbumCircleUser => f_AlbumCircleUser ??= new Icon(IconFamily.Classic, IconStyle.Thin, "album-circle-user", "[unicode]");
}