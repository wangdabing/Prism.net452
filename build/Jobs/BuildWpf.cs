﻿using System.Collections.Generic;
using AvantiPoint.Nuke.Maui.CI;

namespace DevOps.Jobs;

class BuildWpf : CIBuild
{
    public override PullRequestTrigger OnPull => new PullRequestTrigger
    {
        Branches = new[] { "master" },
        IncludePaths = new[]
        {
            ".github/workflows/build_forms.yml",
            "Directory.Build.props",
            "Directory.Build.targets",
            "Packages.props",
            "xunit.runner.json",
            "src/Prism.Core/**",
            "tests/Prism.Core.Tests/**",
            "src/Wpf/**",
            "tests/Wpf/**"
        }
    };

    public override IEnumerable<ICIStage> Stages => new[]
    {
        new CIStage
        {
            Jobs = new []
            {
                new PullRequestJob("Prism.Wpf", "PrismLibrary_Wpf.slnf")
            }
        }
    };
}
