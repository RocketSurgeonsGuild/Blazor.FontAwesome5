using System.Collections.Immutable;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

public record CategoryModel
{
    public required ImmutableHashSet<string> Icons { get; init; } = ImmutableHashSet<string>.Empty;
    public required string Label { get; init; }
    public required string Name { get; init; }

    public virtual bool Equals(CategoryModel? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Label, other.Label, StringComparison.OrdinalIgnoreCase)
         && string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Label, StringComparer.OrdinalIgnoreCase);
        hashCode.Add(Name, StringComparer.OrdinalIgnoreCase);
        return hashCode.ToHashCode();
    }
}
