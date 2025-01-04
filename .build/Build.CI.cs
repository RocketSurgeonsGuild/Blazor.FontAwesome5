using System.Diagnostics;
using Nuke.Common.CI.GitHubActions;
using Rocket.Surgery.Nuke.ContinuousIntegration;
using Rocket.Surgery.Nuke.GithubActions;
using Rocket.Surgery.Nuke.Jobs;

#pragma warning disable CA1050

[GitHubActionsSteps(
    "ci-ignore",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    On = [RocketSurgeonGitHubActionsTrigger.Push,],
    OnPushTags = ["v*",],
    OnPushBranches = ["master", "main", "next",],
    OnPullRequestBranches = ["master", "main", "next",],
    Enhancements = [nameof(CiIgnoreMiddleware),]
)]
[GitHubActionsSteps(
    "ci",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    On = [RocketSurgeonGitHubActionsTrigger.Push,],
    OnPushTags = ["v*",],
    OnPushBranches = ["master", "main", "next",],
    OnPullRequestBranches = ["master", "main", "next",],
    InvokedTargets = [nameof(Default),],
    Enhancements = [nameof(CiMiddleware),]
)]
[GitHubActionsLint(
    "lint",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = false,
    OnPullRequestTargetBranches = ["master", "main", "next",],
    Enhancements = [nameof(LintStagedMiddleware),]
)]
[CloseMilestoneJob]
[DraftReleaseJob]
[UpdateMilestoneJob]
[PublishNugetPackagesJob("RSG_NUGET_API_KEY", "ci")]
[PrintCIEnvironment]
[UploadLogs]
[TitleEvents]
[ContinuousIntegrationConventions]
[DebuggerDisplay("{DebuggerDisplay,nq}")]
internal partial class Pipeline
{
    public static RocketSurgeonGitHubActionsConfiguration CiIgnoreMiddleware(RocketSurgeonGitHubActionsConfiguration configuration)
    {
        ( (RocketSurgeonsGithubActionsJob)configuration.Jobs[0] ).Steps =
        [
            new RunStep("N/A")
            {
                Run = "echo \"No build required\"",
            },
        ];

        return configuration.IncludeRepositoryConfigurationFiles();
    }

    public static RocketSurgeonGitHubActionsConfiguration CiMiddleware(RocketSurgeonGitHubActionsConfiguration configuration)
    {
        configuration
           .ExcludeRepositoryConfigurationFiles()
           .Jobs.OfType<RocketSurgeonsGithubActionsJob>()
           .First(z => z.Name.Equals("build", StringComparison.OrdinalIgnoreCase))
           .UseDotNetSdks("8.0", "9.0")
           // .ConfigureForGitVersion()
           .ConfigureStep<CheckoutStep>(step => step.FetchDepth = 0)
           .PublishLogs<Pipeline>();
        configuration.Environment["FONT_AWESOME_API_KEY"] = "${{ secrets.FONT_AWESOME_API_KEY }}";

        return configuration;
    }

    public static RocketSurgeonGitHubActionsConfiguration LintStagedMiddleware(RocketSurgeonGitHubActionsConfiguration configuration)
    {
        configuration
           .Jobs.OfType<RocketSurgeonsGithubActionsJob>()
           .First(z => z.Name.Equals("Build", StringComparison.OrdinalIgnoreCase))
           .UseDotNetSdks("8.0", "9.0");
        configuration.Environment["FONT_AWESOME_API_KEY"] = "${{ secrets.FONT_AWESOME_API_KEY }}";

        return configuration;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => ToString();
}
