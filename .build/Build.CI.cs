using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.GitHubActions.Configuration;
using Rocket.Surgery.Nuke.ContinuousIntegration;
using Rocket.Surgery.Nuke.DotNetCore;
using Rocket.Surgery.Nuke.GithubActions;

#pragma warning disable CA1050

[GitHubActionsSteps(
    "ci-ignore",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    On = [RocketSurgeonGitHubActionsTrigger.Push],
    OnPushTags = ["v*"],
    OnPushBranches = ["master", "main", "next"],
    OnPullRequestBranches = ["master", "main", "next"],
    Enhancements = [nameof(CiIgnoreMiddleware)]
)]
[GitHubActionsSteps(
    "ci",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    On = [RocketSurgeonGitHubActionsTrigger.Push],
    OnPushTags = ["v*"],
    OnPushBranches = ["master", "main", "next"],
    OnPullRequestBranches = ["master", "main", "next"],
    InvokedTargets = [nameof(Default)],
    NonEntryTargets =
    [
        nameof(ICIEnvironment.CIEnvironment),
        nameof(ITriggerCodeCoverageReports.TriggerCodeCoverageReports),
        nameof(ITriggerCodeCoverageReports.GenerateCodeCoverageReportCobertura),
        nameof(IGenerateCodeCoverageBadges.GenerateCodeCoverageBadges),
        nameof(IGenerateCodeCoverageReport.GenerateCodeCoverageReport),
        nameof(IGenerateCodeCoverageSummary.GenerateCodeCoverageSummary),
        nameof(Default)
    ],
    ExcludedTargets = [nameof(ICanClean.Clean), nameof(ICanRestoreWithDotNetCore.DotnetToolRestore)],
    Enhancements = [nameof(CiMiddleware)]
)]
[GitHubActionsLint(
    "lint",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    OnPullRequestTargetBranches = ["master", "main", "next"],
    Enhancements = [nameof(LintStagedMiddleware)]
)]
[PrintBuildVersion]
[PrintCIEnvironment]
[UploadLogs]
[TitleEvents]
[ContinuousIntegrationConventions]
[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
public partial class Pipeline
{
    [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
    private string DebuggerDisplay
    {
        get
        {
            return ToString();
        }
    }

    public static RocketSurgeonGitHubActionsConfiguration CiIgnoreMiddleware(RocketSurgeonGitHubActionsConfiguration configuration)
    {
        ( (RocketSurgeonsGithubActionsJob)configuration.Jobs[0] ).Steps =
        [
            new RunStep("N/A")
            {
                Run = "echo \"No build required\""
            }
        ];

        return configuration.IncludeRepositoryConfigurationFiles();
    }

    public static RocketSurgeonGitHubActionsConfiguration CiMiddleware(RocketSurgeonGitHubActionsConfiguration configuration)
    {
        _ = configuration
           .ExcludeRepositoryConfigurationFiles()
           .AddNugetPublish()
           .Jobs.OfType<RocketSurgeonsGithubActionsJob>()
           .First(z => z.Name.Equals("build", StringComparison.OrdinalIgnoreCase))
           .UseDotNetSdks("8.0")
           // .ConfigureForGitVersion()
           .ConfigureStep<CheckoutStep>(step => step.FetchDepth = 0)
           .PublishLogs<Pipeline>();

        return configuration;
    }

    public static RocketSurgeonGitHubActionsConfiguration LintStagedMiddleware(RocketSurgeonGitHubActionsConfiguration configuration)
    {
        _ = configuration
           .Jobs.OfType<RocketSurgeonsGithubActionsJob>()
           .First(z => z.Name.Equals("Build", StringComparison.OrdinalIgnoreCase))
           .UseDotNetSdks("8.0");

        return configuration;
    }
}
