using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rocket.Surgery.Blazor.FontAwesome.Tool;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
using StrawberryShake;

var host = Host
          .CreateDefaultBuilder(args)
          .ConfigureRocketSurgery(Imports.GetConventions)
          .Build();

await host.RunAsync();
