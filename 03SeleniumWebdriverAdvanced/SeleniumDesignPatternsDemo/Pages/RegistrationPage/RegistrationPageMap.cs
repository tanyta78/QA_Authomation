using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement Title
        {
            get
            {
                
                return this.Driver.FindElement(By.TagName("title"));
            }
        }

        public IWebElement Header
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("entry-title"));
            }
        }

        public IWebElement FirstName
        {
            get
            {
                return this.Driver.FindElement(By.Id("name_3_firstname"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.Driver.FindElement(By.Id("name_3_lastname"));
            }
        }

        public List<IWebElement> MartialStatus
        {
            get
            {
                return this.Driver.FindElements(By.Name("radio_4[]")).ToList();
            }
        }

        public List<IWebElement> Hobbys
        {
            get
            {
                return this.Driver.FindElements(By.Name("checkbox_5[]")).ToList();
            }
        }

        private IWebElement CountryDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("dropdown_7"));
            }
        }

        public SelectElement CountryOption
        {
            get
            {
                return new SelectElement(CountryDD);
            }
        }

        private IWebElement MounthDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("mm_date_8"));
            }
        }

        public SelectElement MounthOption
        {
            get
            {
                return new SelectElement(MounthDD);
            }
        }

        private IWebElement DayDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("dd_date_8"));
            }
        }

        public SelectElement DayOption
        {
            get
            {
                return new SelectElement(DayDD);
            }
        }

        private IWebElement YearDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("yy_date_8"));
            }
        }

        public SelectElement YearOption
        {
            get
            {
                return new SelectElement(YearDD);
            }
        }

        public IWebElement Phone
        {
            get
            {
                return this.Driver.FindElement(By.Id("phone_9"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return this.Driver.FindElement(By.Id("username"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("email_1"));
            }
        }

        public IWebElement UploadButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("profile_pic_10"));
            }
        }

        public IWebElement Description
        {
            get
            {
                return this.Driver.FindElement(By.Id("description"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("password_2"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("confirm_password_password_2"));
            }
        }
        public IWebElement SubmitButton
        {
            get
            {
                return this.Driver.FindElement(By.Name("pie_submit"));
            }
        }

        public IWebElement SuccessMessage
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("piereg_message"));
            }
        }

        public IWebElement ErrorMessagesForRequiredNames
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));
            }
        }

        public IWebElement ErrorMessagesForRequiredPhone
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForRequiredHobbies
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span"));
            }
        }

        public IWebElement ErrorMessagesForRequiredUserName
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForRequiredPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForConfirmPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span"));
            }
        }



        public IWebElement ErrorMessagesForInvalidEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForPasswordLength
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForMismatchPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"piereg_passwordStrength\"]")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"piereg_passwordStrength\"]"));
            }
        }
    }
}
