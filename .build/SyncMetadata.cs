using System.Collections.Immutable;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Humanizer;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.IO;
using Rocket.Surgery.Blazor.FontAwesome.Tool;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Operations;
using Rocket.Surgery.Blazor.FontAwesome.Tool.Support;
using Rocket.Surgery.Hosting;
using Serilog;
using Spectre.Console;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.Tools.Npm.NpmTasks;
using StringBuilder = PrettyCode.StringBuilder;

public partial class Pipeline
{
    [Parameter]
    private string FontAwesomeToken { get; set; }

    private Target RegenerateFromMetadata =>
        _ => _
            .Requires(() => FontAwesomeToken)
            .Executes(
                 async () =>
                 {
                     var stringV = "6";
                     var packageDirectory = TemporaryDirectory / "V6";
                     packageDirectory.CreateDirectory();
                     ( packageDirectory / "package.json" ).WriteAllText("{}");
                     ( packageDirectory / ".npmrc" ).WriteAllText(
                         $@"@fortawesome:registry=https://npm.fontawesome.com/
//npm.fontawesome.com/:_authToken={FontAwesomeToken}"
                     );

                     if (!( TemporaryDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" ).DirectoryExists())
                     {
                         Npm($"install @fortawesome/fontawesome-pro@{stringV} --no-package-lock", packageDirectory);
                     }

                     var iconsData = packageDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" / "metadata" / "icon-families.json";
                     var categoriesData = packageDirectory / "node_modules" / "@fortawesome" / "fontawesome-pro" / "metadata" / "categories.yml";
                     CopyFile(categoriesData, RootDirectory / "src" / "Blazor.FontAwesome.Tool" / "categories.txt");

                     var host = global::Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
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

                     var freeIcons = await mediator.Send(
                         new GetIconsFromIconFamilies.Request(
                             iconsData,
                             false,
                             categoryProvider
                         )
                     );
                     var proIcons = await mediator.Send(
                         new GetIconsFromIconFamilies.Request(
                             iconsData,
                             true,
                             categoryProvider
                         )
                     );
                     {
                         // Free
                         ( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Icons" ).CreateOrCleanDirectory();
                         ( RootDirectory / "src" / "Blazor.FontAwesome6.Free" / "Categories" ).CreateOrCleanDirectory();
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
                         ( RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg" / "Icons" ).CreateOrCleanDirectory();
                         ( RootDirectory / "src" / "Blazor.FontAwesome6.Free.Svg" / "Categories" ).CreateOrCleanDirectory();
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
                         ( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Icons" ).CreateOrCleanDirectory();
                         ( RootDirectory / "src" / "Blazor.FontAwesome6.Pro" / "Categories" ).CreateOrCleanDirectory();
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
                         var fileContents = mediator.CreateStream(new GetFileContentForIcons.Request(icons, @namespace, svgMode, categoryProvider));
                         await foreach (var item in fileContents)
                         {
                             Log.Information("Writing {FileName}", item.FileName);
                             Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(output, item.FileName))!);
                             await File.WriteAllTextAsync(Path.Combine(output, item.FileName), item.Content);
                         }
                     }
                 }
             );
}
