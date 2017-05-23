using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.ToolsQAHomePage
{
    public partial class ToolsQAHomePage
    {
        public IWebElement Logo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"page\"]/div[1]/header/div/a/img"));
            }
        }
    }
}
