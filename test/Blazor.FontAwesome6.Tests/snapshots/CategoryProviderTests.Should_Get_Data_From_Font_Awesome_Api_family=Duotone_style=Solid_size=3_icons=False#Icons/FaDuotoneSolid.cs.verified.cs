using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Duotone solid Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaDuotoneSolid
{
    private static Icon? f_AlbumCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=duotone&s=solid">Album Circle Plus</a>
    /// </summary>
    public static Icon AlbumCirclePlus => f_AlbumCirclePlus ??= new Icon(IconFamily.Duotone, IconStyle.Solid, "album-circle-plus", "[unicode]");
    private static Icon? f_AlbumCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=duotone&s=solid">Album Circle User</a>
    /// </summary>
    public static Icon AlbumCircleUser => f_AlbumCircleUser ??= new Icon(IconFamily.Duotone, IconStyle.Solid, "album-circle-user", "[unicode]");
}