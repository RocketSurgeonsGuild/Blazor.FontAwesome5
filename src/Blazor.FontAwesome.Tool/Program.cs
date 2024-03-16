using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Blazor.FontAwesome.Tool;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
using StrawberryShake;

var host = Host
          .CreateDefaultBuilder(args)
          .ConfigureRocketSurgery(Imports.GetConventions)
          .ConfigureServices(
               z => z
                   .AddSingleton<FontAwesomeApiKeyProvider>()
                   .AddSingleton<FontAwesomeApiKeyHandler>()
                   .AddFontAwesome(ExecutionStrategy.NetworkOnly)
                   .ConfigureHttpClient(client => client.BaseAddress = new("https://api.fontawesome.com/"), builder => builder.AddHttpMessageHandler<FontAwesomeApiKeyHandler>())
           )
          .Build();

await host.RunAsync();
