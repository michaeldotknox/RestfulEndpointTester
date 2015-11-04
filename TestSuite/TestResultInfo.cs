using System;
using TestSuite.Enums;

namespace TestSuite
{
    public class TestResultInfo
    {
        public string Name { get; set; }
        public TestResult Result { get; set; }
        public Exception Exception { get; set; }
    }
}
