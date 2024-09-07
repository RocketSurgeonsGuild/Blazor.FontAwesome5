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
    private static Icon? f_HouseFloodWaterCircleArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">House Flood Water Circle Arrow Right</a>
    /// </summary>
    public static Icon HouseFloodWaterCircleArrowRight => f_HouseFloodWaterCircleArrowRight ??= new Icon(IconFamily.Sharp, IconStyle.Thin, "house-flood-water-circle-arrow-right", "[unicode]");
    private static Icon? f_PersonWalkingDashedLineArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=thin">Person Walking Dashed Line Arrow Right</a>
    /// </summary>
    public static Icon PersonWalkingDashedLineArrowRight => f_PersonWalkingDashedLineArrowRight ??= new Icon(IconFamily.Sharp, IconStyle.Thin, "person-walking-dashed-line-arrow-right", "[unicode]");
}