using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QAExamSite.Pages.AllCountriesPage
{
    public partial class AllCountriesPage : BasePage
    {
        public AllCountriesPage(IWebDriver driver) : base(driver)
        {

        }

        public String URL
        {
            get
            {
                return "https://www.countries-ofthe-world.com/all-countries.html";
            }

        }

        public void NavigateTo()
        {

            this.Driver.Navigate().GoToUrl(this.URL);
            this.Driver.Manage().Window.Maximize();

        }


    }
}
