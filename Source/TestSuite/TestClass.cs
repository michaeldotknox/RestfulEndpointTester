using System.Collections.Generic;
using System.Reflection;

namespace RestfulEndpoints
{
    public class TestClass
    {
        public Assembly Assembly { get; set; }
        public System.Type Type { get; set; }
        public IEnumerable<MethodInfo> Tests { get; set; } 
        public MethodInfo PreTest { get; set; } 
        public MethodInfo PostTest { get; set; } 
    }
}
