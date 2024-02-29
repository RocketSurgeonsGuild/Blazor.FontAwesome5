using Bunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests {
    public class FaIconTests : LoggerTest
    {
        public FaIconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }
        TestContext _host = new TestContext();

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
            icon.Markup.Should().Be(
                "<i class=\"fa-regular fa-circle-half-stroke\" data-fa-transform=\"grow-6.00 shrink-4.00 rotate--40.00 up-12.00 down-4.00 left-2.00 right-1.00\"></i>"
            );
        }

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
    }
}
