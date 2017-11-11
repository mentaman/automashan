using ClassLibrary2.Elements;
using ReflectionTry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Pages
{
    [TestUICategory("דפים")]
    [TestUIName("דף בית")]
    public class HomePage : IHasNavBar
    {
        public NavBar NavBar
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [TestUIName("כניסה למערכת")]
        public LoginPage LoginToSystem()
        {
            //do something...
            return new LoginPage();
        }

        [TestUIName("צפייה בתמונה")]
        public void ViewImage()
        {
            //do something...
        }
    }
}
