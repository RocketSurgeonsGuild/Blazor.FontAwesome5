using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Rocket.Surgery.Blazor.FontAwesome.Tool.Commands;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.CommandLine;
using Rocket.Surgery.Conventions.DependencyInjection;

using Spectre.Console.Cli;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool;

[ExportConvention]
internal class ToolConvention : ICommandLineConvention, IServiceConvention
{
    public void Register(IConventionContext context, IConfigurator app) => app.AddCommand<EmitCommand>("emit");

    public void Register(IConventionContext context, IConfiguration configuration, IServiceCollection services) => services
        .AddTransient(_ => CategoryProvider.Instance ?? CategoryProvider.CreateDefault())
        .AddSingleton<FontAwesomeApiKeyProvider>()
        .AddSingleton<FontAwesomeApiKeyHandler>()
        .AddFontAwesome()
        .ConfigureHttpClient(
             client => client.BaseAddress = new("https://api.fontawesome.com/"),
             builder => builder.AddHttpMessageHandler<FontAwesomeApiKeyHandler>()
         );
}
