using System.Collections.Frozen;
using System.Collections.Immutable;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool;

internal static class Constants
{
    static Constants()
    {
        using var stream = typeof(Constants).Assembly.GetManifestResourceStream(typeof(Constants).Assembly.GetManifestResourceNames().First(x => x.EndsWith("categories.yml")));
        using var reader = new StreamReader(stream);

        Categories = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build()
                        .Deserialize<CategoryDictionary>(reader.ReadToEnd())
                        .ToModels()
                    .SelectMany(z => z.Icons, (z, y) => (category: z, iconName: y))
                        .ToLookup(z => z.iconName, z => z.category, StringComparer.OrdinalIgnoreCase);
    }

    public static ILookup<string, CategoryModel> Categories { get; }

    private class CategoryDictionary : Dictionary<string, CategoryModelBase>
    {
        public IEnumerable<CategoryModel> ToModels()
        {
            foreach (var item in this)
            {
                yield return new()
                {
                    Name = item.Key,
                    Icons = new(item.Value.Icons, StringComparer.OrdinalIgnoreCase),
                    Label = item.Value.Label,
                };
            }
        }
    }
    private  class CategoryModelBase
    {
        public IEnumerable<string> Icons { get; set; }
        public string Label { get; set; }
    }
}

public  class CategoryModel
{
    public HashSet<string> Icons { get; set; } = new();
    public string Label { get; set; }
    public string Name { get; set; }
}
