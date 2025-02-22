using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.RegularExpressions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Blazor.FontAwesome.Tool;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests;

public class CategoryProviderTests
{
    [Fact]
    public void CategoryProvider_Should_Return_Default_Categories()
    {
        var provider = CategoryProvider.CreateDefault();
        provider.ShouldNotBeNull();
        provider.Categories.ShouldNotBeEmpty();
    }

    [SkippableTheory]
    [MemberData(nameof(GetIconsFromIconFamilies))]
    public async Task Should_Get_Data_From_Icon_Families(Family family, Style style, int size, IconsCollection icons, bool svgMode)
    {
        var result = await CreateStream(new GetFileContentForIcons.Request(icons, "Someplace", svgMode)).ToListAsync();
        await VerifyIcons(icons, result).UseParameters(family, style, size, svgMode);
    }

    [SkippableTheory]
    [MemberData(nameof(GetIconsFromRelease), "6.x")]
    public async Task Should_Get_Data_From_Font_Awesome_Api(Family family, Style style, int size, IconsCollection icons, bool svgMode)
    {
        var result = await CreateStream(new GetFileContentForIcons.Request(icons, "Someplace", svgMode)).ToListAsync();
        await VerifyIcons(icons, result).UseParameters(family, style, size, svgMode);
    }

    [SkippableTheory]
    [MemberData(nameof(GetIconsFromKit), "53d4c0d96f")]
    public async Task Should_Get_Data_From_Font_Awesome_Kit(Family family, Style style, int size, IconsCollection icons, bool svgMode)
    {
        var result = await CreateStream(new GetFileContentForIcons.Request(icons, "Someplace", svgMode)).ToListAsync();
        await VerifyIcons(icons, result).UseParameters(family, style, size, svgMode);
    }

    private SettingsTask VerifyIcons(IEnumerable<IconModel> icons, IEnumerable<GetFileContentForIcons.FileContent> files)
    {
        var verify = Verify(icons);

        //        var scrubValues = new List<string>();
        var regex = new Regex(@"ImmutableArray\.Create\(.*?\)\.ToImmutableArray\(\)\)", RegexOptions.Compiled);
        var regexUnicode = new Regex(@""", "".*?""\);", RegexOptions.Compiled);
        var regexUnicode2 = new Regex("\", \".*?\", (\\d+)", RegexOptions.Compiled);
        verify.ScrubLinesWithReplace(
            "cs",
            line =>
            {
                line = regexUnicode.Replace(line, "\", \"[unicode]\");");
                line = regexUnicode2.Replace(line, "\", \"[unicode]\", $1");
                line = regex.Replace(line, "\"[path]\"");
                return line;
            }
        );
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

    private static string? FontFamilies
    {
        get
        {
            var filePath = typeof(CategoryProviderTests)
                          .Assembly.GetCustomAttributes()
                          .OfType<AssemblyMetadataAttribute>()
                          .FirstOrDefault(z => z.Key == "FontAwesomeFamilysJson");
            Skip.If(filePath?.Value is null, "FontAwesomeFamilysJson is not set");
            return filePath.Value;
        }
    }

    private static string ApiKey
    {
        get
        {
            var apiKey = Environment.GetEnvironmentVariable("FONT_AWESOME_API_KEY");
            Skip.If(apiKey is null, "FONT_AWESOME_API_KEY is not set");
            return apiKey;
        }
    }

    public static IEnumerable<object[]> GetIconsFromIconFamilies()
    {
        return FontFamilies is null ? [] : ReturnMemberData(FontFamilies, new GetIconsFromIconFamilies.Request(FontFamilies, true));
    }

    public static IEnumerable<object[]> GetIconsFromRelease(string faVersion)
    {
        return ReturnMemberData(faVersion, new GetIconsFromRelease.Request(faVersion));
    }

    public static IEnumerable<object[]> GetIconsFromKit(string kit)
    {
        return ReturnMemberData(kit, new GetIconsFromKit.Request(kit));
    }

    private static readonly ConcurrentDictionary<string, ImmutableArray<IconModel>> _cache = new();
    private static string TempDirectory { get; } = Path.Combine(Path.GetTempPath(), ".fat");

    private static IEnumerable<object[]> ReturnMemberData(string key, IRequest<ImmutableArray<IconModel>> request)
    {
        if (_cache.TryGetValue(key, out var result))
            return YieldIcons(result);

        result = RequestData(request);
        _cache.TryAdd(key, result);
        if (!Directory.Exists(TempDirectory)) Directory.CreateDirectory(TempDirectory);
        return YieldIcons(result);

        static ImmutableArray<IconModel> RequestData(IRequest<ImmutableArray<IconModel>> request)
        {
            var iconsTask = Send(request);
            iconsTask.Wait();
            var icons = iconsTask.Result;

            return
            [
                ..icons
                 .GroupBy(z => ( z.Family, z.Style, Size: z.Id.Split('-').Length ))
                 .SelectMany(z => z.Take(5)),
            ];
        }

        static IEnumerable<object[]> YieldIcons(ImmutableArray<IconModel> icons)
        {
            foreach (var iconGroup in icons
                                     .OrderBy(z => z.Id)
                                     .GroupBy(z => (z.Family, z.Style, Size: z.Id.Split('-').Length))
                                     .Select(z => (z.Key.Family, z.Key.Style, z.Key.Size, Icons: z.Take(2).ToFrozenSet()))
                                     .Where((_, i) => i % 2 == 1)
                    )
            {
                // 2 is svg mode
                yield return [iconGroup.Family, iconGroup.Style, iconGroup.Size, new IconsCollection(iconGroup.Icons), true,];
                yield return [iconGroup.Family, iconGroup.Style, iconGroup.Size, new IconsCollection(iconGroup.Icons), false,];
            }
        }
    }


    private static async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var host = Host
                  .CreateDefaultBuilder()
                  .ConfigureRocketSurgery()
                  .ConfigureServices((_, collection) => collection.AddSingleton(new FontAwesomeApiKeyProvider { ApiKey = ApiKey, }))
                  .Build();
        await host.StartAsync();
        var mediator = host.Services.GetRequiredService<IMediator>();
        return await mediator.Send(request);
    }

    private static async IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request)
    {
        var host = Host
                  .CreateDefaultBuilder()
                  .ConfigureRocketSurgery()
                  .ConfigureServices((_, collection) => collection.AddSingleton(new FontAwesomeApiKeyProvider { ApiKey = ApiKey, }))
                  .Build();
        await host.StartAsync();
        var mediator = host.Services.GetRequiredService<IMediator>();
        await foreach (var item in mediator.CreateStream(request))
        {
            yield return item;
        }
    }

    public class IconsCollection(FrozenSet<IconModel> icons) : IEnumerable<IconModel>
    {
        public static implicit operator ImmutableArray<IconModel>(IconsCollection collection)
        {
            return [.. collection,];
        }

        public override string ToString()
        {
            return icons.First().Id;
        }

        public IEnumerator<IconModel> GetEnumerator()
        {
            return icons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return icons.GetEnumerator();
        }
    }
}
