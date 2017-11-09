using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QAExamSite.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait=new WebDriverWait(this.driver,TimeSpan.FromSeconds(5));
        }

        public IWebDriver Driver
        {
            get { return this.driver; }
        }

        public WebDriverWait Wait
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(this.driver,TimeSpan.FromSeconds(20));

                return wait;
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("https://www.countries-ofthe-world.com/");
        }


    }
}
