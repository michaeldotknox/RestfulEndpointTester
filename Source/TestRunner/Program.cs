using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RestfulEndpoints;
using RestfulEndpoints.Enums;

namespace TestRunner
{
    public class Program
    {
        static void Main(string[] args)
        {
            string directory = null;
            string filename = null;

            var variables = args.Select(arg => arg.Split(new[] {"="}, StringSplitOptions.None)).ToDictionary(argItem => argItem[0], argItem => argItem[1]);

            if (variables.ContainsKey("directory"))
            {
                var path = variables["directory"];
                directory = Path.GetDirectoryName(Path.GetFullPath(path));
                filename = Path.GetFileName(path);
            }

            var tests = ((directory == null || filename == null) ? Tests.Initialize() : Tests.Initialize(directory, filename)).WithVariables(variables);
            var task = tests.Run();
            Task.WaitAll(task);

            var results = task.Result;

            Console.WriteLine($"{results.TotalTests} tests run");
            Console.WriteLine($"{results.TestsFailed} tests failed");
            Console.WriteLine($"{results.TestsPassed} tests passed");
            Console.WriteLine($"{results.TestsNotRun} tests not run");

            foreach (var test in results.TestInfo)
            {
                Console.Write($"{test.ClassName}:{test.TestName}: ");
                if (test.Result == TestResult.Fail)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = test.Result == TestResult.NotRun ? ConsoleColor.Yellow : ConsoleColor.Green;
                }
                Console.WriteLine(test.Result);
                Console.ResetColor();
                if (test.Result == TestResult.Fail)
                {
                    Console.WriteLine($"{test.TestName}:{test.Exception.Message}");
                }
            }

            if (Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }
    }
}
