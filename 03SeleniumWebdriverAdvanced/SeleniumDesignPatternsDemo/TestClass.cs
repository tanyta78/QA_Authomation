using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.HomePage;
using SeleniumDesignPatternsDemo.Pages.RegistrationPage;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using NUnit.Framework.Interfaces;

namespace SeleniumWebDriverFirstTests
{
    [TestFixture]
    public class RegisterInDemoQA
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            //this.driver = new InternetExplorerDriver();
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }
            this.driver.Quit();

            //If you use Internet Explorer and browser don't close after test
            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.Start();
            //
            //cmd.StandardInput.WriteLine("taskkill /F /IM iexplore.exe");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        [Test, Property("Priority", 2)]
        [Author("Ventsislav Ivanov")]
        public void NavigateToRegistrationPage()
        {
            var homePage = new HomePage(driver);
            var registrationPage = new RegistrationPage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();
            homePage.RegirstratonButton.Click();

            registrationPage.AssertRegistrationPageIsOpen("Registration");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutName()
        {
            var regPage = new RegistrationPage(driver);

            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);
            regPage.AssertNamesErrorMessage("This field is required");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutHobby");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertHobbyErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);
            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPhoneNumberLetterOnly()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidPhoneNumberLetterOnly");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPhoneNumberLength()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidPhoneNumberLength");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        //BUG FOUND must fail only 10 zero phone
        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPhoneNumberZeroOnly()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidPhoneNumberZeroOnly");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutUserName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertUserNameErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertEmailErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidEmailLettersOnly()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidEmailLettersOnly");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertEmailErrorMessage("Invalid email address");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidEmailLetterLetter()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidEmailLetterLetter");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertEmailErrorMessage("Invalid email address");
        }


        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidEmailSigns()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidEmailSigns");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertEmailErrorMessage("Invalid email address");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPasswordLength()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidPasswordLength");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertPasswordLengthErrorMessage("Minimum 8 characters required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPassword2Length()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidPassword2Length");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertConfirmPasswordErrorMessage("Fields do not match");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithInvalidPasswordMatch()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithInvalidPasswordMatch");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertPasswordMismatchErrorMessage("Mismatch");
        }

        //Two value check tests

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndPhone()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutNameAndPhone");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndPhoneAndUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutNameAndPhoneAndUserName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");
            regPage.AssertUserNameErrorMessage("This field is required");
        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndPhoneAndUserNameAndEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutNameAndPhoneAndUserNameAndEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

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
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutNameAndInvalidPhone");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithoutNameAndInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithoutNameAndInvalidEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertNamesErrorMessage("This field is required");
            regPage.AssertEmailErrorMessage("Invalid email address");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutHobbyAndInvalidPhone()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutHobbyAndInvalidPhone");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertHobbyErrorMessage("This field is required");
            regPage.AssertPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test, Property("Priority", 3)]
        [Author("Tanya Milanova")]
        public void RegistrateWithOutNameAndUserName()
        {
            var regPage = new RegistrationPage(this.driver);
            var RegUser = AccessExcelData.GetTestDataTwo("RegistrateWithOutNameAndUserName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(RegUser);

            regPage.AssertNamesErrorMessage("This field is required");

            regPage.AssertUserNameErrorMessage("This field is required");
        }
    }
}

