using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QAExamSite.Pages.IPsPage
{
   public partial class IPsPage
    {

        
        public IWebElement CountryNamesInputElement
        {
            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("/html/body/form/input[1]")));
                
                return this.Driver.FindElement(By.XPath("/html/body/form/input[1]"));
            }
        }

        public IWebElement GenerateBtnElement
        {

            get
            {
                this.Wait.Until(w => w.FindElement(By.XPath("/html/body/form/input[5]")));

                return this.Driver.FindElement(By.XPath("/html/body/form/input[5]"));
            }
        }



    }


}
