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
//        [ClassData(typeof(IconAnimationData))]
//        [ClassData(typeof(IconBorderAndPullData))]
    [ClassData(typeof(IconTransformData))]
    public Task IconValidations(string id, Action<ComponentParameterCollectionBuilder<FaIcon>> icon)
    {
        return Verify(_host.RenderComponent(icon)).UseHashedParameters(id);
    }

    private class IconTransformData : IconTheory
    {
        public IconTransformData()
        {
            var bogus = new Faker { Random = new(3), };
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
                        .Add(x => x.Icon, FaSolid.Chain.Size(bogus.PickRandom(Enum.GetValues<IconSize>().Except([size,]))))
                        .Add(x => x.Size, size)
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
                       .Grow(bogus.Random.Double())
                       .Shrink(bogus.Random.Double())
                       .Up(bogus.Random.Double())
                       .Left(bogus.Random.Double())
                       .Down(bogus.Random.Double())
                       .Right(bogus.Random.Double())
                       .Rotate(bogus.Random.Double())
                )
            );
            AddIcon(
                z => z
                    .Add(x => x.Icon, FaSolid.Barcode)
                    .Add(x => x.Grow, bogus.Random.Double())
                    .Add(x => x.Shrink, bogus.Random.Double())
                    .Add(x => x.Up, bogus.Random.Double())
                    .Add(x => x.Left, bogus.Random.Double())
                    .Add(x => x.Down, bogus.Random.Double())
                    .Add(x => x.Right, bogus.Random.Double())
                    .Add(x => x.Rotate, bogus.Random.Double())
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
                    .Add(x => x.Grow, bogus.Random.Double())
                    .Add(x => x.Shrink, bogus.Random.Double())
                    .Add(x => x.Up, bogus.Random.Double())
                    .Add(x => x.Left, bogus.Random.Double())
                    .Add(x => x.Down, bogus.Random.Double())
                    .Add(x => x.Right, bogus.Random.Double())
                    .Add(x => x.Rotate, bogus.Random.Double())
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
            var bogus = new Faker { Random = new(5), };
            AddIcon(
                z => z.Add(
                    x => x.Icon,
                    FaSolid.Bank
                           .Border(
                                true,
                                bogus.Internet.Color(),
                                bogus.Random.Number(100) + "px",
                                bogus.Random.Number(100) + "px",
                                bogus.PickRandom(
                                    "solid",
                                    "dotted",
                                    "dashed",
                                    "double",
                                    "groove",
                                    "ridge",
                                    "inset",
                                    "outset"
                                ),
                                bogus.Random.Number(100) + "px"
                            )
                )
            );
            foreach (var item in Enum.GetValues<IconPull>())
            {
                AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.Pull(item, bogus.Random.Number(100) + "px")), item);
                AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(z => z.Pull, IconPull.Left).Add(z => z.PullMargin, bogus.Random.Number(100) + "px"), item);
            }

            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.Pull(IconPull.Right).PullMargin(bogus.Random.Number(100) + "px")));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(x => x.Pull, IconPull.Right).Add(x => x.PullMargin, bogus.Random.Number(100) + "px"));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.PullRight()));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(x => x.Pull, IconPull.Right));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank.PullLeft()));
            AddIcon(z => z.Add(x => x.Icon, FaSolid.Bank).Add(x => x.Pull, IconPull.Left));
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