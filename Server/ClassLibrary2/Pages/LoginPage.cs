using ReflectionTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Pages
{
    [TestUICategory("דפים")]
    [TestUIName("דף כניסה למערכת")]
    public class LoginPage
    {
        [TestUIName("התחבר")]
        public HomePage Login(string username)
        {
            //do something...
            return new HomePage();
        }
    }
}
