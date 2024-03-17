using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class IconTests : LoggerTest
{
    [Fact]
    public Task Should_Support_Implicit_Conversion_From_Known_Enum()
    {
        return Verify(FaDuotone.CircleHalfStroke);
    }

    [Fact]
    public Task Should_Render_An_Icon()
    {
        return Verify(FaDuotone.CircleHalfStroke.ToIcon());
    }

    [Fact]
    public Task Should_Render_A_Transformed_Icon()
    {
        return Verify(
            FaDuotone
               .CircleHalfStroke
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
        );
    }

    [Fact]
    public Task Should_Render_A_FixedWith_Icon()
    {
        return Verify(FaDuotone.CircleHalfStroke.FixedWidth().ToIcon());
    }

    [Fact]
    public Task Should_Render_A_Spin_Icon()
    {
        return Verify(FaDuotone.CircleHalfStroke.Spin());
    }

    [Fact]
    public Task Should_Render_A_Pulse_Icon()
    {
        return Verify(
            FaDuotone
               .CircleHalfStroke
               .SpinPulse()
               .ToIcon()
        );
    }

    [Fact]
    public Task Should_Render_A_Border_Icon()
    {
        return Verify(
            FaDuotone
               .CircleHalfStroke
               .Border()
               .ToIcon()
        );
    }

    [Fact]
    public Task Should_Render_A_Inverse_Icon()
    {
        return Verify(
            FaDuotone
               .CircleHalfStroke
               .Inverse()
               .ToIcon()
        );
    }

    [Fact]
    public Task Should_Render_A_Mask_Icon()
    {
        return Verify(
            FaDuotone
               .CircleHalfStroke
               .Mask(FaBrands.Microsoft)
               .ToIcon()
        );
    }

    public IconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }

    [Theory]
    [InlineData(IconFlip.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconFlip.Horizontal, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h\"></i>")]
    [InlineData(IconFlip.Vertical, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-v\"></i>")]
    [InlineData(IconFlip.Both, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h flip-v\"></i>")]
    public Task Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected)
    {
        return Verify(
                FaDuotone
                   .CircleHalfStroke
                   .FlipIcon(iconFlip)
                   .ToIcon()
            )
           .UseHashedParameters(iconFlip, expected);
    }

    [Theory]
    [InlineData(IconSize.ExtraSmall, "<i class=\"fa-regular fa-circle-half-stroke fa-xs\"></i>")]
    [InlineData(IconSize.Small, "<i class=\"fa-regular fa-circle-half-stroke fa-sm\"></i>")]
    [InlineData(IconSize.Normal, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconSize.Large, "<i class=\"fa-regular fa-circle-half-stroke fa-lg\"></i>")]
    [InlineData(IconSize._2X, "<i class=\"fa-regular fa-circle-half-stroke fa-2x\"></i>")]
    [InlineData(IconSize._5X, "<i class=\"fa-regular fa-circle-half-stroke fa-5x\"></i>")]
    [InlineData(IconSize._10X, "<i class=\"fa-regular fa-circle-half-stroke fa-10x\"></i>")]
    public Task Should_Render_A_Size_Icon(IconSize iconSize, string expected)
    {
        return Verify(
                FaDuotone
                   .CircleHalfStroke
                   .Size(iconSize)
                   .ToIcon()
            )
           .UseHashedParameters(iconSize, expected);
    }

    [Theory]
    [InlineData(IconPull.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconPull.Left, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-left\"></i>")]
    [InlineData(IconPull.Right, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-right\"></i>")]
    public Task Should_Render_A_Pull_Icon(IconPull iconPull, string expected)
    {
        return Verify(
                FaDuotone
                   .CircleHalfStroke
                   .Pull(iconPull)
                   .ToIcon()
            )
           .UseHashedParameters(iconPull, expected);
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
                AddIcon(FaDuotone.Link.Size(size), size);
            }

            AddIcon(FaDuotone.Link.FixedWidth());
            AddIcon(FaDuotone.Link.FixedWidth(false));
            AddIcon(
                FaDuotone
                   .Barcode
                   .Grow(2)
                   .Shrink(3)
                   .Up(4)
                   .Left(5)
                   .Down(6)
                   .Right(7)
                   .Rotate(8)
            );
            AddIcon(FaDuotone.Barcode.RotateLeft(100));
            AddIcon(FaDuotone.Barcode.RotateRight(100));
            AddIcon(FaDuotone.Barcode.RotateBy("100deg"));
            AddIcon(FaDuotone.Barcode.FlipIcon());
            AddIcon(FaDuotone.Barcode.FlipIcon(IconFlip.Vertical));
            AddIcon(FaDuotone.Barcode.FlipIcon(IconFlip.Horizontal));
            AddIcon(FaDuotone.Barcode.FlipIcon(IconFlip.Both));
        }
    }

    private class IconBorderAndPullData : IconTheory
    {
        public IconBorderAndPullData()
        {
            AddIcon(
                FaDuotone.BuildingColumns
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
                AddIcon(FaDuotone.BuildingColumns.Pull(item, "20px"), item);
            }

            AddIcon(FaDuotone.BuildingColumns.Pull(IconPull.Right).PullMargin("10px"));
            AddIcon(FaDuotone.BuildingColumns.PullRight());
            AddIcon(FaDuotone.BuildingColumns.PullLeft());
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
                    FaDuotone.BatteryFull
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
                FaDuotone
                   .BatteryFull
                   .Animate(IconAnimation.Beat)
                   .AnimationDirection("alternate-reverse")
            );
            AddIcon(
                FaDuotone
                   .BatteryFull
                   .Animate(IconAnimation.Beat)
                   .AnimationDuration("2s")
            );
            AddIcon(
                FaDuotone
                   .BatteryFull
                   .Animate(IconAnimation.Beat)
                   .AnimationTiming("ease-in-out")
            );
            AddIcon(
                FaDuotone
                   .BatteryFull
                   .Animate(IconAnimation.Beat)
                   .AnimationDelay("3s")
            );
            AddIcon(
                FaDuotone
                   .BatteryFull
                   .Animate(IconAnimation.Beat)
                   .AnimationIterationCount("4s")
            );

            AddIcon(
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
                         .Shake(
                              "9s",
                              "alternate-reverse",
                              "10s",
                              "11",
                              "ease-in-out"
                          )
            );

            AddIcon(
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
                FaDuotone.BuildingColumns
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
