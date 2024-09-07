using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Regular Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaRegular
{
    private static SvgIcon? f_AlbumCirclePlus;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=regular">Album Circle Plus</a>
    /// </summary>
    public static SvgIcon AlbumCirclePlus => f_AlbumCirclePlus ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "album-circle-plus", "[unicode]", 576, 512, "[path]");
    private static SvgIcon? f_AlbumCircleUser;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=regular">Album Circle User</a>
    /// </summary>
    public static SvgIcon AlbumCircleUser => f_AlbumCircleUser ??= new SvgIcon(IconFamily.Classic, IconStyle.Regular, "album-circle-user", "[unicode]", 576, 512, "[path]");
}