using System;

namespace TestSuite.Attributes
{
    /// <summary>
    /// Applies to methods and indicates that the method is a test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        public Action PreTestAction { get; private set; } 
        public Action PostTestAction { get; private set; } 
         
        public TestAttribute()
        {
            
        }

        public TestAttribute(Action preTestAction = null, Action postTestAction = null)
        {
            PreTestAction = preTestAction;
            PostTestAction = postTestAction;
        }
    }
}
