namespace ReflectionTry
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = false)]
    public class TestUIName : System.Attribute
    {
        public string name;

        public TestUIName(string name)
        {
            this.name = name;
        }
    }
}