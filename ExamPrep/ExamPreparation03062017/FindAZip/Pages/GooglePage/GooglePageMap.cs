using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FindAZip.Pages.GooglePage
{
    public partial class GooglePage
    {
        public IWebElement Search
        {
            get { return this.Driver.FindElement(By.Id("searchboxinput")); }
        }
    }
}
