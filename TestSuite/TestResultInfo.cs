using System;
using TestSuite.Enums;

namespace TestSuite
{
    public class TestResultInfo
    {
        public string ClassName { get; set; }
        public string TestName { get; set; }
        public TestResult Result { get; set; }
        public Exception Exception { get; set; }
    }
}
