using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FindAZip.Pages.ContentPage
{
    public partial class ContentPage
    {
        public IWebElement Name
        {
            get
            {
                return this.Driver.FindElement(By.XPath(
                    "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[1]/td[2]/font/font/b"));
            }
        }

        public IWebElement State
        {
            get
            {
                return this.Driver.FindElement(By.XPath(
                    "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[2]/td[2]/font/b"));
            }
        }

        public IWebElement Zip
        {
            get
            {
                return this.Driver.FindElement(By.XPath(
                    "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[3]/td[2]/font/font/b"));
            }
        }

        public IWebElement Longitude
        {
            get
            {
                return this.Driver.FindElement(By.XPath(
                    "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[8]/td[2]/font/b"));
            }
        }

        public IWebElement Latidude
        {
            get
            {
                return this.Driver.FindElement(By.XPath(
                    "/html/body/table[2]/tbody/tr/td[3]/table[1]/tbody/tr/td/table[2]/tbody/tr/td[3]/table[2]/tbody/tr[3]/td/table/tbody/tr/td/ul/table/tbody/tr[9]/td[2]/font/b"));
            }
        }
    }
}
