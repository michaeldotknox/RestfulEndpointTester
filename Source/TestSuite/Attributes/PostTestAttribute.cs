using System;

namespace RestfulEndpoints.Attributes
{
    /// <summary>
    /// Applies to methods and indicates that the method will run after each test
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class PostTestAttribute : Attribute
    {
    }
}
