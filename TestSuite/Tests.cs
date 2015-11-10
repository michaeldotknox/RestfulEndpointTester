﻿using System;
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

        private Tests(List<TestClass> tests)
        {
            _tests = tests;
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
                        Tests = testClass.GetMethods().Where(m => m.GetCustomAttribute<TestAttribute>() != null),
                        PreTest = testClass.GetMethods().FirstOrDefault(m => m.GetCustomAttribute<PreTestAttribute>() != null),
                        PostTest = testClass.GetMethods().FirstOrDefault(m => m.GetCustomAttribute<PostTestAttribute>() != null)
                    });
                }
            }

            return new Tests(tests);
        }

        public async Task<ResultInfo> Run()
        {
            var testResults = new List<TestResultInfo>();

            foreach (var type in _tests)
            {
                var testClass = type.Assembly.CreateInstance(type.Type.ToString());
                foreach (var test in type.Tests)
                {
                    var testResult = await ExecuteTest(test, type.PreTest, type.PostTest, testClass);
                    testResults.Add(testResult);
                }
            }

            var testsResult = new ResultInfo
            {
                TotalTests = _tests.Sum(type => type.Tests.Count()),
                TestInfo = testResults,
                TestsFailed = testResults.Count(x => x.Result == TestResult.Fail),
                TestsPassed = testResults.Count(x => x.Result == TestResult.Pass),
                TestsNotRun = testResults.Count(x => x.Result == TestResult.NotRun)
            };
            return testsResult;
        }

        private static async Task<TestResultInfo> ExecuteTest(MethodInfo test, MethodInfo preTest, MethodInfo postTest, object testClass)
        {
            var testResult = new TestResultInfo {ClassName = testClass.GetType().Name ,TestName = test.Name, Result = TestResult.NotRun};
            var tasks = new List<Task>();
            try
            {
                if (preTest != null)
                {
                    tasks.Add((Task) preTest.Invoke(testClass, new object[] {}));
                }
                tasks.Add((Task) test.Invoke(testClass, new object[] {}));
                if (postTest != null)
                {
                    tasks.Add((Task) postTest.Invoke(testClass, new object[] {}));
                }
                testResult.Result = TestResult.Pass;

                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                testResult.Result = TestResult.Fail;
                testResult.Exception = e;
            }
            return testResult;
        }
    }
}
