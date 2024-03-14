using System.ComponentModel;
using FluentValidation;
using Rocket.Surgery.Conventions.CommandLine;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Commands;
class EmitCommand : AsyncCommand<EmitCommand.Settings>
{
    private readonly FontAwesomeApiKeyProvider _apiKeyProvider;

    public EmitCommand(FontAwesomeApiKeyProvider apiKeyProvider)
    {
        _apiKeyProvider = apiKeyProvider;
    }

    public async override Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        _apiKeyProvider.ApiKey = settings.ApiKey!;

        return 0;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        return new SettingsValidator().Validate(settings) is { IsValid: false } result ? ValidationResult.Error(result.ToString()) : ValidationResult.Success();
    }

    class SettingsValidator : AbstractValidator<Settings>
    {
        public SettingsValidator()
        {
            When(z => z.FilePath is { Length: > 0 }, () =>
                                                     {
                                                         RuleFor(x => x.FilePath)
                                                            .Must(File.Exists)
                                                            .WithMessage("The file path must exist");
                                                         RuleFor(z => z.KitName).Null();
                                                         RuleFor(z => z.Release).Null();
                                                     });
            When(z => z.KitName is { Length: > 0 }, () =>
                                                    {
                                                        RuleFor(z => z.ApiKey).NotNull().NotEmpty();
                                                        RuleFor(z => z.FilePath).Null();
                                                        RuleFor(z => z.Release).Null();
                                                    });
            When(z => z.Release is { Length: > 0 }, () =>
                                                    {
                                                        RuleFor(z => z.ApiKey).NotNull().NotEmpty();
                                                        RuleFor(z => z.FilePath).Null();
                                                        RuleFor(z => z.KitName).Null();
                                                    });
        }
    }


    public class Settings : AppSettings
    {
        [Description("The ApiKey used to call the font awesome api")]
        [CommandOption("--api-key")]
        public string? ApiKey { get; init; }

        [Description("The file path that points to the locally available icon-families.json")]
        [CommandOption("--file-path")]
        public string? FilePath { get; init; }

        [Description("The name of the kit to emit")]
        [CommandOption("--kit-name")]
        public string? KitName { get; init; }

        [Description("The version of the release to emit")]
        [CommandOption("--release")]
        public string? Release { get; init; }
    }
}
