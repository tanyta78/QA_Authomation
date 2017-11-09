using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QAExamSite.Pages.FlagPage
{
    public partial class FlagPage : BasePage
    {
        public FlagPage(IWebDriver driver) : base(driver)
        {

        }

       
        public void NavigateTo(string url)
        {

            this.Driver.Navigate().GoToUrl(url);
            this.Driver.Manage().Window.Maximize();

        }


    }
}
