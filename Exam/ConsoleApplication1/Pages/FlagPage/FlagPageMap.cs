using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QAExamSite.Pages.FlagPage
{
   public partial class FlagPage
    {

        public IWebElement FooterElement
        {
            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"footer\"]/p/a")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"footer\"]/p/a"));
            }
        }

        
        public IWebElement WhereCountryIsElement
        {
            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"content\"]/h2[5]")));
                
                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/h2[5]"));
            }
        }

        public IWebElement CountryName
        {
            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[2]")));

                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[2]"));
            }
        }

        public IWebElement CountryCapital
        {
            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[3]")));

                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[3]"));
            }
        }

        public IWebElement CountryCode
        {
            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[10]")));

                return this.Driver.FindElement(By.XPath("//*[@id=\"content\"]/dl[1]/dd[10]"));
            }
        }

        


    }


}
