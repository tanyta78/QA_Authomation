using OpenQA.Selenium;
using SeleniumDesignPatternsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            :base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(FirstName, user.FirstName);
            Type(LastName, user.LastName);
            ClickOnElements(MartialStatus, user.MatrialStatus);
            ClickOnElements(Hobbys, user.Hobbys);
            CountryOption.SelectByText(user.Country);
            MounthOption.SelectByText(user.BirthMonth);
            DayOption.SelectByText(user.BirthDay);
            YearOption.SelectByText(user.BirthYear);
            Type(Phone, user.Phone);
            Type(UserName, user.UserName);
            Type(Email, user.Email);
            
            if (user.Picture!= null || user.Picture != string.Empty)
            {
                UploadButton.Click();
                Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            }
           
            Type(Description, user.Description);
            Type(Password, user.Password);
            Type(ConfirmPassword, user.ConfirmPassword);
            SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, string data)
        {
            var conditions = data.Split(',').Select(int.Parse).ToList();
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i]==1)
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            if (text == null)
            {
                element.SendKeys(string.Empty);
            }
            else
            {
                element.SendKeys(text);
            }
            
        }
    }
}

