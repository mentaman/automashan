using ReflectionTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Elements
{
    public class NavBar : IHasSearchBar
    {
        public SearchBar Bar
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    public interface IHasNavBar
    {
        NavBar NavBar { get; }
    }

    public static class NavBarExtensions
    {
        [TestUIName("בר ניווט")]
        public static IHasNavBar NavBar(this IHasNavBar page)
        {
            //do something...
            return page;
        }
    }
}
