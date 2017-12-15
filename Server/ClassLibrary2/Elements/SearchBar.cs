using ReflectionTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Elements
{
    public class SearchBar
    {
    }

    public interface IHasSearchBar
    {
        SearchBar Bar { get; }
    }

    public static class SearchBarExtensions
    {
        [TestUIName("חיפוש")]
        public static IHasSearchBar Search(this IHasSearchBar page, string text)
        {
            //do something...
            return page;
        }
    }
}
