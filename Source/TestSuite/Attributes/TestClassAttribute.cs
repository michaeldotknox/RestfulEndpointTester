using System;

namespace TestSuite.Attributes
{
    /// <summary>
    /// Applies to a class and indicates that the class contains tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TestClassAttribute : Attribute
    {
    }
}
