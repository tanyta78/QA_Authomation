using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDesignPatternsDemo.Pages.SoftUniLoginPage
{
    public partial class SoftUniLoginPage : BasePage
    {
        public SoftUniLoginPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return "http://softuni.bg";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void Login()
        {

        }
    }
}
