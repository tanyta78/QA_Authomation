using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FindAZip.Pages.NavigationPage
{
    public partial class NavigationPage
    {
        public IWebElement citiesWithV
        {
            get
            {
                return this.Driver.FindElement(By.XPath(
                    "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[1]/table[5]/tbody/tr/td/a[22]"));
            }
        }
    }
}
