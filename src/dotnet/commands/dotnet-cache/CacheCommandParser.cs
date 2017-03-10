// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using Microsoft.DotNet.Cli.CommandLine;
using Microsoft.DotNet.Tools.Cache;

namespace Microsoft.DotNet.Cli
{
    internal static class CacheCommandParser
    {
        public static Command Cache() =>
            Create.Command(
                LocalizableStrings.AppFullName,
                LocalizableStrings.AppDescription,
                Accept.ZeroOrMoreArguments,
                CommonOptions.HelpOption(),
                Create.Option(
                    "-e|--entries",
                    LocalizableStrings.ProjectEntryDescription,
                    Accept.ExactlyOneArgument
                        .With(name: LocalizableStrings.ProjectEntries)
                        .Forward()),
                CommonOptions.FrameworkOption(),
                Create.Option(
                    "--framework-version",
                    LocalizableStrings.FrameworkVersionOptionDescription,
                    Accept.ExactlyOneArgument
                        .With(name: LocalizableStrings.FrameworkVersionOption)
                        .ForwardAs(o => $"/p:FX_Version={o.Arguments.Single()}")),
                CommonOptions.RuntimeOption(),
                CommonOptions.ConfigurationOption(),
                Create.Option(
                    "-o|--output",
                    LocalizableStrings.OutputOptionDescription,
                    Accept.ExactlyOneArgument
                        .With(name: LocalizableStrings.OutputOption)
                        .ForwardAs(o => $"/p:ComposeDir={o.Arguments.Single()}")),
                Create.Option(
                    "-w |--working-dir",
                    LocalizableStrings.IntermediateWorkingDirOptionDescription,
                    Accept.ExactlyOneArgument
                        .With(name: LocalizableStrings.IntermediateWorkingDirOption)
                        .ForwardAs(o => $"/p:ComposeWorkingDir={o.Arguments.Single()}")),
                Create.Option(
                    "--preserve-working-dir",
                    LocalizableStrings.PreserveIntermediateWorkingDirOptionDescription,
                    Accept.NoArguments
                        .ForwardAs(o => $"/p:PreserveComposeWorkingDir=true")),
                Create.Option(
                    "--skip-optimization",
                    LocalizableStrings.SkipOptimizationOptionDescription,
                    Accept.NoArguments
                          .ForwardAs("/p:SkipOptimization=true")),
                CommonOptions.VerbosityOption());
    }
}