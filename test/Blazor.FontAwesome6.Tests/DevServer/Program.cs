using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Rocket.Surgery.Blazor.FontAwesome6.Tests.DevServer;

/// <summary>
/// Intended for framework test use only.
/// </summary>
public class DevHostServerProgram
{
    /// <summary>
    /// Intended for framework test use only.
    /// </summary>
    public static IHost BuildWebHost(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(config =>
             {
                 var applicationPath = args.SkipWhile(a => a != "--applicationpath").Skip(1).First();
                 var applicationDirectory = Path.GetDirectoryName(applicationPath)!;
                 var name = Path.ChangeExtension(applicationPath, ".staticwebassets.runtime.json");
                 name = !File.Exists(name) ? Path.ChangeExtension(applicationPath, ".StaticWebAssets.xml") : name;

                 var inMemoryConfiguration = new Dictionary<string, string?>
                 {
                     [WebHostDefaults.EnvironmentKey] = "Development",
                     ["Logging:LogLevel:Microsoft"] = "Warning",
                     ["Logging:LogLevel:Microsoft.Hosting.Lifetime"] = "Information",
                     [WebHostDefaults.StaticWebAssetsKey] = name,
                     ["ApplyCopHeaders"] = args.Contains("--apply-cop-headers").ToString()
                 };

                 config.AddInMemoryCollection(inMemoryConfiguration);
                 config.AddJsonFile(Path.Combine(applicationDirectory, "blazor-devserversettings.json"), optional: true, reloadOnChange: true);
             })
            .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStaticWebAssets();
                 webBuilder.UseStartup<Startup>();
             }).Build();
}
