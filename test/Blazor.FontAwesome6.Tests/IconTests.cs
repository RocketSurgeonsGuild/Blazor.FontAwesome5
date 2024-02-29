﻿using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests
{
    public class IconTests : LoggerTest
    {
        public IconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information)
        {
        }

        [Fact]
        public void Should_Support_Implicit_Conversion_From_Known_Enum()
        {
            Icon icon = FaRegular.Adjust;
            icon.Style.Should().Be(IconStyle.Regular);
            icon.Name.Should().Be("circle-half-stroke");
        }

        [Fact]
        public void Should_Render_An_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon.ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke\"></i>");
        }

        [Fact]
        public void Should_Render_A_Transformed_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Left(2)
               .RotateLeft(120)
               .RotateRight(80)
               .Down(4)
               .Left(2)
               .Right(1)
               .Up(12)
               .Shrink(2)
               .Grow(3)
               .ToIcon().Should().Be(
                    "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"grow-3.00 shrink-2.00 rotate-200.00 up-12.00 down-4.00 left-2.00 right-1.00\"></i>"
                );
        }

        [Theory]
        [InlineData(IconFlip.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
        [InlineData(IconFlip.Horizontal, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h\"></i>")]
        [InlineData(IconFlip.Vertical, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-v\"></i>")]
        [InlineData(IconFlip.Both, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h flip-v\"></i>")]
        public void Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected)
        {
            Icon icon = FaRegular.Adjust;
            icon
               .FlipIcon(iconFlip)
               .ToIcon().Should().Be(expected);
        }

        [Theory]
        [InlineData(IconSize.ExtraSmall, "<i class=\"fa-regular fa-circle-half-stroke fa-xs\"></i>")]
        [InlineData(IconSize.Small, "<i class=\"fa-regular fa-circle-half-stroke fa-sm\"></i>")]
        [InlineData(IconSize.Normal, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
        [InlineData(IconSize.Large, "<i class=\"fa-regular fa-circle-half-stroke fa-lg\"></i>")]
        [InlineData(IconSize._2X, "<i class=\"fa-regular fa-circle-half-stroke fa-2x\"></i>")]
        [InlineData(IconSize._5X, "<i class=\"fa-regular fa-circle-half-stroke fa-5x\"></i>")]
        [InlineData(IconSize._10X, "<i class=\"fa-regular fa-circle-half-stroke fa-10x\"></i>")]
        public void Should_Render_A_Size_Icon(IconSize iconSize, string expected)
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Size(iconSize)
               .ToIcon().Should().Be(expected);
        }

        [Fact]
        public void Should_Render_A_FixedWith_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .FixedWidth()
               .ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-fw\"></i>");
        }

        [Fact]
        public void Should_Render_A_Spin_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Spin()
               .ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin\"></i>");
        }

        [Fact]
        public void Should_Render_A_Pulse_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .SpinPulse()
               .ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin-pulse\"></i>");
        }

        [Fact]
        public void Should_Render_A_Border_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Border()
               .ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-border\"></i>");
        }

        [Fact]
        public void Should_Render_A_Inverse_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Inverse()
               .ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-inverse\"></i>");
        }

        [Fact]
        public void Should_Render_A_Mask_Icon()
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Mask(FaDuotone.Analytics)
               .ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke\" data-fa-mask=\"fa-duotone fa-chart-mixed\"></i>");
        }

        [Theory]
        [InlineData(IconPull.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
        [InlineData(IconPull.Left, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-left\"></i>")]
        [InlineData(IconPull.Right, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-right\"></i>")]
        public void Should_Render_A_Pull_Icon(IconPull iconPull, string expected)
        {
            Icon icon = FaRegular.Adjust;
            icon
               .Pull(iconPull)
               .ToIcon().Should().Be(expected);
        }
    }
}
