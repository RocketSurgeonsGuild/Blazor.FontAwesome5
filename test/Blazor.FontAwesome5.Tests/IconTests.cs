using System.Collections.Generic;
using Egil.RazorComponents.Testing;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome5.Brands;
using Rocket.Surgery.Blazor.FontAwesome5.Pro;
using Rocket.Surgery.Blazor.FontAwesome5.Shared;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome5.Tests
{
    public class IconTests : LoggerTest
    {
        public IconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }

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

        enum InvalidEnum
        {
            This,
            Is,
            Invalid
        }

        enum Custom
        {
            [FontAwesome(IconStyle.Regular, "adjust")]
            Name
        }
    }

    public class FaStackTests : LoggerTest
    {
        public FaStackTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }
        TestContext _host = new TestContext();

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_1()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Parameter(x => x.Size, IconSize._2X)
                   .ChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Square)
                                   .Parameter(z => z.Size, IconSize._2X)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fab.Twitter)
                                   .Parameter(z => z.Inverse, true)
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fas fa-square fa-stack-2x\"></i>" +
                "<i class=\"fab fa-twitter fa-stack-1x fa-inverse\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_2()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Parameter(x => x.Size, IconSize._2X)
                   .ChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Circle)
                                   .Parameter(z => z.Size, IconSize._2X)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Flag)
                                   .Parameter(z => z.Inverse, true)
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fas fa-circle fa-stack-2x\"></i>" +
                "<i class=\"fas fa-flag fa-stack-1x fa-inverse\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_3()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Parameter(x => x.Size, IconSize._2X)
                   .ChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Square)
                                   .Parameter(z => z.Size, IconSize._2X)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Terminal)
                                   .Parameter(z => z.Inverse, true)
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fas fa-square fa-stack-2x\"></i>" +
                "<i class=\"fas fa-terminal fa-stack-1x fa-inverse\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_4()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Parameter(x => x.Size, IconSize._2X)
                   .ChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Camera)
                                   .Parameter(z => z.Size, IconSize.Normal)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, Fas.Ban)
                                   .Parameter(z => z.Size, IconSize._2X)
                                   .Parameter(x => x.Style, "color:Tomato")
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fas fa-camera fa-stack-1x\"></i>" +
                "<i class=\"fas fa-ban fa-stack-2x\" style=\"color:Tomato\"></i>" +
                "</span>"
            );
        }
    }

    public class FaIconTests : LoggerTest
    {
        public FaIconTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }
        TestContext _host = new TestContext();

        [Fact]
        public void Should_Support_Implicit_Conversion_From_Known_Enum()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder.Parameter(x => x.Icon, Far.Adjust)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust\"></i>");
        }

        [Fact]
        public void Should_Support_Implicit_Conversion_From_Custom_Enum()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder.Parameter(x => x.Icon, Custom.Name)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust\"></i>");
        }

        [Fact]
        public void Should_Have_A_Default_Icon_If_Not_Defined()
        {
            _host.RenderComponent<FaIcon>().Markup.Should().Be("<i class=\"fas fa-bomb\"></i>");
        }

        [Fact]
        public void Should_Render_An_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder.Parameter(x => x.Icon, Custom.Name)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust\"></i>");
        }

        [Fact]
        public void Should_Render_A_Transformed_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Rotate, "-40")
                   .Parameter(x => x.Left, "2")
                   .Parameter(x => x.Down, "4")
                   .Parameter(x => x.Right, "1")
                   .Parameter(x => x.Up, "12")
                   .Parameter(x => x.Grow, "6")
                   .Parameter(x => x.Shrink, "4")
            );
            icon.Markup.Should().Be(
                "<i class=\"far fa-adjust\" data-fa-transform=\"grow-6.00 shrink-4.00 rotate--40.00 up-12.00 down-4.00 left-2.00 right-1.00\"></i>"
            );
        }

        [Theory]
        [InlineData(IconFlip.None, "<i class=\"far fa-adjust\"></i>")]
        [InlineData(IconFlip.Horizontal, "<i class=\"far fa-adjust\" data-fa-transform=\"flip-h\"></i>")]
        [InlineData(IconFlip.Vertical, "<i class=\"far fa-adjust\" data-fa-transform=\"flip-v\"></i>")]
        [InlineData(IconFlip.Both, "<i class=\"far fa-adjust\" data-fa-transform=\"flip-h flip-v\"></i>")]
        public void Should_Render_A_Flip_Icon(IconFlip iconFlip, string expected)
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Flip, iconFlip)
            );
            icon.Markup.Should().Be(expected);
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
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Size, iconSize)
            );
            icon.Markup.Should().Be(expected);
        }

        [Fact]
        public void Should_Render_A_FixedWith_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.FixedWidth, true)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust fa-fw\"></i>");
        }

        [Fact]
        public void Should_Render_A_Spin_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Spin, true)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust fa-spinner\"></i>");
        }

        [Fact]
        public void Should_Render_A_Pulse_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Pulse, true)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust fa-pulse\"></i>");
        }

        [Fact]
        public void Should_Render_A_Border_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Border, true)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust fa-border\"></i>");
        }

        [Fact]
        public void Should_Render_A_Inverse_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Inverse, true)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust fa-inverse\"></i>");
        }

        [Fact]
        public void Should_Render_A_Mask_Icon()
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Mask, Fad.Analytics)
            );
            icon.Markup.Should().Be("<i class=\"far fa-adjust\" data-fa-mask=\"fad fa-analytics\"></i>");
        }

        [Theory]
        [InlineData(IconPull.None, "<i class=\"far fa-adjust\"></i>")]
        [InlineData(IconPull.Left, "<i class=\"far fa-adjust fa-pull-left\"></i>")]
        [InlineData(IconPull.Right, "<i class=\"far fa-adjust fa-pull-right\"></i>")]
        public void Should_Render_A_Pull_Icon(IconPull iconPull, string expected)
        {
            var icon = _host.RenderComponent<FaIcon>(
                builder => builder
                   .Parameter(x => x.Icon, Far.Adjust)
                   .Parameter(x => x.Pull, iconPull)
            );
            icon.Markup.Should().Be(expected);
        }

        enum Custom
        {
            [FontAwesome(IconStyle.Regular, "adjust")]
            Name
        }
    }
}