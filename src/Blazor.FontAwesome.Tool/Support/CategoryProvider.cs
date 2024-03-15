using System.Collections.Frozen;
using System.Collections.Immutable;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

public class CategoryProvider
{
    public static CategoryProvider Create(Stream stream)
    {
        using var reader = new StreamReader(stream);

        return new(
            new DeserializerBuilder()
               .WithNamingConvention(CamelCaseNamingConvention.Instance)
               .Build()
               .Deserialize<CategoryDictionary>(reader.ReadToEnd())
               .ToModels()
        );
    }

    public static CategoryProvider CreateDefault()
    {

        var fileResourceName = typeof(CategoryProvider).Assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith("categories.yml"));
        if (fileResourceName is null)
        {
            return new(Array.Empty<CategoryModel>());
        }

        using var stream = typeof(CategoryProvider).Assembly.GetManifestResourceStream(fileResourceName)!;
        return Create(stream);
    }

    private class CategoryDictionary : Dictionary<string, CategoryModelBase>
    {
        public IEnumerable<CategoryModel> ToModels()
        {
            foreach (var item in this)
            {
                yield return new()
                {
                    Name = item.Key,
                    Icons = ImmutableHashSet.CreateRange(StringComparer.OrdinalIgnoreCase, item.Value.Icons),
                    Label = item.Value.Label,
                };
            }
        }
    }

    private class CategoryModelBase
    {
        public IEnumerable<string> Icons { get; set; }
        public string Label { get; set; }
    }

    private CategoryProvider(IEnumerable<CategoryModel> dictionary)
    {
        var categoryModels = dictionary as CategoryModel[] ?? dictionary.ToArray();
        Categories = categoryModels.ToFrozenDictionary(z => z.Name, z => z, StringComparer.OrdinalIgnoreCase);
        CategoryLookup = categoryModels
                        .SelectMany(z => z.Icons, (z, y) => ( category: z, iconName: y ))
                        .ToLookup(z => z.iconName, z => z.category, StringComparer.OrdinalIgnoreCase);
    }

    public FrozenDictionary<string, CategoryModel> Categories { get; }
    public ILookup<string, CategoryModel> CategoryLookup { get; }
}
