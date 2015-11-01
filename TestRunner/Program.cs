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

            var exceptions = task.Result;

            foreach (var exception in exceptions)
            {
                Console.WriteLine($"{exception.MethodName}:{exception.Exception.Message}");
            }
        }
    }
}
