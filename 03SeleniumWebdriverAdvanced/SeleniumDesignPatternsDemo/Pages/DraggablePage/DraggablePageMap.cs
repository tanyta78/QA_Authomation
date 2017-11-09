using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
   public partial class DraggablePage
    {
        public IWebElement Source
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggable\"]/p"));
            }
        }

        public IWebElement SourceVertical
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggabl\"]/p"));
            }
        }

        public IWebElement SourceHorizont
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggabl2\"]/p"));
            }
        }

        public IWebElement Container
        {
            get
            {
                return this.Driver.FindElement(By.Id("containment-wrapper"));
            }
        }

        public IWebElement SourseContained
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"draggabl3\"]/p")); }
        }

       

        public IWebElement ParentContainer
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"containment-wrapper\"]/div[2]"));
            }
        }

        public IWebElement SourseParentContained
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"draggabl5\"]")); }
        }
    }
}
