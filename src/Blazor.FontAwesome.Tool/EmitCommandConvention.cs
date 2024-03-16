using Rocket.Surgery.Blazor.FontAwesome.Tool.Commands;
using Rocket.Surgery.Conventions;
using Rocket.Surgery.Conventions.CommandLine;
using Spectre.Console.Cli;

[ExportConvention]
class EmitCommandConvention : ICommandLineConvention
{
    public void Register(IConventionContext context, IConfigurator app)
    {
        app.AddCommand<EmitCommand>("emit");
    }
}
