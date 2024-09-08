using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Light Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaLight
{
    private static Icon? f_HouseFloodWaterCircleArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">House Flood Water Circle Arrow Right</a>
    /// </summary>
    public static Icon HouseFloodWaterCircleArrowRight => f_HouseFloodWaterCircleArrowRight ??= new Icon(IconFamily.Classic, IconStyle.Light, "house-flood-water-circle-arrow-right", "[unicode]");
    private static Icon? f_PersonWalkingDashedLineArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=classic&s=light">Person Walking Dashed Line Arrow Right</a>
    /// </summary>
    public static Icon PersonWalkingDashedLineArrowRight => f_PersonWalkingDashedLineArrowRight ??= new Icon(IconFamily.Classic, IconStyle.Light, "person-walking-dashed-line-arrow-right", "[unicode]");
}