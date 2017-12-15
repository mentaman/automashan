using ClassLibrary2.Pages;
using ClassLibrary2.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTry
{
    [TestUIName("Awesome page")]
    public class MyPage
    {
        public Element GetSomeElement()
        {
            return new Element();
        }
    }

    public class Element
    {
    }

    public class Program
    {
        public static void PrintData(Data data, int idx = 0)
        {
            Console.WriteLine(String.Concat(Enumerable.Repeat("     ", idx))+data.ResultType.Name+"->"+data.Name);
            if (data.CanContinue)
            {
                foreach (var indata in data.GetContinue())
                {
                    PrintData(indata, idx + 1);
                }
            }
        }
        public static void Main(string[] args)
        {
            var t = new ClassData(true, typeof(MyPage));
            //return new LineOfCode(new List<Data>() { new ClassData(true, typeof(MyPage)), new  })
            PrintData(t);
            /*foreach (var c in GetClasses())
            {
                Console.WriteLine(c.Name);
            }*/
            HomePage homePage = new HomePage();

            Console.ReadLine();
        }
        static List<Type> GetClasses()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            List<Type> classlist = new List<Type>();

            foreach (Type type in asm.GetTypes())
            {
                /*var classdata = new ClassData() {Name = type.Name, Type = type, Functions = GetFunctions(type)};
                var attributes = type.GetCustomAttributes(true);
                var nameattr = attributes.OfType<TestUIName>().FirstOrDefault();
                if (nameattr != null)
                {
                    classdata.Name = nameattr.name;
                }*/
                classlist.Add(type);
            }


            return classlist;
        }
        
    }
}
