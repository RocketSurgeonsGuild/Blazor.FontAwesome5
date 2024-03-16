using FluentAssertions;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

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
}