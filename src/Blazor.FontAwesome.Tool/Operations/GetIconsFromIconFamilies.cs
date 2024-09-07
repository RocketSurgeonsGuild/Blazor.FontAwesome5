using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromIconFamilies
{
    public record Request(string FilePath, bool GetProIcons) : IRequest<ImmutableArray<IconModel>>;

    class Handler(CategoryProvider categoryProvider) : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        [RequiresUnreferencedCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(Stream, JsonSerializerOptions)")]
        public async Task<ImmutableArray<IconModel>> Handle(Request request, CancellationToken cancellationToken)
        {
            await using var stream = File.OpenRead(request.FilePath);
            var icons = JsonSerializer.Deserialize<Dictionary<string, IconModelBase>>(
                stream,
                new JsonSerializerOptions()
                {
                    Converters = { new JsonStringEnumConverter<Family>(), new JsonStringEnumConverter<Style>() },
                    PropertyNameCaseInsensitive = true,
                }
            );

            return [
                ..icons
                 .SelectMany(
                      z => ( request.GetProIcons ? z.Value.FamilyStylesByLicense.Pro : z.Value.FamilyStylesByLicense.Free ),
                      (iconBase, familyStyle) => ( Name: iconBase.Key, IconBase: iconBase.Value, Family: familyStyle.Family, Style: familyStyle.Style )
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
                      a => new IconModel()
                      {
                          Label = a.IconBase.Label,
                          Unicode = a.IconBase.Unicode!,
                          Aliases = [..a.IconBase.Aliases.Names.Where(x => !x.Equals(a.IconBase.Label, StringComparison.OrdinalIgnoreCase))],
                          Categories = categoryProvider.CategoryLookup[a.Name].ToImmutableHashSet(),
                          Height = a.SvgData.Height,
                          Width = a.SvgData.Width,
                          Id = a.Name,
                          RawFamily = a.Family.ToString(),
                          RawStyle = a.Style.ToString(),
                          PathData =
                          [
                              ..a.SvgData.Path.ValueKind == JsonValueKind.Array
                                  ? a.SvgData.Path.EnumerateArray().Select(z => z.GetString()!)
                                  : [a.SvgData.Path.GetString()!]
                          ],
                      }
                  )
            ];
        }
    }

    private class IconModelBase
    {
        public string Label { get; set; }
        public FamilyStylesByLicense FamilyStylesByLicense { get; set; } = new FamilyStylesByLicense();
        public string? Unicode { get; set; }
        public IEnumerable<string> Ligatures { get; set; } = Enumerable.Empty<string>();
        public bool Private { get; set; }
        public IconAliases Aliases { get; set; } = new IconAliases();
        public Dictionary<Family, Dictionary<Style, SvgData>> Svgs { get; set; } = new();
    }

    private class FamilyStylesByLicense
    {
        public IEnumerable<FontAwesomeFamilyStyle> Free { get; set; } = Enumerable.Empty<FontAwesomeFamilyStyle>();
        public IEnumerable<FontAwesomeFamilyStyle> Pro { get; set; } = Enumerable.Empty<FontAwesomeFamilyStyle>();
    }

    private class FontAwesomeFamilyStyle
    {
        public Family Family { get; set; }
        public Style Style { get; set; }
    }

    private class SvgData
    {
        public int LastModified { get; set; }
        public string Raw { get; set; }
        public int[] ViewBox { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public JsonElement Path { get; set; }
    }

    class IconAliases
    {
        public IEnumerable<string> Names { get; set; } = Enumerable.Empty<string>();
    }
}
