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

            foreach (var test in results.TestInfo)
            {
                Console.WriteLine($"{test.Name}:{test.Result}");
                if (test.Result == TestResult.Fail)
                {
                    Console.WriteLine($"{test.Name}:{test.Exception.Message}");
                }
            }

            Console.ReadKey();
        }
    }
}
