﻿using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace Make.Utility
{
    internal static class CommandLineApplicationExtensions
    {
        public static void OnExecuteShowHelp(this CommandLineApplication app)
        {
            app.OnExecute(() =>
            {
                app.ShowHelp();
                return 1;
            });
        }

        public static CommandLineApplication WithExecute(this CommandLineApplication app, Func<Task<int>> f)
        {
            app.OnExecute(f);
            return app;
        }
        
        public static CommandLineApplication WithExecuteShowingHelp(this CommandLineApplication app)
        {
            app.OnExecuteShowHelp();
            return app;
        } 
        
        public static CommandLineApplication WithCommand(this CommandLineApplication app, string name, Action<CommandLineApplication> f)
        {
            app.Command(name, f);
            return app;
        }
    }
}