using System;

namespace ReflectionTry
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class TestUICategory : Attribute
    {
        public string Name;

        public TestUICategory(string name)
        {
            this.Name = name;
        }
    }
}