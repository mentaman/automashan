using System;

namespace ReflectionTry
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TestUIName : Attribute
    {
        public string Name;

        public TestUIName(string name)
        {
            this.Name = name;
        }
    }
}