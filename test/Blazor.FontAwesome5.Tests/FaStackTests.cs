using Egil.RazorComponents.Testing;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome5.Brands;
using Rocket.Surgery.Blazor.FontAwesome5.Pro;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;

namespace Rocket.Surgery.Blazor.FontAwesome5.Tests {
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
}