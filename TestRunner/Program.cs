using System;
using System.Threading.Tasks;
using TestSuite;
using TestSuite.Enums;

namespace TestRunner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tests = Tests.Initialize();
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

            Console.ReadKey();
        }
    }
}
