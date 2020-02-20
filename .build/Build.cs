using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Rocket.Surgery.Nuke;
using Rocket.Surgery.Nuke.DotNetCore;

[PublicAPI]
[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
[PackageIcon(
    "https://raw.githubusercontent.com/RocketSurgeonsGuild/graphics/master/png/social-square-thrust-rounded.png"
)]
[EnsurePackageSourceHasCredentials("RocketSurgeonsGuild")]
[EnsureGitHooks(GitHook.PreCommit)]
internal class Solution : DotNetCoreBuild, IDotNetCoreBuild
{
    /// <summary>
    /// Support plugins are available for:
    /// - JetBrains ReSharper        https://nuke.build/resharper
    /// - JetBrains Rider            https://nuke.build/rider
    /// - Microsoft VisualStudio     https://nuke.build/visualstudio
    /// - Microsoft VSCode           https://nuke.build/vscode
    /// </summary>
    public static int Main() => Execute<Solution>(x => x.Default);

    private Target Default => _ => _
       .DependsOn(Restore)
       .DependsOn(Build)
       .DependsOn(Test)
       .DependsOn(Pack);

    public Target Restore => _ => _.With(this, DotNetCoreBuild.Restore);

    public Target Build => _ => _.With(this, DotNetCoreBuild.Build);

    public Target Test => _ => _.With(this, DotNetCoreBuild.Test);

    public Target Pack => _ => _.With(this, DotNetCoreBuild.Pack);
}