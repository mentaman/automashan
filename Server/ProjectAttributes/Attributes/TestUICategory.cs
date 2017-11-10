namespace ReflectionTry
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Method, AllowMultiple = false)]
    public class TestUiCategory : System.Attribute
    {
        public string name;

        public TestUiCategory(string name)
        {
            this.name = name;
        }
    }
}