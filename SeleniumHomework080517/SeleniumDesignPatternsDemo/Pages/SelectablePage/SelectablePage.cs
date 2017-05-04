using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
   public partial class SelectablePage:BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

      public string URL
        {
            get
            {
                return base.url + "selectable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void SelectItemOne()
        {
            this.Driver.Url = "http://demoqa.com/selectable/";
            Actions builder = new Actions(this.Driver);

            var drag = builder.Click(ItemOne);
            drag.Perform();
        }

        public void SelectMoreItems()
        {
            this.Driver.Url = "http://demoqa.com/selectable/";
            Actions builder = new Actions(this.Driver);

            var hold = builder.ClickAndHold(ItemOne).Release(ItemSeven);
            hold.Perform();
            
        }

        public void SelectMoreItemsAsGrid()
        {
            this.Driver.Url = "http://demoqa.com/selectable/";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            newTag.Click();

            var hold = builder.ClickAndHold(ItemOneAsGrid).Release(ItemTwelveAsGrid);
            hold.Perform();

        }

    }
}
