using System.Collections.Generic;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Rocket.Surgery.Blazor.FontAwesome5.Pro;
using Rocket.Surgery.Blazor.FontAwesome5.Shared;
using Rocket.Surgery.Extensions.Testing;
using Xunit;
using Xunit.Abstractions;
using static Rocket.Surgery.Blazor.FontAwesome5.Tests.ComponentParameterHelpers;

namespace Rocket.Surgery.Blazor.FontAwesome5.Tests
{
    public class FaLayerTests : LoggerTest
    {
        private TestContext _host = new TestContext();

        public FaLayerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information)
        {
        }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_1()
        {
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                          .Add(z => z.FixedWidth, true)
                          .Add(x => x.Style, "background:MistyRose")
                          .AddChildContent(
                               b => b
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Circle)
                                            .Parameter(x => x.Style, "color:Tomato")
                                    )
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Times)
                                            .Parameter(x => x.Shrink, "6")
                                            .Parameter(x => x.Inverse, true)
                                    )
                           )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-circle\" style=\"color:Tomato\"></i>" +
                "<i class=\"fas fa-times fa-inverse\" data-fa-transform=\"shrink-6.00\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_2()
        {
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                          .Add(x => x.FixedWidth, true)
                          .Add(x => x.Style, "background:MistyRose")
                          .AddChildContent(
                               b => b
                                   .RenderComponent<FaIcon>(
                                        c => c
                                           .Parameter(x => x.Icon, Fas.Bookmark)
                                    )
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Heart)
                                            .Parameter(x => x.Inverse, true)
                                            .Parameter(x => x.Shrink, "10")
                                            .Parameter(x => x.Up, "2")
                                            .Parameter(x => x.Style, "color:Tomato")
                                    )
                           )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-bookmark\"></i>" +
                "<i class=\"fas fa-heart fa-inverse\" style=\"color:Tomato\" data-fa-transform=\"shrink-10.00 up-2.00\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_3()
        {
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                          .Add(x => x.FixedWidth, true)
                          .Add(x => x.Style, "background:MistyRose")
                          .AddChildContent(
                               b => b
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Play)
                                            .Parameter(x => x.Rotate, "-90")
                                            .Parameter(x => x.Grow, "2")
                                    )
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Sun)
                                            .Parameter(x => x.Inverse, true)
                                            .Parameter(x => x.Shrink, "10")
                                            .Parameter(x => x.Up, "2")
                                    )
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Moon)
                                            .Parameter(x => x.Inverse, true)
                                            .Parameter(x => x.Shrink, "11")
                                            .Parameter(x => x.Down, "4.2")
                                            .Parameter(x => x.Left, "4")
                                    )
                                   .RenderComponent<FaIcon>(
                                        c => c
                                            .Parameter(x => x.Icon, Fas.Star)
                                            .Parameter(x => x.Inverse, true)
                                            .Parameter(x => x.Shrink, "11")
                                            .Parameter(x => x.Down, "4.2")
                                            .Parameter(x => x.Right, "4")
                                    )
                           )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-play\" data-fa-transform=\"grow-2.00 rotate--90.00\"></i>" +
                "<i class=\"fas fa-sun fa-inverse\" data-fa-transform=\"shrink-10.00 up-2.00\"></i>" +
                "<i class=\"fas fa-moon fa-inverse\" data-fa-transform=\"shrink-11.00 down-4.20 left-4.00\"></i>" +
                "<i class=\"fas fa-star fa-inverse\" data-fa-transform=\"shrink-11.00 down-4.20 right-4.00\"></i>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_4()
        {
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                          .Add(x => x.FixedWidth, true)
                          .Add(x => x.Style, "background:MistyRose")
                          .AddChildContent(
                               b => b
                                   .RenderComponent<FaIcon>(
                                        c => c
                                           .Parameter(x => x.Icon, Fas.Calendar)
                                    )
                                   .RenderComponent<FaText>(
                                        c => c
                                            .Parameter(x => x.Inverse, true)
                                            .Parameter(x => x.Shrink, "8")
                                            .Parameter(x => x.Down, "3")
                                            .Parameter(x => x.Style, "font-weight:900")
                                            .ChildContent("27")
                                    )
                           )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-calendar\"></i>" +
                "<span class=\"fa-layers-text fa-inverse\" style=\"font-weight:900\" data-fa-transform=\"shrink-8.00 down-3.00\">27</span>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_5()
        {
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                          .Add(x => x.FixedWidth, true)
                          .Add(x => x.Style, "background:MistyRose")
                          .AddChildContent(
                               b => b
                                   .RenderComponent<FaIcon>(
                                        c => c
                                           .Parameter(x => x.Icon, Fas.Certificate)
                                    )
                                   .RenderComponent<FaText>(
                                        c => c
                                            .Parameter(x => x.Inverse, true)
                                            .Parameter(x => x.Shrink, "11.5")
                                            .Parameter(x => x.Rotate, "-30")
                                            .Parameter(x => x.Style, "font-weight:900")
                                            .ChildContent("NEW")
                                    )
                           )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-certificate\"></i>" +
                "<span class=\"fa-layers-text fa-inverse\" style=\"font-weight:900\" data-fa-transform=\"shrink-11.50 rotate--30.00\">NEW</span>" +
                "</span>"
            );
        }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_6()
        {
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                          .Add(x => x.FixedWidth, true)
                          .Add(x => x.Style, "background:MistyRose")
                          .AddChildContent(
                               b => b
                                   .RenderComponent<FaIcon>(
                                        c => c
                                           .Parameter(x => x.Icon, Fas.Envelope)
                                    )
                                   .RenderComponent<FaCounter>(
                                        c => c
                                            .Parameter(x => x.Style, "background:Tomato")
                                            .ChildContent("1,419")
                                    )
                           )
            );

            icon.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-envelope\"></i>" +
                "<span class=\"fa-layers-counter\" style=\"background:Tomato\">1,419</span>" +
                "</span>"
            );
        }
    }
}
