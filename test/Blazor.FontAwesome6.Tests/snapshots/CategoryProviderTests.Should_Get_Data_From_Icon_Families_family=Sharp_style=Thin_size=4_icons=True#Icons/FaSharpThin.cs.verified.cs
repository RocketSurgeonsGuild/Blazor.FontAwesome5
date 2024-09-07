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
    private static SvgIcon? f_AlbumCollectionCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Album Collection Circle Plus</a>
    /// </summary>
    public static SvgIcon AlbumCollectionCirclePlus => f_AlbumCollectionCirclePlus ??= new SvgIcon(IconFamily.Sharp, IconStyle.Thin, "album-collection-circle-plus", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_AlbumCollectionCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Album Collection Circle User</a>
    /// </summary>
    public static SvgIcon AlbumCollectionCircleUser => f_AlbumCollectionCircleUser ??= new SvgIcon(IconFamily.Sharp, IconStyle.Thin, "album-collection-circle-user", "[unicode]", 640, 512, "[path]");
}