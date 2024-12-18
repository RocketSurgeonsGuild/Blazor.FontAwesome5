using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.MSBuild;
using Rocket.Surgery.Nuke.DotNetCore;

[PublicAPI]
[UnsetVisualStudioEnvironmentVariables]
[PackageIcon("https://raw.githubusercontent.com/RocketSurgeonsGuild/graphics/master/png/social-square-thrust-rounded.png")]
[EnsureGitHooks(GitHook.PreCommit)]
[DotNetVerbosityMapping]
[MSBuildVerbosityMapping]
[NuGetVerbosityMapping]
[ShutdownDotNetAfterServerBuild]
[LocalBuildConventions]
internal partial class Pipeline : NukeBuild,
                                ICanRestoreWithDotNetCore,
                                ICanBuildWithDotNetCore,
                                ICanTestWithDotNetCore,
                                ICanPackWithDotNetCore,
                                ICanClean,
                                IHaveCommonLintTargets,
                                // IHavePublicApis,
                                IGenerateCodeCoverageReport,
                                IGenerateCodeCoverageSummary,
                                IGenerateCodeCoverageBadges,
                                IHaveConfiguration<Configuration>
{
    /// <summary>
    ///     Support plugins are available for:
    ///     - JetBrains ReSharper        https://nuke.build/resharper
    ///     - JetBrains Rider            https://nuke.build/rider
    ///     - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///     - Microsoft VSCode           https://nuke.build/vscode
    /// </summary>
    public static int Main() => Execute<Pipeline>(x => x.Default);

    [NonEntryTarget]
    private Target Default => _ => _
                                  .DependsOn(Restore)
                                  .DependsOn(Build)
                                  .DependsOn(Test)
                                  .DependsOn(Pack);

    public Target Build => _ => _;
    public Target Pack => _ => _;
    public Target Clean => _ => _;
    public Target Lint => _ => _;
    public Target Restore => _ => _;
    public Target Test => _ => _;

    /// <summary>
    /// Only run the JetBrains cleanup code when running on the server
    /// </summary>
    public Target JetBrainsCleanupCode => _ => _
                                              .Inherit<ICanDotNetFormat>(x => x.JetBrainsCleanupCode)
                                              .OnlyWhenStatic(() => IsServerBuild);

    [Solution(GenerateProjects = true)] private Solution Solution { get; } = null!;
    Nuke.Common.ProjectModel.Solution IHaveSolution.Solution => Solution;

    [OptionalGitRepository] public GitRepository? GitRepository { get; }
    [GitVersion(NoFetch = true, NoCache = false)] public GitVersion GitVersion { get; } = null!;
    [Parameter("Configuration to build")] public Configuration Configuration { get; } = IsLocalBuild ? Configuration.Debug : Configuration.Release;
}
