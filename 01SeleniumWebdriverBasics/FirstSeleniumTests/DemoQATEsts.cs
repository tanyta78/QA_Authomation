using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumTests
{
    [TestFixture]
    public class DemoQATests
    {
        [Test]
        public void RegisterWithValidData()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.demoqa.com/";
            
            IWebElement regButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]"));
            regButton.Click();

            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Tanya");

            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Petrova");

            var martialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            martialStatus.Click();

            List<IWebElement> hobbies = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbies[0].Click();
            hobbies[1].Click();

            SelectOption(driver,"dropdown_7", "Bulgaria");
            SelectOption(driver,"mm_date_8", "3");
            SelectOption(driver,"dd_date_8", "3");
            SelectOption(driver,"yy_date_8", "1978");
            IWebElement phonenumber = driver.FindElement(By.Id("phone_9"));
            Type(phonenumber, "3597878787878");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "tanyta");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "cir@abv.bg");

            //IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
           // uploadPicButton.Click();
            //driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\Pc\Downloads\eee.jpg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Family Wars: Question: Popular movie with Schwarzenegger? Answer correct:ROKI");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();
            IWebElement registrationMessage = driver.FindElement(By.ClassName("piereg_message"));

            Assert.IsTrue(regButton.Displayed);
            Assert.AreEqual("Thank you for your registration", registrationMessage.Text);
            


            driver.Quit();

        }

        private void SelectOption(IWebDriver driver,string selector,string text)
        {
           
            var dropDown= driver.FindElement(By.Id(selector));
            SelectElement countryOption = new SelectElement(dropDown);
            countryOption.SelectByText(text);
        }

        private void Type(IWebElement element,string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        [Test]
        public void CheckAlertMassageWhenTryToRegisterWithUnvalidData()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.demoqa.com/";

            IWebElement regButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]"));
            regButton.Click();
            //do not insert any data
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();

            IWebElement namesRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));
            Assert.AreEqual("* This field is required", namesRequired.Text);
            
            IWebElement passwordRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            Assert.AreEqual("* This field is required", passwordRequired.Text);

            IWebElement hobbyRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span"));
            Assert.AreEqual("* This field is required", hobbyRequired.Text);

            IWebElement userNameRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span"));
            Assert.AreEqual("* This field is required", userNameRequired.Text);

            //insert invalid data
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "cir125");
            IWebElement phonenumber = driver.FindElement(By.Id("phone_9"));
            Type(phonenumber, "357");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "12349");
            submitButton.Click();

            IWebElement validEmailRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));
            Assert.AreEqual("* Invalid email address", validEmailRequired.Text);

            IWebElement validPhoneRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));
            Assert.AreEqual("* Minimum 10 Digits starting with Country Code", validPhoneRequired.Text);

            IWebElement passwordLengthRequired = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            Assert.AreEqual("* Minimum 8 characters required", passwordLengthRequired.Text);

            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "023456789");
            Type(password, "123456789");
            submitButton.Click();

            IWebElement passwordMismatch = driver.FindElement(By.XPath("//*[@id=\"piereg_passwordStrength\"]"));
            Assert.IsTrue(passwordMismatch.Displayed);

            Assert.AreEqual("Mismatch", passwordMismatch.Text);

        }
    }
}
