﻿using System.Collections.Generic;
using System.Linq;

namespace Make.Configuration
{
    public class DotnetConfig
    {
        // q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic]
        public string Verbosity => "m";
        public string Configuration => "release";

        public DotnetProject Project => new[] { "Web" }
            .Select(name => new DotnetProject(name, $"src/server/{name}"))
            .First();

        public IEnumerable<DotnetProject> TestProjects => new[] { "WebTests" }
            .Select(name => new DotnetProject(name, $"test/server/{name}"));
    }
}