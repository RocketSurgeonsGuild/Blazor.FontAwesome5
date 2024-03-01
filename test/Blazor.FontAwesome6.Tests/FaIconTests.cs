using System.Runtime.CompilerServices;
using Bogus;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class FaIconTests : LoggerTest
{
    [Fact]
    public void Should_Support_Implicit_Conversion_From_Known_Enum()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder.Add(x => x.Icon, FaRegular.Adjust)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke\"></i>");
    }

    [Fact]
    public void Should_Render_A_Transformed_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Rotate, -40)
                      .Add(x => x.Left, 2)
                      .Add(x => x.Down, 4)
                      .Add(x => x.Right, 1)
                      .Add(x => x.Up, 12)
                      .Add(x => x.Grow, 6)
                      .Add(x => x.Shrink, 4)
        );
        icon
           .Markup.Should()
           .Be(
                "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"grow-6.00 shrink-4.00 rotate--40.00 up-12.00 down-4.00 left-2.00 right-1.00\"></i>"
            );
    }

    [Fact]
    public void Should_Render_A_FixedWith_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.FixedWidth, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-fw\"></i>");
    }

    [Fact]
    public void Should_Render_A_Spin_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Spin, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin\"></i>");
    }

    [Fact]
    public void Should_Render_A_Spin_Reverse_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Spin, true)
                      .Add(z => z.Reverse, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin fa-spin-reverse\"></i>");
    }

    [Fact]
    public void Should_Render_A_Pulse_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.SpinPulse, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin-pulse\"></i>");
    }

    [Fact]
    public void Should_Render_A_Pulse_Reverse_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.SpinPulse, true)
                      .Add(z => z.Reverse, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-spin-pulse fa-spin-reverse\"></i>");
    }

    [Fact]
    public void Should_Render_A_Border_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Border, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-border\"></i>");
    }

    [Fact]
    public void Should_Render_A_Inverse_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Inverse, true)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke fa-inverse\"></i>");
    }

    [Fact]
    public void Should_Render_A_Mask_Icon()
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Mask, FaDuotone.Analytics)
        );
        icon.Markup.Should().Be("<i class=\"fa-regular fa-circle-half-stroke\" data-fa-mask=\"fa-duotone fa-chart-mixed\"></i>");
    }

    public FaIconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }
    private TestContext _host = new();

    [Theory]
    [InlineData(IconFlip.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconFlip.Horizontal, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h\"></i>")]
    [InlineData(IconFlip.Vertical, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-v\"></i>")]
    [InlineData(IconFlip.Both, "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"flip-h flip-v\"></i>")]
    public void Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected)
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.FlipTransform, iconFlip)
        );
        icon.Markup.Should().Be(expected);
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
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Size, iconSize)
        );
        icon.Markup.Should().Be(expected);
    }

    [Theory]
    [InlineData(IconPull.None, "<i class=\"fa-regular fa-circle-half-stroke\"></i>")]
    [InlineData(IconPull.Left, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-left\"></i>")]
    [InlineData(IconPull.Right, "<i class=\"fa-regular fa-circle-half-stroke fa-pull-right\"></i>")]
    public void Should_Render_A_Pull_Icon(IconPull iconPull, string expected)
    {
        var icon = _host.RenderComponent<FaIcon>(
            builder => builder
                      .Add(x => x.Icon, FaRegular.Adjust)
                      .Add(x => x.Pull, iconPull)
        );
        icon.Markup.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(IconAnimationData))]
    [ClassData(typeof(IconBorderAndPullData))]
    [ClassData(typeof(IconTransformData))]
    public Task IconValidations(string id, Action<ComponentParameterCollectionBuilder<FaIcon>> icon)
    {
        return Verify(_host.RenderComponent(icon)).UseHashedParameters(id);
    }

    private class IconTransformData : IconTheory
    {
        public IconTransformData()
        {
            foreach (var size in Enum.GetValues<IconSize>().Distinct())
            {
                AddIcon(
                    z => z.Add(x => x.Icon, FaSolid.Chain.Size(size)),
                    size
                );
                AddIcon(
                    z => z
                        .Add(x => x.Icon, FaSolid.Chain)
                        .Add(x => x.Size, size),
                    size
                );
                AddIcon(
                    z => z
                        .Add(x => x.Icon, FaSolid.Chain.Size(size == IconSize._5X ? IconSize._6X : IconSize._5X))
                        .Add(x => x.Size, size),
                    size
                );
            }

            AddIcon(
                z => z.Add(x => x.Icon, FaRegular.Chain.FixedWidth())
            );

            AddIcon(
                z => z.Add(x => x.Icon, FaRegular.Chain).Add(x => x.FixedWidth, true)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaRegular.Chain.FixedWidth()).Add(x => x.FixedWidth, false)
            );

            AddIcon(
                z => z.Add(x => x.Icon, FaRegular.Chain.FixedWidth(false))
            );

            AddIcon(
                z => z.Add(x => x.Icon, FaRegular.Chain).Add(x => x.FixedWidth, false)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaRegular.Chain.FixedWidth(false)).Add(x => x.FixedWidth, true)
            );
            AddIcon(
                z => z.Add(
                    x => x.Icon,
                    FaSolid
                       .Barcode
                       .Grow(1)
                       .Shrink(2)
                       .Up(3)
                       .Left(4)
                       .Down(5)
                       .Right(6)
                       .Rotate(7)
                )
            );
            AddIcon(
                z => z
                    .Add(x => x.Icon, FaSolid.Barcode)
                    .Add(x => x.Grow, 1)
                    .Add(x => x.Shrink, 2)
                    .Add(x => x.Up, 3)
                    .Add(x => x.Left, 4)
                    .Add(x => x.Down, 5)
                    .Add(x => x.Right, 6)
                    .Add(x => x.Rotate, 7)
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Barcode
                            .Grow(10)
                            .Shrink(10)
                            .Up(10)
                            .Left(10)
                            .Down(10)
                            .Right(10)
                            .Rotate(10)
                     )
                    .Add(x => x.Grow, 1)
                    .Add(x => x.Shrink, 2)
                    .Add(x => x.Up, 3)
                    .Add(x => x.Left, 4)
                    .Add(x => x.Down, 5)
                    .Add(x => x.Right, 6)
                    .Add(x => x.Rotate, 7)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode.RotateLeft(100))
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.Rotate, -100)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode.RotateRight(100))
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.Rotate, 100)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode.RotateBy("100deg"))
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.RotateBy, "100deg")
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.FlipTransform, IconFlip.None)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode.FlipIcon(IconFlip.Vertical))
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.FlipTransform, IconFlip.Vertical)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode.FlipIcon(IconFlip.Horizontal))
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.FlipTransform, IconFlip.Horizontal)
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode.FlipIcon(IconFlip.Both))
            );
            AddIcon(
                z => z.Add(x => x.Icon, FaSolid.Barcode).Add(x => x.FlipTransform, IconFlip.Both)
            );
        }
    }


    private class IconBorderAndPullData : IconTheory
    {
        public IconBorderAndPullData()
        {
            AddIcon(
                z => z.Add(
                    x => x.Icon,
                    FaSolid.Bank
                           .Border(
                                true,
                                "#FF0000",
                                "6px",
                                "8px",
                                "dotted",
                                "12px"
                            )
                )
            );
            foreach (var item in Enum.GetValues<IconPull>())
            {
                AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.Pull(item, "12px")), item);
                AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(z => z.Pull, IconPull.Left).Add(z => z.PullMargin, "8px"), item);
            }

            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.Pull(IconPull.Right).PullMargin("5px")));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(x => x.Pull, IconPull.Right).Add(x => x.PullMargin, "10px"));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.PullRight()));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(x => x.Pull, IconPull.Right));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.PullLeft()));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(x => x.Pull, IconPull.Left));
        }
    }


    private class IconAnimationData : IconTheory
    {
        public IconAnimationData()
        {
            foreach (var item in Enum.GetValues<IconAnimation>().Concat(Enum.GetValues<IconAnimation>().Select(i => i | IconAnimation.Reverse)).Distinct())
            {
                AddIcon(
                    z => z.Add(
                        x => x.Icon,
                        FaSolid.Battery
                               .Animate(
                                    item,
                                    "3s",
                                    "alternate-reverse",
                                    "4s",
                                    "5s",
                                    "ease-in-out"
                                )
                    ),
                    item
                );
                AddIcon(
                    z => z
                        .Add(x => x.Icon, FaSolid.Battery)
                        .Add(x => x.Animation, item)
                        .Add(z => z.AnimationDelay, "3s")
                        .Add(z => z.AnimationDirection, "alternate-reverse")
                        .Add(z => z.AnimationDuration, "4s")
                        .Add(z => z.AnimationIterationCount, "5s")
                        .Add(z => z.AnimationTiming, "ease-in-out"),
                    item
                );
                AddIcon(
                    z => z
                        .Add(
                             x => x.Icon,
                             FaSolid.Battery
                                    .Animate(
                                         item,
                                         "10s",
                                         "11alternate-reverse",
                                         "10s",
                                         "10s",
                                         "11ease-in-out"
                                     )
                         )
                        .Add(z => z.AnimationDelay, "3s")
                        .Add(z => z.AnimationDirection, "alternate-reverse")
                        .Add(z => z.AnimationDuration, "4s")
                        .Add(z => z.AnimationIterationCount, "5s")
                        .Add(z => z.AnimationTiming, "ease-in-out"),
                    item
                );
            }

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid
                           .Battery
                           .Animate(IconAnimation.Beat)
                           .AnimationDirection("alternate-reverse")
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationDirection, "alternate-reverse")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                            .Animate(IconAnimation.Bounce)
                            .AnimationDirection("reverse")
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationDirection, "alternate-reverse")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid
                           .Battery
                           .Animate(IconAnimation.Beat)
                           .AnimationDuration("2s")
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationDuration, "2s")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                            .Animate(IconAnimation.Bounce)
                            .AnimationDuration("10s")
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationDuration, "2s")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid
                           .Battery
                           .Animate(IconAnimation.Beat)
                           .AnimationTiming("ease-in-out")
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                            .Animate(IconAnimation.Bounce)
                            .AnimationTiming("ease-out")
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid
                           .Battery
                           .Animate(IconAnimation.Beat)
                           .AnimationDelay("3s")
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationDelay, "3s")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                            .Animate(IconAnimation.Bounce)
                            .AnimationDelay("10s")
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationDelay, "3s")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid
                           .Battery
                           .Animate(IconAnimation.Beat)
                           .AnimationIterationCount("4s")
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationIterationCount, "4s")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid
                            .Battery
                            .Animate(IconAnimation.Bounce)
                            .AnimationIterationCount("10s")
                     )
                    .Add(z => z.Animation, IconAnimation.Beat)
                    .Add(z => z.AnimationIterationCount, "4s")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
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
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.Bounce, true)
                    .Add(z => z.BounceRebound, 1)
                    .Add(z => z.BounceHeight, 2)
                    .Add(z => z.BounceStartScaleX, 3)
                    .Add(z => z.BounceStartScaleY, 4)
                    .Add(z => z.BounceJumpScaleX, 5)
                    .Add(z => z.BounceJumpScaleY, 6)
                    .Add(z => z.BounceLandScaleX, 7)
                    .Add(z => z.BounceLandScaleY, 8)
                    .Add(z => z.AnimationDelay, "3s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "4s")
                    .Add(z => z.AnimationIterationCount, "5s")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Bounce(
                                     10,
                                     10,
                                     10,
                                     10,
                                     10,
                                     10,
                                     10,
                                     10,
                                     "11s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.Bounce, true)
                    .Add(z => z.BounceRebound, 1)
                    .Add(z => z.BounceHeight, 2)
                    .Add(z => z.BounceStartScaleX, 3)
                    .Add(z => z.BounceStartScaleY, 4)
                    .Add(z => z.BounceJumpScaleX, 5)
                    .Add(z => z.BounceJumpScaleY, 6)
                    .Add(z => z.BounceLandScaleX, 7)
                    .Add(z => z.BounceLandScaleY, 8)
                    .Add(z => z.AnimationDelay, "3s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "4s")
                    .Add(z => z.AnimationIterationCount, "5s")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .Beat(
                                    4,
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.Beat, true)
                    .Add(z => z.BeatScale, 4)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Beat(
                                     10,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.Beat, true)
                    .Add(z => z.BeatScale, 4)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .Fade(
                                    4,
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.Fade, true)
                    .Add(z => z.FadeOpacity, 4)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Fade(
                                     10,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.Fade, true)
                    .Add(z => z.FadeOpacity, 4)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
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
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.BeatFade, true)
                    .Add(z => z.BeatFadeOpacity, 4)
                    .Add(z => z.BeatFadeScale, 5)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .BeatFade(
                                     10,
                                     10,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.BeatFade, true)
                    .Add(z => z.BeatFadeOpacity, 4)
                    .Add(z => z.BeatFadeScale, 5)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
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
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.FlipX, 1)
                    .Add(z => z.FlipY, 2)
                    .Add(z => z.FlipZ, 3)
                    .Add(z => z.FlipAngle, "10deg")
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Flip(
                                     10,
                                     10,
                                     10,
                                     "11deg",
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.FlipX, 1)
                    .Add(z => z.FlipY, 2)
                    .Add(z => z.FlipZ, 3)
                    .Add(z => z.FlipAngle, "10deg")
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .Shake(
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.Shake, true)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Shake(
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.Shake, true)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .Spin(
                                    true,
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.Spin, true)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Spin(
                                     true,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.Spin, true)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .Spin(
                                    false,
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.Spin, false)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .Spin(
                                     false,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.Spin, false)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .SpinPulse(
                                    true,
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.SpinPulse, true)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .SpinPulse(
                                     true,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.SpinPulse, true)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );

            AddIcon(
                z => z
                   .Add(
                        x => x.Icon,
                        FaSolid.Bank
                               .SpinPulse(
                                    false,
                                    "9s",
                                    "alternate-reverse",
                                    "10s",
                                    "11",
                                    "ease-in-out"
                                )
                    )
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                     )
                    .Add(z => z.SpinPulse, false)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
            AddIcon(
                z => z
                    .Add(
                         x => x.Icon,
                         FaSolid.Bank
                                .SpinPulse(
                                     false,
                                     "10s",
                                     "reverse",
                                     "11s",
                                     "10",
                                     "ease-in"
                                 )
                     )
                    .Add(z => z.SpinPulse, false)
                    .Add(z => z.AnimationDelay, "9s")
                    .Add(z => z.AnimationDirection, "alternate-reverse")
                    .Add(z => z.AnimationDuration, "10s")
                    .Add(z => z.AnimationIterationCount, "11")
                    .Add(z => z.AnimationTiming, "ease-in-out")
            );
        }
    }

    private class IconTheory : TheoryData<string, Action<ComponentParameterCollectionBuilder<FaIcon>>>
    {
        protected void AddIcon(Action<ComponentParameterCollectionBuilder<FaIcon>> icon, [CallerArgumentExpression(nameof(icon))] string? caller = null)
        {
            Add(string.Join("", caller.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(z => z.Trim())), icon);
        }

        protected void AddIcon(
            Action<ComponentParameterCollectionBuilder<FaIcon>> icon,
            object variation,
            [CallerArgumentExpression(nameof(icon))]
            string? caller = null
        )
        {
            Add(variation + " @ " + string.Join("", caller.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(z => z.Trim())), icon);
        }
    }
}
