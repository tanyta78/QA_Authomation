using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
   public partial class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "draggable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop(int pixelsToMove)
        {
            this.Driver.Url = "http://demoqa.com/draggable/";
            Actions builder = new Actions(this.Driver);

            var drag = builder.DragAndDropToOffset(this.Source,pixelsToMove,pixelsToMove);
            drag.Perform();
        }

        public void DragAndDropVertical(int pixelsToMove)
        {
            this.Driver.Url = "http://demoqa.com/draggable/";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var drag = builder.DragAndDropToOffset(this.SourceVertical, pixelsToMove, pixelsToMove);
            drag.Perform();
        }

        public void DragAndDropHorizontal(int pixelsToMove)
        {
            this.Driver.Url = "http://demoqa.com/draggable/";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var drag = builder.DragAndDropToOffset(this.SourceHorizont, pixelsToMove, pixelsToMove);
            drag.Perform();
        }

        public void DragAndDropInContainer(int pixelsToMove)
        {
            this.Driver.Url = "http://demoqa.com/draggable/";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var drag = builder.DragAndDropToOffset(this.SourseContained, pixelsToMove, pixelsToMove);
            drag.Perform();
        }

        public void DragAndDropInParentContainer(int pixelsToMove)
        {
            this.Driver.Url = "http://demoqa.com/draggable/";
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var drag = builder.DragAndDropToOffset(this.SourseParentContained, pixelsToMove, pixelsToMove);
            drag.Perform();
        }
    }
}
