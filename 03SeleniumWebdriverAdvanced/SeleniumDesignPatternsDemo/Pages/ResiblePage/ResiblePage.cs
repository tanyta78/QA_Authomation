using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.ResiblePage
{
    public partial class ResiblePage : BasePage
    {
        private int width;
        private int height;

        public ResiblePage(IWebDriver driver) : base(driver)
        {
        }

       

        public string URL
        {
            get
            {
                return base.url + "resizable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public void IncreaseWidthAndheightBy(int increaseSize)
        {
            this.NavigateTo();
            this.width = this.ResizeWindow.Size.Width;
            this.height = this.ResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.ResizeButton, increaseSize, increaseSize);
            resize.Perform();
        }

        public void AnimateResize(int increaseSize)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            this.width = this.ResizeWindowAnime.Size.Width;
            this.height = this.ResizeWindowAnime.Size.Height;
            var resize = builder.DragAndDropToOffset(this.ResizeButtonAnime, increaseSize, increaseSize);
            resize.Perform();
        }

        public void ConstrainResize(int increaseSize)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            var newTag = this.Driver.FindElement(By.XPath(" //*[@id=\"ui-id-3\"]"));
            newTag.Click();
            this.width = this.ResizeWindowConstrain.Size.Width;
            this.height = this.ResizeWindowConstrain.Size.Height;
            var resize = builder.DragAndDropToOffset(this.ResizeButtonConstrain, increaseSize, increaseSize);
            resize.Perform();
        }

    }
}
