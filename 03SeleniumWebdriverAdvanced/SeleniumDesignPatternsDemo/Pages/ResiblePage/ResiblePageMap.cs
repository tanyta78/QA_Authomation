using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.ResiblePage
{
    public partial class ResiblePage
    {
        public IWebElement ResizeButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizable\"]/div[3]"));
            }
        }

        public IWebElement ResizeWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizable"));
            }
        }

        public IWebElement ResizeButtonAnime
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizableani\"]/div[3]"));
            }
        }

        public IWebElement ResizeWindowAnime
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizableani"));
            }
        }

        public IWebElement ResizeButtonConstrain
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizableani\"]/div[3]"));
            }
        }

        public IWebElement ResizeWindowConstrain
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizableconstrain"));
            }
        }

        public IWebElement WindowContainer
        {
            get
            {
                return this.Driver.FindElement(By.Id("container1"));
            }
        }

    }
}
