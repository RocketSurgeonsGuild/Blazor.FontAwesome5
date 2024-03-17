using System.Reflection;
using System.Text.RegularExpressions;
using DryIoc.ImTools;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
using SkipException = Xunit.Sdk.SkipException;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class CategoryProviderTests
{
    [Fact]
    public void CategoryProvider_Should_Return_Default_Categories()
    {
        var provider = CategoryProvider.CreateDefault();
        provider.Should().NotBeNull();
        provider.Categories.Should().NotBeEmpty();
    }

    private string ApiKey
    {
        get
        {
            Skip.If(Environment.GetEnvironmentVariable("FONT_AWESOME_API_KEY") is null, "FONT_AWESOME_API_KEY is not set");
            return Environment.GetEnvironmentVariable("FONT_AWESOME_API_KEY")!;
        }
    }

    private string FontFamilies
    {
        get
        {
            var filePath = typeof(CategoryProviderTests)
                          .Assembly.GetCustomAttributes()
                          .OfType<AssemblyMetadataAttribute>()
                          .FirstOrDefault(z => z.Key == "FontAwesomeFamilysJson");
            Skip.If(filePath.Value is null, "FontAwesomeFamilysJson is not set");
            return filePath.Value!;
        }
    }

    [SkippableTheory]
    [InlineData(true, false)]
    [InlineData(false, false)]
    [InlineData(true, true)]
    [InlineData(false, true)]
    public async Task Should_Get_Data_From_Icon_Families(bool svgMode, bool proIcons)
    {
        using var host = Host
                        .CreateDefaultBuilder()
                        .ConfigureRocketSurgery()
                        .ConfigureServices((_, collection) => collection.AddSingleton(new FontAwesomeApiKeyProvider() { ApiKey = ApiKey }))
                        .Build();
        await host.StartAsync();
        var categoryProvider = CategoryProvider.CreateDefault();
        var mediator = host.Services.GetRequiredService<IMediator>();

        var icons = await mediator.Send(new GetIconsFromIconFamilies.Request(FontFamilies, proIcons, categoryProvider));
        var result = await mediator.CreateStream(new GetFileContentForIcons.Request(icons, "Someplace", svgMode, categoryProvider)).ToListAsync();
        await VerifyIcons(icons, result).UseParameters(svgMode, proIcons);
    }

    [SkippableTheory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task Should_Get_Data_From_Font_Awesome_Api(bool svgMode)
    {
        using var host = Host
                        .CreateDefaultBuilder()
                        .ConfigureRocketSurgery()
                        .ConfigureServices((_, collection) => collection.AddSingleton(new FontAwesomeApiKeyProvider() { ApiKey = ApiKey }))
                        .Build();
        await host.StartAsync();
        var categoryProvider = CategoryProvider.CreateDefault();
        var mediator = host.Services.GetRequiredService<IMediator>();

        var icons = await mediator.Send(new GetIconsFromRelease.Request("6.x", categoryProvider));
        var result = await mediator.CreateStream(new GetFileContentForIcons.Request(icons, "Someplace", svgMode, categoryProvider)).ToListAsync();
        await VerifyIcons(icons, result).UseParameters(svgMode);
    }

    [SkippableTheory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task Should_Get_Data_From_Font_Awesome_Kit(bool svgMode)
    {
        using var host = Host
                        .CreateDefaultBuilder()
                        .ConfigureRocketSurgery()
                        .ConfigureServices((_, collection) => collection.AddSingleton(new FontAwesomeApiKeyProvider() { ApiKey = ApiKey }))
                        .Build();
        await host.StartAsync();
        var categoryProvider = CategoryProvider.CreateDefault();
        var mediator = host.Services.GetRequiredService<IMediator>();

        var icons = await mediator.Send(new GetIconsFromKit.Request("53d4c0d96f", categoryProvider));
        var result = await mediator.CreateStream(new GetFileContentForIcons.Request(icons, "Someplace", svgMode, categoryProvider)).ToListAsync();
        await VerifyIcons(icons, result).UseParameters(svgMode);
    }

    private SettingsTask VerifyIcons(IEnumerable<IconModel> icons, IEnumerable<GetFileContentForIcons.FileContent> files)
    {
        var verify = Verify(icons);

//        var scrubValues = new List<string>();
        var regex = new Regex(@"ImmutableArray\.Create\(.*?\)\.ToImmutableArray\(\)\)", RegexOptions.Compiled);
        var regexUnicode = new Regex(@""", "".*?""\);", RegexOptions.Compiled);
        var regexUnicode2 = new Regex("\", \".*?\", (\\d+)", RegexOptions.Compiled);
        verify.ScrubLinesWithReplace("cs", line =>
                                     {
                                         line= regexUnicode.Replace(line, "\", \"[unicode]\");");
                                         line= regexUnicode2.Replace(line, "\", \"[unicode]\", $1");
                                         line = regex.Replace(line, "\"[path]\"");
                                         return line;
                                     });
        ;
//        foreach (var icon in icons)
//        {
//            scrubValues.Add($"\"{icon.Unicode}\"");
//        }
        foreach (var second in files)
        {
            verify.AppendContentAsFile(second.Content, "cs", second.FileName);
        }

        return verify;
    }
}
