using System.Collections.Immutable;
using System.ComponentModel;
using FluentValidation;
using MediatR;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Conventions.CommandLine;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Rocket.Surgery.Blazor.FontAwesome.Tool.Commands;

internal class EmitCommand : AsyncCommand<EmitCommand.Settings>
{
    private readonly FontAwesomeApiKeyProvider _apiKeyProvider;
    private readonly IMediator _mediator;

    public EmitCommand(FontAwesomeApiKeyProvider apiKeyProvider, IMediator mediator)
    {
        _apiKeyProvider = apiKeyProvider;
        _mediator = mediator;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        _apiKeyProvider.ApiKey = settings.ApiKey!;

        ImmutableArray<IconModel> icons;

        CategoryProvider categoryProvider;
        if (settings is { Categories: { Length: > 0, } categoriesFile, })
        {
            await using var stream = File.OpenRead(categoriesFile);
            categoryProvider = CategoryProvider.Create(stream);
        }
        else
        {
            categoryProvider = CategoryProvider.CreateDefault();
        }

        CategoryProvider.Instance = categoryProvider;

        if (settings is { FilePath.Length: > 0, })
        {
            throw new NotImplementedException();
        }

        if (settings is { KitName.Length: > 0, })
        {
            var request = new GetIconsFromKit.Request(settings.KitName);
            var response = await _mediator.Send(request);
            icons = response;
        }

        else if (settings is { Release.Length: > 0, })
        {
            var request = new GetIconsFromRelease.Request(settings.Release);
            var response = await _mediator.Send(request);
            icons = response;
        }
        else
        {
            throw new("not sure how this happened... validation!");
        }

        var fileContents = _mediator.CreateStream(new GetFileContentForIcons.Request(icons, settings.Namespace, settings.SvgMode));
        await foreach (var item in fileContents)
        {
            AnsiConsole.MarkupLine($"[bold]Writing[/] {item.FileName}");
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(settings.Output, item.FileName))!);
            await File.WriteAllTextAsync(Path.Combine(settings.Output, item.FileName), item.Content);
        }

        return 0;
    }

    public override ValidationResult Validate(CommandContext context, Settings settings)
    {
        return new SettingsValidator().Validate(settings) is { IsValid: false, } result
            ? ValidationResult.Error(result.ToString())
            : ValidationResult.Success();
    }

    private class SettingsValidator : AbstractValidator<Settings>
    {
        public SettingsValidator()
        {
            When(
                z => z.Categories is { Length: > 0, },
                () => RuleFor(x => x.Categories)
                   .Must(File.Exists)
            );
            When(
                z => z.FilePath is { Length: > 0, },
                () =>
                {
                    RuleFor(x => x.FilePath)
                       .Must(File.Exists);
                    RuleFor(z => z.KitName).Null();
                    RuleFor(z => z.Release).Null();
                }
            );
            When(
                z => z.KitName is { Length: > 0, },
                () =>
                {
                    RuleFor(z => z.ApiKey).NotNull().NotEmpty();
                    RuleFor(z => z.FilePath).Null();
                    RuleFor(z => z.Release).Null();
                }
            );
            When(
                z => z.Release is { Length: > 0, },
                () =>
                {
                    RuleFor(z => z.ApiKey).NotNull().NotEmpty();
                    RuleFor(z => z.FilePath).Null();
                    RuleFor(z => z.KitName).Null();
                }
            );
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

        [Description("The namespace you wish to have the generated code in, defaults to Rocket.Surgery.Blazor.FontAwesome6")]
        [CommandOption("--namespace")]
        public string Namespace { get; init; } = "Rocket.Surgery.Blazor.FontAwesome6";

        [Description("Emit icons without svg content")]
        [CommandOption("--no-svg")]
        public bool NoSvg { get; init; }

        [Description("the folder to emit the files to, defaults to the current directory")]
        [CommandOption("--output")]
        public string Output { get; init; } = Directory.GetCurrentDirectory();

        [Description("The path to the categories.yml file for providing category aliases")]
        [CommandOption("--categories")]
        public string? Categories { get; init; }

        public bool SvgMode => !NoSvg;
    }
}