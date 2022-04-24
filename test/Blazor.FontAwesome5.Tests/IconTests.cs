using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome5.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome5.Tests
{
    public class IconTests : LoggerTest
    {
        public IconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information)
        {
        }

        [Fact]
        public void Should_Support_Implicit_Conversion_From_Known_Enum()
        {
            Icon icon = Far.Adjust;
            icon.Style.Should().Be(IconStyle.Regular);
            icon.Name.Should().Be("adjust");
        }

        [Fact]
        public void Should_Support_Implicit_Conversion_From_Custom_Enum()
        {
            Icon icon = Custom.Name;
            icon.Style.Should().Be(IconStyle.Regular);
            icon.Name.Should().Be("adjust");
        }

        [Fact]
        public void Should_Render_An_Icon()
        {
            Icon icon = Far.Adjust;
            icon.ToIcon().Should().Be("<i class=\"far fa-adjust\"></i>");
        }

        [Fact]
        public void Should_Not_Support_Implicit_Conversion_From_Unknown_Enum()
        {
            Icon icon = InvalidEnum.This;
            icon.Style.Should().Be(IconStyle.Unknown);
            // ReSharper disable once CA1308
            icon.Name.Should().BeEmpty();
        }

        [Fact]
        public void Should_Render_A_Default_Icon()
        {
            Icon icon = InvalidEnum.This;
            icon.ToIcon().Should().Be("<i class=\"fas fa-bomb\"></i>");
        }

        [Fact]
        public void Should_Render_A_Transformed_Icon()
        {
            Icon icon = Far.Adjust;
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
                    "<i class=\"far fa-adjust\" data-fa-transform=\"grow-3.00 shrink-2.00 rotate--40.00 up-12.00 down-4.00 left-2.00 right-1.00\"></i>"
                );
        }

        [Theory]
        [InlineData(IconFlip.None, "<i class=\"far fa-adjust\"></i>")]
        [InlineData(IconFlip.Horizontal, "<i class=\"far fa-adjust\" data-fa-transform=\"flip-h\"></i>")]
        [InlineData(IconFlip.Vertical, "<i class=\"far fa-adjust\" data-fa-transform=\"flip-v\"></i>")]
        [InlineData(IconFlip.Both, "<i class=\"far fa-adjust\" data-fa-transform=\"flip-h flip-v\"></i>")]
        public void Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected)
        {
            Icon icon = Far.Adjust;
            icon
               .Flip(iconFlip)
               .ToIcon().Should().Be(expected);
        }

        [Theory]
        [InlineData(IconSize.ExtraSmall, "<i class=\"far fa-adjust fa-xs\"></i>")]
        [InlineData(IconSize.Small, "<i class=\"far fa-adjust fa-sm\"></i>")]
        [InlineData(IconSize.Normal, "<i class=\"far fa-adjust\"></i>")]
        [InlineData(IconSize.Large, "<i class=\"far fa-adjust fa-lg\"></i>")]
        [InlineData(IconSize._2X, "<i class=\"far fa-adjust fa-2x\"></i>")]
        [InlineData(IconSize._5X, "<i class=\"far fa-adjust fa-5x\"></i>")]
        [InlineData(IconSize._10X, "<i class=\"far fa-adjust fa-10x\"></i>")]
        public void Should_Render_A_Size_Icon(IconSize iconSize, string expected)
        {
            Icon icon = Far.Adjust;
            icon
               .Size(iconSize)
               .ToIcon().Should().Be(expected);
        }

        [Fact]
        public void Should_Render_A_FixedWith_Icon()
        {
            Icon icon = Far.Adjust;
            icon
               .FixedWidth()
               .ToIcon().Should().Be("<i class=\"far fa-adjust fa-fw\"></i>");
        }

        [Fact]
        public void Should_Render_A_Spin_Icon()
        {
            Icon icon = Far.Adjust;
            icon
               .Spin()
               .ToIcon().Should().Be("<i class=\"far fa-adjust fa-spinner\"></i>");
        }

        [Fact]
        public void Should_Render_A_Pulse_Icon()
        {
            Icon icon = Far.Adjust;
            icon
               .Pulse()
               .ToIcon().Should().Be("<i class=\"far fa-adjust fa-pulse\"></i>");
        }

        [Fact]
        public void Should_Render_A_Border_Icon()
        {
            Icon icon = Far.Adjust;
            icon
               .Border()
               .ToIcon().Should().Be("<i class=\"far fa-adjust fa-border\"></i>");
        }

        [Fact]
        public void Should_Render_A_Inverse_Icon()
        {
            Icon icon = Far.Adjust;
            icon
               .Inverse()
               .ToIcon().Should().Be("<i class=\"far fa-adjust fa-inverse\"></i>");
        }

        [Fact]
        public void Should_Render_A_Mask_Icon()
        {
            Icon icon = Far.Adjust;
            icon
               .Mask(Fad.Analytics)
               .ToIcon().Should().Be("<i class=\"far fa-adjust\" data-fa-mask=\"fad fa-analytics\"></i>");
        }

        [Theory]
        [InlineData(IconPull.None, "<i class=\"far fa-adjust\"></i>")]
        [InlineData(IconPull.Left, "<i class=\"far fa-adjust fa-pull-left\"></i>")]
        [InlineData(IconPull.Right, "<i class=\"far fa-adjust fa-pull-right\"></i>")]
        public void Should_Render_A_Pull_Icon(IconPull iconPull, string expected)
        {
            Icon icon = Far.Adjust;
            icon
               .Pull(iconPull)
               .ToIcon().Should().Be(expected);
        }

        private enum InvalidEnum
        {
            This,
            Is,
            Invalid
        }

        private enum Custom
        {
            [FontAwesome(IconStyle.Regular, "adjust")]
            Name
        }
    }
}
