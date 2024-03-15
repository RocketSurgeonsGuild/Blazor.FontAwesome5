namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

internal class AccessTokenResult
{
    public required string AccessToken { get; init; }
    public DateTimeOffset ExpiresAt { get; init; }
}
