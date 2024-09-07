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
    private static Icon? f_AlbumCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Album Circle Plus</a>
    /// </summary>
    public static Icon AlbumCirclePlus => f_AlbumCirclePlus ??= new Icon(IconFamily.Sharp, IconStyle.Light, "album-circle-plus", "[unicode]");
    private static Icon? f_AlbumCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=light">Album Circle User</a>
    /// </summary>
    public static Icon AlbumCircleUser => f_AlbumCircleUser ??= new Icon(IconFamily.Sharp, IconStyle.Light, "album-circle-user", "[unicode]");
}