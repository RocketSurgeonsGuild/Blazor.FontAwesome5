using System.Runtime.CompilerServices;
using Bogus;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit.Abstractions;
using FaSolid = Rocket.Surgery.Blazor.FontAwesome6.Free.FaSolid;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class IconTests : LoggerTest
{
    [Fact]
    public void Should_Support_Implicit_Conversion_From_Known_Enum()
    {
        var icon = FaRegular.Adjust;
        icon.Style.Should().Be(IconStyle.Regular);
        icon.Name.Should().Be("circle-half-stroke");
    }

    [Fact]
    public void Should_Render_An_Icon()
    {
        var icon = FaRegular.Adjust;
        icon.ToIcon().Should().Be("<i class=\"fa-regular fa-circle-half-stroke\"></i>");
    }

    [Fact]
    public void Should_Render_A_Transformed_Icon()
    {
        var icon = FaRegular.Adjust;
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
           .ToIcon()
           .Should()
           .Be(
                "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"grow-3.00 shrink-2.00 rotate--40.00 up-12.00 down-4.00 left-2.00 right-1.00\"></i>"
            );
    }

    [Fact]
    public void Should_Render_A_FixedWith_Icon()
    {
        var icon = FaRegular.Adjust;
        icon
           .FixedWidth()
           .ToIcon()
           .Should()
           .Be("<i class=\"fa-regular fa-circle-half-stroke fa-fw\"></i>");
    }

    [Fact]
    public void Should_Render_A_Spin_Icon()
    {
        var icon = FaRegular.Adjust;
        icon
           .Spin()
           .ToIcon()
           .Should()
           .Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin\"></i>");
    }

    [Fact]
    public void Should_Render_A_Pulse_Icon()
    {
        var icon = FaRegular.Adjust;
        icon
           .SpinPulse()
           .ToIcon()
           .Should()
           .Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin-pulse\"></i>");
    }

    [Fact]
    public void Should_Render_A_Border_Icon()
    {
        var icon = FaRegular.Adjust;
        icon
           .Border()
           .ToIcon()
           .Should()
           .Be("<i class=\"fa-regular fa-circle-half-stroke fa-border\"></i>");
    }

    [Fact]
    public void Should_Render_A_Inverse_Icon()
    {
        var icon = FaRegular.Adjust;
        icon
           .Inverse()
           .ToIcon()
           .Should()
           .Be("<i class=\"fa-regular fa-circle-half-stroke fa-inverse\"></i>");
    }

    [Fact]
    public void Should_Render_A_Mask_Icon()
    {
        var icon = FaRegular.Adjust;
        icon
           .Mask(FaDuotone.Analytics)
           .ToIcon()
           .Should()
           .Be("<i class=\"fa-regular fa-circle-half-stroke\" data-fa-mask=\"fa-duotone fa-chart-mixed\"></i>");
    }

    public IconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }

    [Theory]
    [InlineData(IconFlip.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconFlip.Horizontal, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h\"></i>")]
    [InlineData(IconFlip.Vertical, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-v\"></i>")]
    [InlineData(IconFlip.Both, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h flip-v\"></i>")]
    public void Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected)
    {
        var icon = FaRegular.Adjust;
        icon
           .FlipIcon(iconFlip)
           .ToIcon()
           .Should()
           .Be(expected);
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
        var icon = FaRegular.Adjust;
        icon
           .Size(iconSize)
           .ToIcon()
           .Should()
           .Be(expected);
    }

    [Theory]
    [InlineData(IconPull.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconPull.Left, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-left\"></i>")]
    [InlineData(IconPull.Right, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-right\"></i>")]
    public void Should_Render_A_Pull_Icon(IconPull iconPull, string expected)
    {
        var icon = FaRegular.Adjust;
        icon
           .Pull(iconPull)
           .ToIcon()
           .Should()
           .Be(expected);
    }

    [Theory]
    [ClassData(typeof(IconAnimationData))]
    [ClassData(typeof(IconBorderAndPullData))]
    [ClassData(typeof(IconTransformData))]
    public Task IconValidations(string id, Icon icon)
    {
        return Verify(icon.ToIcon()).UseHashedParameters(id);
    }

    private class IconTransformData : IconTheory
    {
        public IconTransformData()
        {
            foreach (var size in Enum.GetValues<IconSize>().Distinct())
            {
                AddIcon(FaSolid.Chain.Size(size), size);
            }

            AddIcon(FaRegular.Chain.FixedWidth());
            AddIcon(FaRegular.Chain.FixedWidth(false));
            AddIcon(
                FaSolid
                   .Barcode
                   .Grow(2)
                   .Shrink(3)
                   .Up(4)
                   .Left(5)
                   .Down(6)
                   .Right(7)
                   .Rotate(8)
            );
            AddIcon(FaSolid.Barcode.RotateLeft(100));
            AddIcon(FaSolid.Barcode.RotateRight(100));
            AddIcon(FaSolid.Barcode.RotateBy("100deg"));
            AddIcon(FaSolid.Barcode.FlipIcon());
            AddIcon(FaSolid.Barcode.FlipIcon(IconFlip.Vertical));
            AddIcon(FaSolid.Barcode.FlipIcon(IconFlip.Horizontal));
            AddIcon(FaSolid.Barcode.FlipIcon(IconFlip.Both));
        }
    }

    private class IconBorderAndPullData : IconTheory
    {
        public IconBorderAndPullData()
        {
            AddIcon(
                FaSolid.Bank
                       .Border(
                            true,
                            "#FF0000",
                            "6px",
                            "8px",
                            "solid",
                            "100px"
                        )
            );
            foreach (var item in Enum.GetValues<IconPull>())
            {
                AddIcon(FaSolid.Bank.Pull(item, "20px"), item);
            }

            AddIcon(FaSolid.Bank.Pull(IconPull.Right).PullMargin("10px"));
            AddIcon(FaSolid.Bank.PullRight());
            AddIcon(FaSolid.Bank.PullLeft());
        }
    }

    private class IconTheory : TheoryData<string, Icon>
    {
        protected void AddIcon(Icon icon, [CallerArgumentExpression(nameof(icon))] string? caller = null)
        {
            Add(string.Join("", caller.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(z => z.Trim())), icon);
        }

        protected void AddIcon(Icon icon, object variation, [CallerArgumentExpression(nameof(icon))] string? caller = null)
        {
            Add(variation + " @ " + string.Join("", caller.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(z => z.Trim())), icon);
        }
    }

    private class IconAnimationData : IconTheory
    {
        public IconAnimationData()
        {
            foreach (var item in Enum.GetValues<IconAnimation>().Concat(Enum.GetValues<IconAnimation>().Select(i => i | IconAnimation.Reverse)).Distinct())
            {
                AddIcon(
                    FaSolid.Battery
                           .Animate(
                                item,
                                "3s",
                                "alternate-reverse",
                                "4s",
                                "5s",
                                "ease-in-out"
                            ),
                    item
                );
            }

            AddIcon(
                FaSolid
                   .Battery
                   .Animate(IconAnimation.Beat)
                   .AnimationDirection("alternate-reverse")
            );
            AddIcon(
                FaSolid
                   .Battery
                   .Animate(IconAnimation.Beat)
                   .AnimationDuration("2s")
            );
            AddIcon(
                FaSolid
                   .Battery
                   .Animate(IconAnimation.Beat)
                   .AnimationTiming("ease-in-out")
            );
            AddIcon(
                FaSolid
                   .Battery
                   .Animate(IconAnimation.Beat)
                   .AnimationDelay( "3s")
            );
            AddIcon(
                FaSolid
                   .Battery
                   .Animate(IconAnimation.Beat)
                   .AnimationIterationCount("4s")
            );

            AddIcon(
                FaSolid.Bank
                       .Bounce(
                            1,
                            2,
                            3,
                            4,
                            5,
                            6,
                            7,
                            8,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .Beat(
                            4,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .Fade(
                            4,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .BeatFade(
                            4,
                            5,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .Flip(
                            1,
                            2,
                            3,
                            "10deg",
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .Shake(
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .Spin(
                            true,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .Spin(
                            false,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .SpinPulse(
                            true,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );

            AddIcon(
                FaSolid.Bank
                       .SpinPulse(
                            false,
                            "9s",
                            "alternate-reverse",
                            "10s",
                            "11",
                            "ease-in-out"
                        )
            );
        }
    }
}
