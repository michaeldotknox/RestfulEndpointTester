using System;

namespace TestSuite.Attributes
{
    /// <summary>
    /// Applies to methods and indicates that the method is a test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        public TestAttribute()
        {
            
        }
    }
}
