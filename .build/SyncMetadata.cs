using System.Collections.Immutable;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nuke.Common;
using Nuke.Common.IO;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
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
                                            _ = this.CastAs<ICanLint>().LintMatcher
                                                .AddExclude(Solution.src.Rocket_Surgery_Blazor_FontAwesome6_Free.Directory)
                                                .AddExclude(Solution.src.Rocket_Surgery_Blazor_FontAwesome6_Pro.Directory)
                                                .AddExclude(Solution.src.Rocket_Surgery_Blazor_FontAwesome6_Free_Svg.Directory)
                                                 ;
                                        })
                                   .Inherit<ICanLint>(z => z.LintFiles);

    private Target RegenerateFromMetadata =>
        _ => _
            .Requires(() => FontAwesomeToken)
            .Executes(
                 async () =>
                 {
                     const string stringV = "6";
                     var packageDirectory = TemporaryDirectory / "V6";
                     _ = (ITargetDefinition)packageDirectory.CreateDirectory();
                     _ = (ITargetDefinition)( packageDirectory / "package.json" ).WriteAllText("{}");
                     _ = (ITargetDefinition)( packageDirectory / ".npmrc" ).WriteAllText(
                         $@"@fortawesome:registry=https://npm.fontawesome.com/
//npm.fontawesome.com/:_authToken={FontAwesomeToken}"
                     );

                     if (!( TemporaryDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" ).DirectoryExists())
                     {
                         _ = (ITargetDefinition)Npm($"install @fortawesome/fontawesome-pro@{stringV} --no-package-lock", packageDirectory);
                     }

                     var iconsData = packageDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" / "metadata" / "icon-families.json";
                     var categoriesData = packageDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" / "metadata" / "categories.yml";
                     CopyFile(categoriesData, RootDirectory / "src" / "Blazor.FontAwesome.Tool" / "categories.txt", FileExistsPolicy.Overwrite);

                     var host = Microsoft
                               .Extensions.Hosting.Host.CreateDefaultBuilder()
                               .ConfigureRocketSurgery(Imports.GetConventions)
                               .Build();
                     await host.StartAsync();
                     CategoryProvider categoryProvider;
                     if (categoriesData.FileExists())
                     {
                         await using var stream = File.OpenRead(categoriesData);
                         categoryProvider = CategoryProvider.Create(stream);
                     }
                     else
                     {
                         categoryProvider = CategoryProvider.CreateDefault();
                     }

                     var mediator = host.Services.GetRequiredService<IMediator>();

                     // free
                     // free svg
                     // pro

                     var freeIcons = await mediator.Send(new GetIconsFromIconFamilies.Request(iconsData, false));
                     var proIcons = await mediator.Send(new GetIconsFromIconFamilies.Request(iconsData, true));
                     {
                         // Free
                         _ = (ITargetDefinition)( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Icons" ).CreateOrCleanDirectory();
                         _ = (ITargetDefinition)( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Categories" ).CreateOrCleanDirectory();
                         await writeFileContents(
                             mediator,
                             freeIcons,
                             false,
                             "Rocket.Surgery.Blazor.FontAwesome6.Free",
                             RootDirectory / "src" / "Blazor.FontAwesome6.Free",
                             categoryProvider
                         );
                     }

                     {
                         _ = (ITargetDefinition)( RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg" / "Icons" ).CreateOrCleanDirectory();
                         _ = (ITargetDefinition)( RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg" / "Categories" ).CreateOrCleanDirectory();
                         // Free SVG
                         await writeFileContents(
                             mediator,
                             freeIcons,
                             true,
                             "Rocket.Surgery.Blazor.FontAwesome6.Free.Svg",
                             RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg",
                             categoryProvider
                         );
                     }

                     {
                         _ = (ITargetDefinition)( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Icons" ).CreateOrCleanDirectory();
                         _ = (ITargetDefinition)( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Categories" ).CreateOrCleanDirectory();
                         // Pro
                         await writeFileContents(
                             mediator,
                             proIcons,
                             false,
                             "Rocket.Surgery.Blazor.FontAwesome6.Pro",
                             RootDirectory / "src" / "Blazor.FontAwesome6.Pro",
                             categoryProvider
                         );
                     }

                     {
                         // No Pro SVG because it's not free
                     }

                     static async Task writeFileContents(
                         IMediator mediator,
                         ImmutableArray<IconModel> icons,
                         bool svgMode,
                         string @namespace,
                         string output,
                         CategoryProvider categoryProvider
                     )
                     {
                         var fileContents = mediator.CreateStream(new GetFileContentForIcons.Request(icons, @namespace, svgMode));
                         await foreach (var item in fileContents)
                         {
                             Log.Information("Writing {FileName}", item.FileName);
                             _ = Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(output, item.FileName))!);
                             await File.WriteAllTextAsync(Path.Combine(output, item.FileName), item.Content);
                         }
                     }
                 }
             );
}
