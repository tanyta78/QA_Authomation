using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public partial class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "droppable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop()
        {
            this.Driver.Url = "http://demoqa.com/droppable/";
            Actions builder = new Actions(this.Driver);
            
            var drag = builder.DragAndDrop(this.Source, this.Target);
            drag.Perform();
        }

        public void DragAndDropAccept()
        {
            this.Driver.Url = "http://demoqa.com/droppable/#tab2";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
           
            var drag = builder.DragAndDrop(this.DragAccept, this.TargetToDrop);
            drag.Perform();
        }

        public void DragAndDropNotAccept()
        {
            this.Driver.Url = "http://demoqa.com/droppable/#tab2";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();

            var drag = builder.DragAndDrop(this.DragNonValid, this.TargetToDrop);
            drag.Perform();
        }

        public void DragAndDropPropagationNotGreedy()
        {
            this.Driver.Url = "http://demoqa.com/droppable/#tab2";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-3\"]"));
            newTag.Click();

            var drag = builder.DragAndDrop(this.SourceToDrop, this.TargetNotGreedy);
            drag.Perform();
        }

        public void DragAndDropPropagationGreedy()
        {
            this.Driver.Url = "http://demoqa.com/droppable/#tab2";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-3\"]"));
            newTag.Click();

            var drag = builder.DragAndDrop(this.SourceToDrop, this.TargetGreedy);
            drag.Perform();
        }
    }
}
