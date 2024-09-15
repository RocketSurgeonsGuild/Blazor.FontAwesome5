using System.Collections.Immutable;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.Git;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
using Rocket.Surgery.Nuke.GithubActions;
using Serilog;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.Npm.NpmTasks;

[GitHubActionsSecret("FONT_AWESOME_TOKEN")]
[GitHubActionsSecret("FONT_AWESOME_API_KEY")]
public partial class Pipeline
{
    private static Matcher excludeProjects(Matcher matcher, params Project[] projects)
    {
        foreach (var item in projects)
        {
            _ = matcher.AddExclude(RootDirectory.GetUnixRelativePathTo(item.Directory) + "/**/*.cs");
        }

        return matcher;
    }

    [Parameter]
    public string FontAwesomeToken { get; set; }

    private Target RegenerateFromMetadata =>
        t => t
            .Requires(() => FontAwesomeToken)
            .OnlyWhenStatic(() => !string.IsNullOrWhiteSpace(FontAwesomeToken))
            .TryTriggeredBy<IHaveLintTarget>(a => a.Lint)
            .Executes(
                 async () =>
                 {
                     const string stringV = "6";
                     var packageDirectory = TemporaryDirectory / "V6";
                     _ = packageDirectory.CreateDirectory();
                     _ = ( packageDirectory / "package.json" ).WriteAllText("{}");
                     _ = ( packageDirectory / ".npmrc" )
                        .WriteAllText(
                             $"""
                             @fortawesome:registry=https://npm.fontawesome.com/
                             //npm.fontawesome.com/:_authToken={FontAwesomeToken}
                             """
                         );

                     if (!( TemporaryDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" ).DirectoryExists())
                     {
                         _ = Npm($"install @fortawesome/fontawesome-pro@{stringV} --no-package-lock", packageDirectory);
                     }

                     var iconsData = packageDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" / "metadata" / "icon-families.json";
                     var categoriesData = packageDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" / "metadata" / "categories.yml";
                     CopyFile(categoriesData, RootDirectory / "src" / "Blazor.FontAwesome.Tool" / "categories.txt", FileExistsPolicy.Overwrite);

                     var categoryProvider = categoriesData.FileExists()
                         ? CategoryProvider.Create(File.OpenRead(categoriesData))
                         : CategoryProvider.CreateDefault();
                     var host = Microsoft
                               .Extensions.Hosting.Host.CreateDefaultBuilder()
                               .ConfigureRocketSurgery(Imports.GetConventions)
                               .ConfigureServices((_, collection) => collection.AddSingleton(categoryProvider))
                               .Build();
                     await host.StartAsync();

                     var mediator = host.Services.GetRequiredService<IMediator>();

                     // free
                     // free svg
                     // pro

                     var freeIcons = await mediator.Send(new GetIconsFromIconFamilies.Request(iconsData, false));
                     var proIcons = await mediator.Send(new GetIconsFromIconFamilies.Request(iconsData, true));
                     // ReSharper disable InvokeAsExtensionMethod
                     {
                         // Free
                         await writeFileContents(
                             mediator,
                             freeIcons,
                             false,
                             "Rocket.Surgery.Blazor.FontAwesome6.Free",
                             RootDirectory / "src" / "Blazor.FontAwesome6.Free"
                         );
                     }

                     {
                         // Free SVG
                         await writeFileContents(
                             mediator,
                             freeIcons,
                             true,
                             "Rocket.Surgery.Blazor.FontAwesome6.Free.Svg",
                             RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg"
                         );
                     }

                     {
                         await writeFileContents(
                             mediator,
                             proIcons,
                             false,
                             "Rocket.Surgery.Blazor.FontAwesome6.Pro",
                             RootDirectory / "src" / "Blazor.FontAwesome6.Pro"
                         );
                     }
                     // ReSharper enable InvokeAsExtensionMethod

                     {
                         // No Pro SVG because it's not free
                     }


                     static async Task writeFileContents(
                         IMediator mediator,
                         ImmutableArray<IconModel> icons,
                         bool svgMode,
                         string @namespace,
                         AbsolutePath output
                     )
                     {
                         _ = output.CreateDirectory();
                         _ = ( output / "Icons" ).CreateOrCleanDirectory();
                         _ = ( output / "Categories" ).CreateOrCleanDirectory();

                         var fileContents = mediator.CreateStream(new GetFileContentForIcons.Request(icons, @namespace, svgMode));
                         await foreach (var item in fileContents)
                         {
                             var fileOutputPath = output / item.FileName;
                             Log.Information("Writing {FileName}", fileOutputPath);
                             _ = fileOutputPath.WriteAllText(item.Content);
                         }

                         _ = GitTasks.Git($"add {RootDirectory.GetRelativePathTo(output)}");
                     }
                 }
             );

    // need a better way to do this
    public Matcher LintMatcher => new Matcher(StringComparison.OrdinalIgnoreCase)
                                 .AddInclude("**/*")
                                 .AddExclude("**/node_modules/**/*")
                                 .AddExclude(".idea/**/*")
                                 .AddExclude(".vscode/**/*")
                                 .AddExclude(".nuke/**/*")
                                 .AddExclude("**/bin/**/*")
                                 .AddExclude("**/obj/**/*")
                                 .AddExclude("**/*.g.*")
                                 .AddExclude("**/*.verified.*")
                                 .AddExclude("**/*.received.*");
}
