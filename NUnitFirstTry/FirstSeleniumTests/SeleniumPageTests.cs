using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSeleniumTests
{
    [TestFixture]
    public class SeleniumPageTests
    {
        [Test]
        public void EnterAndSearchGoogle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

           IWebElement searchTextAria= driver.FindElement(By.Id("lst-ib"));
            Type(searchTextAria, "best browser automation tool \"Selenium\"");
            searchTextAria.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement firstLink = wait.Until<IWebElement>((w) => { return w.FindElement(By.CssSelector("#rso > div > div > div:nth-child(1) > div > h3 > a")); });
            
            firstLink.Click();
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);

            driver.Quit();
        }
        [Test]
        public void CheckTitleName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.seleniumhq.org/";
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement title = wait.Until((w) => { return w.FindElement(By.XPath("/html/head/title")); });
            
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);
            driver.Quit();
        }

        [Test]
        public void SoftUniQAAutomationNavCheck()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.softuni.bg";

            var courses = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a/span"));
            courses.Click();
            
            var qaCourse = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/div/div/div/div[2]/div[2]/ul/li[4]/a"));
            qaCourse.Click();

            var headingOne = driver.FindElements(By.XPath("//h1"));
            Assert.AreEqual("Курс QA Automation - март 2017", headingOne[0].Text);
            var headingTwo = driver.FindElements(By.XPath("//h2"));
            bool check = false;
            int count = 0;
            foreach (var item in headingTwo)
            {
                if ("Курс QA Automation - март 2017" == item.Text)
                {
                   check = true;
                   count++;
                }
            }
            Assert.IsTrue(check);
            Assert.AreEqual(count, 1);
            

            driver.Quit();
        }
        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        private void SelectOption(IWebDriver driver, string selector, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var dropDown = wait.Until((w) => { return w.FindElement(By.XPath(selector)); });
            SelectElement dropdownOption = new SelectElement(dropDown);
            dropdownOption.SelectByText(text);
        }

    }
}
