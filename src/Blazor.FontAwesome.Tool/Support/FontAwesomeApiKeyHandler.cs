using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Support;

internal class FontAwesomeApiKeyHandler(FontAwesomeApiKeyProvider apiKeyProvider) : DelegatingHandler
{
    private AccessTokenResult? _accessTokenResult;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_accessTokenResult is null || _accessTokenResult.ExpiresAt.AddMinutes(2) < DateTimeOffset.UtcNow)
            _accessTokenResult = await GetAccessToken(cancellationToken);

        request.Headers.Authorization = new("Bearer", _accessTokenResult.AccessToken);
        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<AccessTokenResult> GetAccessToken(CancellationToken cancellationToken)
    {
        using var client = new HttpClient()
        {
            DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher
        };
        var response = await client.SendAsync(
            new(HttpMethod.Post, "https://api.fontawesome.com/token")
            {
                Headers = { Authorization = new("Bearer", apiKeyProvider.ApiKey) },
            },
            cancellationToken
        );
        var result = await response.Content.ReadFromJsonAsync<AccessTokenResponse>(cancellationToken: cancellationToken);

        return new()
        {
            AccessToken = result!.AccessToken,
            ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(result.ExpiresIn)
        };
    }

    class AccessTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; init; }
    }
}
