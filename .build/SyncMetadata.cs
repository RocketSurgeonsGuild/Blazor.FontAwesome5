using System.Collections.Immutable;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Git;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
using Rocket.Surgery.Nuke.DotNetCore;
using Serilog;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.Npm.NpmTasks;

public partial class Pipeline
{
    [Parameter]
    public string FontAwesomeToken { get; set; }

    public Target LintFiles => d => d
                                   .Executes(
                                        () =>
                                        {
                                            var a = this
                                                   .CastAs<ICanDotNetFormat>()
                                                   .DotnetFormatMatcher
                                                   .AddExclude(Solution.src.Rocket_Surgery_Blazor_FontAwesome6_Free.Directory)
                                                   .AddExclude(Solution.src.Rocket_Surgery_Blazor_FontAwesome6_Pro.Directory)
                                                   .AddExclude(Solution.src.Rocket_Surgery_Blazor_FontAwesome6_Free_Svg.Directory)
                                                ;
                                        }
                                    )
                                   .Inherit<ICanLint>(z => z.LintFiles);

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

                     var categoryProvider = ( categoriesData.FileExists() )
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
}
