﻿using LanguageExt;
using Make.Utility.Commands.Executables;

namespace Make.Utility.Commands
{
    public static class Dotnet
    {
        public static EitherAsync<Error, Unit> Publish(string projectDirectory, string configuration, string verbosity, string outputDirectory)
        {
            return Executable.RunAsEither($"dotnet publish {projectDirectory} --configuration {configuration} --output {outputDirectory} --verbosity {verbosity}");
        }

        public static EitherAsync<Error, Unit> Test(string projectDirectory, string configuration, string verbosity, string outputDirectory, string resultDirectory, string resultsFileName)
        {
            return Executable.RunAsEither($"dotnet test {projectDirectory} --configuration {configuration} --output {outputDirectory} --results-directory {resultDirectory} --verbosity {verbosity} --logger trx;logfilename={resultsFileName}.xml");
        }

        public static EitherAsync<Error, Unit> Clean(string projectDirectory, string configuration, string verbosity)
        {
            return Executable.RunAsEither($"dotnet clean {projectDirectory} --configuration {configuration} --verbosity {verbosity}");
        }

        public static EitherAsync<Error, Unit> TestWatch(string projectDirectory, ExecutionOptions options)
        {
            return Executable.RunAsEither(options, $"dotnet watch -p {projectDirectory} test");
        }

        public static EitherAsync<Error, Unit> RunWatch(string projectDirectory, ExecutionOptions options)
        {
            return Executable.RunAsEither(options, $"dotnet watch -p {projectDirectory} run");
        }
    }
}