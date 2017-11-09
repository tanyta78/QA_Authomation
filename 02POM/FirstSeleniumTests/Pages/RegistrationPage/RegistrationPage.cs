using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FirstSeleniumTests.Models;

namespace FirstSeleniumTests.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
           : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
            ClickOnElements(this.MartialStatus, user.MatrialStatus);
            ClickOnElements(this.Hobbys, user.Hobbys);
            this.CountryOption.SelectByText(user.Country);
            this.MounthOption.SelectByText(user.BirthMonth);
            this.DayOption.SelectByText(user.BirthDay);
            this.YearOption.SelectByText(user.BirthYear);
            Type(this.Phone, user.Phone);
            Type(this.UserName, user.UserName);
            Type(this.Email, user.Email);
            this.UploadButton.Click();
            this.Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, List<bool> conditions)
        {
            for (int i = 0; i < conditions.Count - 1; i++)
            {
                if (!conditions[i])
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

    }
}
