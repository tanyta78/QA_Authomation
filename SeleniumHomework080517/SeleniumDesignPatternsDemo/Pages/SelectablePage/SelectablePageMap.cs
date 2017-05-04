using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
   public partial class SelectablePage
    {
        public IWebElement ItemOne
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[1]"));
            }
        }

        public IWebElement ItemTwo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[2]"));
            }
        }

        public IWebElement ItemThree
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[3]"));
            }
        }

        public IWebElement ItemFour
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[4]"));
            }
        }

        public IWebElement ItemFive
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[5]"));
            }
        }

        public IWebElement ItemSix
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[6]"));
            }
        }

        public IWebElement ItemSeven
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[7]"));
            }
        }

        public IWebElement ItemOneAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[1]"));
            }
        }

        public IWebElement ItemTwoAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[2]"));
            }
        }

        public IWebElement ItemThreeAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[3]"));
            }
        }

        public IWebElement ItemFourAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[4]"));
            }
        }

        public IWebElement ItemFiveAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[5]"));
            }
        }

        public IWebElement ItemSixAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[6]"));
            }
        }

        public IWebElement ItemSevenAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[7]"));
            }
        }

        public IWebElement ItemEightAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[8]"));
            }
        }

        public IWebElement ItemNineAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[9]"));
            }
        }

        public IWebElement ItemTenAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[10]"));
            }
        }

        public IWebElement ItemElevenAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[11]"));
            }
        }

        public IWebElement ItemTwelveAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[12]"));
            }
        }

    }
}
