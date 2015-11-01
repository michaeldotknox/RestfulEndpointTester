using System;
using System.Threading.Tasks;
using TestSuite;

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
            }
        }
    }
}
