using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestSuite.Attributes;
using TestSuite.Enums;

namespace TestSuite
{
    public class Tests
    {
        private readonly List<TestClass> _tests;
        private readonly List<ExceptionInfo> _exceptions; 

        private Tests(List<TestClass> tests)
        {
            _tests = tests;
            _exceptions = new List<ExceptionInfo>();
        }
         
        public static Tests Initialize()
        {
            var tests = new List<TestClass>();
            foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
            {
                var assembly = Assembly.LoadFile(file);
                var testClasses = assembly.GetTypes().Where(t => t.GetCustomAttribute<TestClassAttribute>() != null);
                foreach (var testClass in testClasses)
                {
                    tests.Add(new TestClass
                    {
                        Assembly = assembly,
                        Type = testClass,
                        Tests = testClass.GetMethods().Where(m => m.GetCustomAttribute<TestAttribute>() != null)
                    });
                }
            }

            return new Tests(tests);
        }

        public static Tests Initialize(string serverName)
        {
            throw new NotImplementedException();
        }

        public static Tests Initialize(Methods method, string serverName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExceptionInfo>> Run()
        {
            foreach (var type in _tests)
            {
                var testClass = type.Assembly.CreateInstance(type.Type.ToString());
                foreach (var test in type.Tests)
                {
                    try
                    {
                        var result = (Task)test.Invoke(testClass, new object[] {});
                        await result;
                    }
                    catch (Exception e)
                    {
                        _exceptions.Add(new ExceptionInfo {MethodName = test.Name, Exception = e});
                    }
                }
            }

            return _exceptions;
        }
    }
}
