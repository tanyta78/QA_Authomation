using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
   public partial class SortablePage
    {
        public IWebElement ItemOne
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[1]"));
            }
        }

        public IWebElement ItemTwo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[2]"));
            }
        }

        public IWebElement ItemThree
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[3]"));
            }
        }

        public IWebElement ItemFour
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[4]"));
            }
        }

        public IWebElement ItemFive
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[5]"));
            }
        }

        public IWebElement ItemSix
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[6]"));
            }
        }

        public IWebElement ItemSeven
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[7]"));
            }
        }

        public IWebElement ItemOneConnectedDefault
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable1\"]/li[1]"));
            }
        }
        public IWebElement ItemOneConnectedHighlight
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable2\"]/li[1]"));
            }
        }

       
    }
}
