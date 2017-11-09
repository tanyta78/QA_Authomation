using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System;
using OpenQA.Selenium.Interactions;
using FirstSeleniumTests.Pages.HomePage;
using FirstSeleniumTests.Pages.RegistrationPage;
using FirstSeleniumTests.Models;

namespace FirstSeleniumTests
{
    [TestFixture]
    public class RegistrationInDemoQA
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
        }

        [Test, Property("Priority", 2)]
        [Author("Tanya Milanova")]
        public void NavigateToRegistrationPage()
        {
            var homePage = new HomePage(driver);
            var registrationPage = new RegistrationPage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();
            homePage.RegirstratonButton.Click();

            registrationPage.AssertRegistrationPageIsOpen("Registration");
        }

        //One value check tests

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                          new List<bool>(new bool[] { true, false, false }),
                                                           new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbyErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPhoneNumberLetterOnly()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "fdgfhdfhfg",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPhoneNumberLength()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "0532222",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        //must fail only 10 zero phone
        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPhoneNumberZeroOnly()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "0000000000",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUserNameErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidEmailLettersOnly()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "ssss",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("Invalid email address");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidEmailLetterLetter()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "l@l",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("Invalid email address");
        }


        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidEmailSigns()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "\\e.f.fff @e.w.t",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("Invalid email address");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPasswordLength()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "d@d.ff",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "1234567",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordLengthErrorMessage("Minimum 8 characters required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPassword2Length()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "d@d.ff",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "1234567");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertConfirmPasswordErrorMessage("Fields do not match");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPasswordMatch()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "d@d.ff",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "1234567",
                                                         "12345679");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordMismatchErrorMessage("Mismatch");
        }

        //Two value check tests

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndPhone()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndPhoneAndUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "",
                                                         "",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");
            regPage.AssertUserNameErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndPhoneAndUserNameAndEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "",
                                                         "",
                                                         "",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");
            regPage.AssertUserNameErrorMessage("This field is required");
            regPage.AssertEmailErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndInvalidPhone()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "0532222",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");


            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithoutNameAndInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "tanyta",
                                                         "\\e.f.fff @e.w.t",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");


            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertEmailErrorMessage("Invalid email address");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutHobbyAndInvalidPhone()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Tanya",
                                                         "Milanova",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "0532222",
                                                         "tanyta",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");


            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbyErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "3",
                                                         "1978",
                                                         "3597878787878",
                                                         "",
                                                         "cir@abv.bg",
                                                         @"C:\Users\123\Documents\Rainbow-colored-seahorse.jpg",
                                                         "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI",
                                                         "123456789",
                                                         "123456789");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
           
            regPage.AssertUserNameErrorMessage("This field is required");
        }


        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

       
    }
}
