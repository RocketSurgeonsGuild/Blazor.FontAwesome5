using System;
using System.Collections.Immutable;
using Rocket.Surgery.Blazor.FontAwesome6;
namespace Someplace;
/// <summary>
/// Font Awesome Sharp regular Icons
/// </summary>
[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
public static partial class FaSharpRegular
{
    private static Icon? f_HouseFloodWaterCircleArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">House Flood Water Circle Arrow Right</a>
    /// </summary>
    public static Icon HouseFloodWaterCircleArrowRight => f_HouseFloodWaterCircleArrowRight ??= new Icon(IconFamily.Sharp, IconStyle.Regular, "house-flood-water-circle-arrow-right", "[unicode]");
    private static Icon? f_PersonWalkingDashedLineArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">Person Walking Dashed Line Arrow Right</a>
    /// </summary>
    public static Icon PersonWalkingDashedLineArrowRight => f_PersonWalkingDashedLineArrowRight ??= new Icon(IconFamily.Sharp, IconStyle.Regular, "person-walking-dashed-line-arrow-right", "[unicode]");
}