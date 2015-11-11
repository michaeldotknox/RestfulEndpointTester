using System;
using System.Runtime.Serialization;

namespace TestSuite
{
    public class ExceptionInfo
    {
        public string MethodName { get; set; }
        public Exception Exception { get; set; }
    }
}
