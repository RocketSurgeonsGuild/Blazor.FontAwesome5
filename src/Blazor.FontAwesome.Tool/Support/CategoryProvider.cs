using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Diagnostics;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public sealed class CategoryProvider
{
    public static CategoryProvider? Instance { get; internal set; }

    public static CategoryProvider Create(Stream stream)
    {
        using var reader = new StreamReader(stream);

        return new(
            new DeserializerBuilder()
               .WithNamingConvention(HyphenatedNamingConvention.Instance)
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

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => ToString();

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
        [YamlMember(Alias = "icons")]
        public IEnumerable<string> Icons { get; } = null!;

        [YamlMember(Alias = "label")]
        public string Label { get; } = null!;
    }
}