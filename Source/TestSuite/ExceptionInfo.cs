using System;

namespace RestfulEndpoints
{
    public class ExceptionInfo
    {
        public string MethodName { get; set; }
        public Exception Exception { get; set; }
    }
}
