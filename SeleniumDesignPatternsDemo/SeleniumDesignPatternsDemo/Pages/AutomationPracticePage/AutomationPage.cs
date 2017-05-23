using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDesignPatternsDemo.Pages.AutomationPracticePage
{
    public partial class AutomationPage : BasePage
    {
        public AutomationPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return "http://toolsqa.com/automation-practice-switch-windows/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }
    }
}
