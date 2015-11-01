using System.Collections.Generic;
using System.Reflection;

namespace TestSuite
{
    public class TestClass
    {
        public Assembly Assembly { get; set; }
        public System.Type Type { get; set; }
        public IEnumerable<MethodInfo> Tests { get; set; } 
    }
}
