using System.Runtime.CompilerServices;
using Bogus;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Free.Svg;
using Rocket.Surgery.Extensions.Testing;
using Serilog.Events;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class SvgIconTests
    (ITestOutputHelper testOutputHelper) : LoggerTest<XUnitTestContext>(XUnitTestContext.Create(testOutputHelper, LogEventLevel.Information))
{
    [Fact]
    public Task Should_Support_Implicit_Conversion_From_Known_Enum() => Verify(FaSolid.Adjust);

    [Fact]
    public Task Should_Render_An_Icon() => Verify(FaSolid.Adjust.ToIcon());

    [Fact]
    public Task Should_Render_A_Transformed_Icon()
    {
        return Verify(FaSolid.Adjust
                             .Left(2)
                             .RotateLeft(120)
                             .RotateRight(80)
                             .Down(4)
                             .Left(2)
                             .Right(1)
                             .Up(12)
                             .Shrink(2)
                             .Grow(3)
                             .ToIcon());
    }

    [Fact]
    public Task Should_Render_A_FixedWith_Icon() => Verify(FaSolid.Adjust.FixedWidth().ToIcon());

    [Fact]
    public Task Should_Render_A_Spin_Icon() => Verify(FaSolid.Adjust.Spin());

    [Fact]
    public Task Should_Render_A_Pulse_Icon() =>
        Verify(FaSolid.Adjust
                      .SpinPulse()
                      .ToIcon()
        );

    [Fact]
    public Task Should_Render_A_Border_Icon() =>
        Verify(FaSolid.Adjust
                      .Border()
                      .ToIcon()
        );

    [Fact]
    public Task Should_Render_A_Inverse_Icon() =>
        Verify(FaSolid.Adjust
                      .Inverse()
                      .ToIcon()
        );

    [Fact]
    public Task Should_Render_A_Mask_Icon() =>
        Verify(FaSolid.Adjust
                      .Mask(FaBrands.Microsoft)
                      .ToIcon()
        );

    [Theory]
    [InlineData(IconFlip.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconFlip.Horizontal, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h\"></i>")]
    [InlineData(IconFlip.Vertical, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-v\"></i>")]
    [InlineData(IconFlip.Both, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h flip-v\"></i>")]
    public Task Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected) =>
        Verify(FaSolid.Adjust
                      .FlipIcon(iconFlip)
                      .ToIcon()
            )
           .HashParameters().UseParameters(iconFlip, expected);

    [Theory]
    [InlineData(IconSize.ExtraSmall, "<i class=\"fa-regular fa-circle-half-stroke fa-xs\"></i>")]
    [InlineData(IconSize.Small, "<i class=\"fa-regular fa-circle-half-stroke fa-sm\"></i>")]
    [InlineData(IconSize.Normal, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconSize.Large, "<i class=\"fa-regular fa-circle-half-stroke fa-lg\"></i>")]
    [InlineData(IconSize._2X, "<i class=\"fa-regular fa-circle-half-stroke fa-2x\"></i>")]
    [InlineData(IconSize._5X, "<i class=\"fa-regular fa-circle-half-stroke fa-5x\"></i>")]
    [InlineData(IconSize._10X, "<i class=\"fa-regular fa-circle-half-stroke fa-10x\"></i>")]
    public Task Should_Render_A_Size_Icon(IconSize iconSize, string expected) =>
        Verify(FaSolid.Adjust
                      .Size(iconSize)
                      .ToIcon()
            )
           .HashParameters().UseParameters(iconSize, expected);

    [Theory]
    [InlineData(IconPull.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconPull.Left, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-left\"></i>")]
    [InlineData(IconPull.Right, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-right\"></i>")]
    public Task Should_Render_A_Pull_Icon(IconPull iconPull, string expected) =>
        Verify(
                FaSolid
                   .Adjust
                   .Pull(iconPull)
                   .ToIcon()
            )
           .HashParameters().UseParameters(iconPull, expected);

    [Theory]
    [ClassData(typeof(IconAnimationData))]
    [ClassData(typeof(IconBorderAndPullData))]
    [ClassData(typeof(IconTransformData))]
    public Task IconValidations(string id, Icon icon) => Verify(icon.ToIcon()).HashParameters().UseParameters(id);

    private class IconTransformData : IconTheory
    {
        public IconTransformData()
        {
            foreach (var size in Enum.GetValues<IconSize>().Distinct())
            {
                AddIcon(FaSolid.Chain.Size(size), size);
            }

            AddIcon(FaSolid.Chain.FixedWidth());
            AddIcon(FaSolid.Chain.FixedWidth(false));
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
                   .AnimationDelay("3s")
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
