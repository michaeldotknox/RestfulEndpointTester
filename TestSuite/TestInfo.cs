using System;
using TestSuite.Enums;

namespace TestSuite
{
    public class TestInfo
    {
        public string Name { get; set; }
        public TestResult Result { get; set; }
        public Exception Exception { get; set; }
    }
}
