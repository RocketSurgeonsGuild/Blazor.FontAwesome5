using Bunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome6.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests {
    public class FaStackTests : LoggerTest
    {
        public FaStackTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }
        TestContext _host = new TestContext();

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_1()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Add(x => x.Size, IconSize._2X)
                   .AddChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Square)
                                   .Parameter(z => z.Size, IconSize._2X)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaBrands.Twitter)
                                   .Parameter(z => z.Inverse, true)
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fa-solid fa-square fa-stack-2x\"></i>" +
                "<i class=\"fa-brands fa-twitter fa-inverse fa-stack-1x\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_2()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Add(x => x.Size, IconSize._2X)
                   .AddChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Circle)
                                   .Parameter(z => z.Size, IconSize._2X)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Flag)
                                   .Parameter(z => z.Inverse, true)
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fa-solid fa-circle fa-stack-2x\"></i>" +
                "<i class=\"fa-solid fa-flag fa-inverse fa-stack-1x\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_3()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Add(x => x.Size, IconSize._2X)
                   .AddChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Square)
                                   .Parameter(z => z.Size, IconSize._2X)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Terminal)
                                   .Parameter(z => z.Inverse, true)
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fa-solid fa-square fa-stack-2x\"></i>" +
                "<i class=\"fa-solid fa-terminal fa-inverse fa-stack-1x\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_stacking_icons_4()
        {
            var icon = _host.RenderComponent<FaStack>(
                builder => builder
                   .Add(x => x.Size, IconSize._2X)
                   .AddChildContent(
                        child => child
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Camera)
                                   .Parameter(z => z.Size, IconSize.Normal)
                            )
                           .RenderComponent<FaIcon>(
                                fa => fa
                                   .Parameter(z => z.Icon, FaSolid.Ban)
                                   .Parameter(z => z.Size, IconSize._2X)
                                   .Parameter(x => x.Style, "color:Tomato")
                            )
                    )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-stack fa-2x\">" +
                "<i class=\"fa-solid fa-camera fa-stack-1x\"></i>" +
                "<i class=\"fa-solid fa-ban fa-stack-2x\" style=\"color:Tomato\"></i>" +
                "</span>"
            );
        }
    }
}
