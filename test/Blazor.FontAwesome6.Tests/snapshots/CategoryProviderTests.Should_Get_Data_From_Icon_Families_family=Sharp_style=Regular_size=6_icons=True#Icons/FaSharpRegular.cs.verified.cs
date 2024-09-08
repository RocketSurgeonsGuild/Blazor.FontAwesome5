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
    private static SvgIcon? f_HouseFloodWaterCircleArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">House Flood Water Circle Arrow Right</a>
    /// </summary>
    public static SvgIcon HouseFloodWaterCircleArrowRight => f_HouseFloodWaterCircleArrowRight ??= new SvgIcon(IconFamily.Sharp, IconStyle.Regular, "house-flood-water-circle-arrow-right", "[unicode]", 640, 512, "[path]");
    private static SvgIcon? f_PersonWalkingDashedLineArrowRight;
    /// <summary>
    /// <a href="https://fontawesome.com/icons/user?f=sharp&s=regular">Person Walking Dashed Line Arrow Right</a>
    /// </summary>
    public static SvgIcon PersonWalkingDashedLineArrowRight => f_PersonWalkingDashedLineArrowRight ??= new SvgIcon(IconFamily.Sharp, IconStyle.Regular, "person-walking-dashed-line-arrow-right", "[unicode]", 640, 512, "[path]");
}