using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using Humanizer;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromIconFamilies
{
    public record Request(string FilePath, bool GetProIcons) : IRequest<ImmutableArray<IconModel>>;

    private class Handler(CategoryProvider categoryProvider) : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        [RequiresUnreferencedCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(Stream, JsonSerializerOptions)")]
        public async Task<ImmutableArray<IconModel>> Handle(Request request, CancellationToken cancellationToken)
        {
            await using var stream = File.OpenRead(request.FilePath);
            var icons = JsonSerializer.Deserialize<Dictionary<string, IconModelIntermediate>>(
                                           stream,
                                           new JsonSerializerOptions
                                           {
                                               Converters =
                                               {
                                                   new JsonStringEnumConverter<Family>(JsonNamingPolicy.KebabCaseLower),
                                                   new JsonStringEnumConverter<Style>(JsonNamingPolicy.KebabCaseLower),
                                               },
                                               PropertyNameCaseInsensitive = true,
                                           }
                                       )!
                                      .ToDictionary(
                                           z => z.Key,
                                           z => new IconModelBase
                                           {
                                               Label = z.Value.Label,
                                               FamilyStylesByLicense = z.Value.FamilyStylesByLicense,
                                               Unicode = z.Value.Unicode,
                                               Ligatures = [..z.Value.Ligatures,],
                                               Private = z.Value.Private,
                                               Aliases = z.Value.Aliases,
                                               Svgs = parseDictionary(z.Value.Svgs),
                                           }
                                       );


            return
            [
                ..icons
                 .SelectMany(
                      z => request.GetProIcons ? z.Value.FamilyStylesByLicense.Pro : z.Value.FamilyStylesByLicense.Free,
                      (iconBase, familyStyle) => ( Name: iconBase.Key, IconBase: iconBase.Value, familyStyle.Family, familyStyle.Style )
                  )
                 .Select(
                      z =>
                      {
                          if (z.IconBase.Svgs.TryGetValue(z.Family, out var f) && f.TryGetValue(z.Style, out var s))
                          {
                              return ( z.Name, z.IconBase, z.Family, z.Style, SvgData: s );
                          }

                          return ( z.Name, z.IconBase, z.Family, z.Style, SvgData: null! );
                      }
                  )
                 .Where(z => z.SvgData != null!)
                 .Select(
                      a => new IconModel
                      {
                          Label = a.IconBase.Label,
                          Unicode = a.IconBase.Unicode!,
                          Aliases = [..a.IconBase.Aliases.Names.Where(x => !x.Equals(a.IconBase.Label, StringComparison.OrdinalIgnoreCase)),],
                          Categories = categoryProvider.CategoryLookup[a.Name].ToImmutableHashSet(),
                          Height = a.SvgData.Height,
                          Width = a.SvgData.Width,
                          Id = a.Name,
                          RawFamily = a.Family.ToString(),
                          RawStyle = a.Style.ToString(),
                          PathData =
                          [
                              ..a.SvgData.Path.ValueKind switch
                                {
                                    JsonValueKind.Array  => a.SvgData.Path.EnumerateArray().Select(z => z.GetString()!),
                                    JsonValueKind.String => [a.SvgData.Path.GetString()!,],
                                    _                    => [],
                                }
                          ],
                      }
                  ),
            ];

            static ImmutableDictionary<Family, ImmutableDictionary<Style, SvgData>> parseDictionary(Dictionary<string, Dictionary<string, SvgData>> dictionary)
            {
                return dictionary.ToImmutableDictionary(
                    static x => Enum.Parse<Family>(x.Key.Dehumanize(), true),
                    static x => x.Value.ToImmutableDictionary(
                        static y => Enum.Parse<Style>(y.Key.Dehumanize(), true),
                        static y => y.Value
                    )
                );
            }
        }
    }

    [PublicAPI]
    private class IconModelIntermediate
    {
        public string Label { get; set; }
        public FamilyStylesByLicense FamilyStylesByLicense { get; set; } = new();
        public string? Unicode { get; set; }
        public IEnumerable<string> Ligatures { get; set; } = [];
        public bool Private { get; set; }
        public IconAliases Aliases { get; set; } = new();
        public Dictionary<string, Dictionary<string, SvgData>> Svgs { get; set; } = new();
    }

    [PublicAPI]
    private record IconModelBase
    {
        public required string Label { get; init; }
        public required FamilyStylesByLicense FamilyStylesByLicense { get; init; } = new();
        public required string? Unicode { get; init; }
        public required ImmutableArray<string> Ligatures { get; init; } = [];
        public required bool Private { get; init; }
        public required IconAliases Aliases { get; init; } = new();
        public required ImmutableDictionary<Family, ImmutableDictionary<Style, SvgData>> Svgs { get; init; }
    }

    [PublicAPI]
    private class FamilyStylesByLicense
    {
        public ImmutableArray<FontAwesomeFamilyStyle> Free { get; set; } = [];
        public ImmutableArray<FontAwesomeFamilyStyle> Pro { get; set; } = [];
    }

    [PublicAPI]
    private class FontAwesomeFamilyStyle
    {
        public Family Family { get; set; }
        public Style Style { get; set; }
    }

    [PublicAPI]
    private class SvgData
    {
        public int LastModified { get; set; }
        public string Raw { get; set; }
        public int[] ViewBox { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public JsonElement Path { get; set; }
    }

    [PublicAPI]
    private record IconAliases
    {
        public ImmutableArray<string> Names { get; set; } = [];
    }
}
