﻿using LanguageExt;

namespace Make.Utility
{
    public static class Parcel
    {
        public static EitherAsync<Error, Unit> RunDev(string projectDirectory, int logLevel)
        {
            return CommandLine.RunToOption($"{Exe(projectDirectory)} {projectDirectory}/index.html --open --log-level {logLevel}");
        }

        public static EitherAsync<Error, Unit> BuildProd(string projectDirectory, string outputDirectory, string cacheDirectory, int logLevel)
        {
            return CommandLine.RunToOption($"{Exe(projectDirectory)} build {projectDirectory}/index.html --out-dir {outputDirectory} --cache-dir {cacheDirectory} --log-level {logLevel}");
        }

        private static string Exe(string projectDirectory)
        {
            return $"{projectDirectory}/node_modules/.bin/parcel";
        }
    }
}