using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public partial class SortablePage:BasePage
    {
        public SortablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "sortable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void MoveItemOneToItemFivePosition()
        {
            this.Driver.Url = "http://demoqa.com/sortable/";
            Actions builder = new Actions(this.Driver);
            int yToNewLocation=ItemFive.Location.Y-ItemOne.Location.Y+ItemOne.Size.Height/2;
            var drag = builder.DragAndDropToOffset(ItemOne,0,yToNewLocation);
            drag.Perform();
        }

        public void MoveItemOneToEndPosition()
        {
            this.Driver.Url = "http://demoqa.com/sortable/";
            Actions builder = new Actions(this.Driver);
            int yToNewLocation = ItemSeven.Location.Y - ItemOne.Location.Y + ItemOne.Size.Height/2;
            var drag = builder.DragAndDropToOffset(ItemOne, 0, yToNewLocation);
            drag.Perform();
        }

        public void MoveItemOneToEndPositionConnected()
        {
            this.Driver.Url = "http://demoqa.com/sortable/";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            newTag.Click();
          
            var drag = builder.DragAndDrop(ItemOneConnectedDefault, ItemOneConnectedHighlight);
            drag.Perform();
        }

    }
}
