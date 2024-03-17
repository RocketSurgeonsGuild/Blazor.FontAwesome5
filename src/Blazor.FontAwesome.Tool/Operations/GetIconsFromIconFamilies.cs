using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;

public static class GetIconsFromIconFamilies
{
    public record Request(string FilePath, bool GetProIcons, CategoryProvider CategoryProvider) : IRequest<ImmutableArray<IconModel>>;

    class Handler : IRequestHandler<Request, ImmutableArray<IconModel>>
    {
        public Handler() { }

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

            return icons
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
                           Aliases = a.IconBase.Aliases.Names.Where(x=>!x.Equals(a.IconBase.Label, StringComparison.OrdinalIgnoreCase)).ToImmutableArray(),
                           Categories = request.CategoryProvider.CategoryLookup[a.Name].ToImmutableHashSet(),
                           Height = a.SvgData.Height,
                           Width = a.SvgData.Width,
                           Id = a.Name,
                           RawFamily = a.Family.ToString(),
                           RawStyle = a.Style.ToString(),
                           PathData = a.SvgData.Path.ValueKind == JsonValueKind.Array ? a.SvgData.Path.EnumerateArray().Select(z => z.GetString()!).ToImmutableArray() : ImmutableArray.Create(a.SvgData.Path.GetString()!),

                           Prefix = ( a.Family, a.Style ) switch
                                    {
                                        (_, Style.Brands)   => "fab",
                                        (Family.Duotone, _) => "fad",
                                        (Family.Classic, _) => $"fa{a.Style.ToString()[..1].ToLowerInvariant()}",
                                        (_, _) =>
                                            $"fa{a.Family.ToString()[..1].ToLowerInvariant()}{a.Style.ToString()[..1].ToLowerInvariant()}",
                                    },
                           LongPrefix = ( a.Family, a.Style ) switch
                                        {
                                            (_, Style.Brands)   => "fa-brands",
                                            (Family.Duotone, _) => "fa-duotone",
                                            (Family.Classic, _) => $"fa-{a.Style.ToString().ToLowerInvariant()}",
                                            (_, _) =>
                                                $"fa-{a.Family.ToString().ToLowerInvariant()} fa-{a.Style.ToString().ToLowerInvariant()}",
                                        },
                       }
                   )
                  .ToImmutableArray();
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
