using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement RegirstratonButton
        {
            get
            {
                return this.Driver.FindElement(By.PartialLinkText("Registration"));
            }
        }
    }
}
