using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Blazor.FontAwesome.Tool;
using Rocket.Surgery.Hosting;
using StrawberryShake;

var host = Host
          .CreateDefaultBuilder(args)
          .ConfigureRocketSurgery(Imports.GetConventions)
          .ConfigureServices(
               z => z
                   .AddSingleton<FontAwesomeApiKeyProvider>()
                   .AddFontAwesome(ExecutionStrategy.NetworkOnly)
                   .ConfigureHttpClient(client => client.BaseAddress = new("https://api.fontawesome.com/"))
           )
          .Build();

await host.StartAsync();

class FontAwesomeApiKeyProvider
{
    public required string ApiKey { get; set; }
}
