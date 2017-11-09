using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QAExamSite.Pages.IPsPage
{
    public partial class IPsPage : BasePage
    {
        public IPsPage(IWebDriver driver) : base(driver)
        {

        }

        public String URL
        {
            get
            {
                return "http://services.ce3c.be/ciprg/ ";
            }

        }

        public void NavigateTo()
        {

            this.Driver.Navigate().GoToUrl(this.URL);
            this.Driver.Manage().Window.Maximize();

        }

        public void Type(IWebElement element, string text)
        {
            if (text == null)
            {
                element.Clear();
            }
            else
            {
                element.Clear();
                element.SendKeys(text);
            }

        }

    }
}
