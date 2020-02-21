using System.Collections.Generic;
using Egil.RazorComponents.Testing;
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
        public FaLayerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper, LogLevel.Information) { }

        [Fact]
        public void Should_Support_Documentation_styling_layering_example_1()
        {
            var icon2 = _host.RenderComponent<FaLayer>(
                Parameter(nameof(FaLayer.FixedWidth), true),
                    ChildContent("hello world...")
            );
            
            icon2.Render();
            
            var icon = _host.RenderComponent<FaLayer>(
                builder => builder
                   .Parameter(x => x.FixedWidth, true)
                   .ChildContent(
                        b => b
                           .RenderComponent<FaIcon>(
                                c => c
                                   .Parameter(x => x.Icon, Fas.Circle)
                                   .Parameter(x => x.Style, "background:MistyRose")
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
                "<i class=\"fa-inverse fas fa-times\" data-fa-transform=\"shrink-6\"></i>" +
                "</span>"
            );

            icon2.Markup.Should().Be(
                "<span class=\"fa-layers fa-fw\" style=\"background:MistyRose\">" +
                "<i class=\"fas fa-circle\" style=\"color:Tomato\"></i>" +
                "<i class=\"fa-inverse fas fa-times\" data-fa-transform=\"shrink-6\"></i>" +
                "</span>"
            );
        }

        /*
         <span class="fa-layers fa-fw" style="background:MistyRose">
            <i class="fas fa-circle" style="color:Tomato"></i>
            <i class="fa-inverse fas fa-times" data-fa-transform="shrink-6"></i>
          </span>
        
          <span class="fa-layers fa-fw" style="background:MistyRose">
            <i class="fas fa-bookmark"></i>
            <i class="fa-inverse fas fa-heart" data-fa-transform="shrink-10 up-2" style="color:Tomato"></i>
          </span>
        
          <span class="fa-layers fa-fw" style="background:MistyRose">
            <i class="fas fa-play" data-fa-transform="rotate--90 grow-2"></i>
            <i class="fas fa-sun fa-inverse" data-fa-transform="shrink-10 up-2"></i>
            <i class="fas fa-moon fa-inverse" data-fa-transform="shrink-11 down-4.2 left-4"></i>
            <i class="fas fa-star fa-inverse" data-fa-transform="shrink-11 down-4.2 right-4"></i>
          </span>
        
          <span class="fa-layers fa-fw" style="background:MistyRose">
            <i class="fas fa-calendar"></i>
            <span class="fa-layers-text fa-inverse" data-fa-transform="shrink-8 down-3" style="font-weight:900">27</span>
          </span>
        
          <span class="fa-layers fa-fw" style="background:MistyRose">
            <i class="fas fa-certificate"></i>
            <span class="fa-layers-text fa-inverse" data-fa-transform="shrink-11.5 rotate--30" style="font-weight:900">NEW</span>
          </span>
        
          <span class="fa-layers fa-fw" style="background:MistyRose">
            <i class="fas fa-envelope"></i>
            <span class="fa-layers-counter" style="background:Tomato">1,419</span>
          </span>
         */
    }
}