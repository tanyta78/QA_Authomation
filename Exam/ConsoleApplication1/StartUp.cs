using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using QAExamSite.Pages.AllCountriesPage;
using QAExamSite.Pages.AllEuropeCountries;
using QAExamSite.Pages.FlagPage;
using QAExamSite.Pages.IPsPage;

namespace QAExamSite
{
    public class Program
    {
        public static void Main()
        {

            // ChromeOptions options = new ChromeOptions();
            //  options.AddExtension(@"..\..\Extension\AdBlock_v3.10.0.crx");

            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.countries-ofthe-world.com/");

            //take all countries names
            AllCountriesPage countriesPage = new AllCountriesPage(driver);
            countriesPage.NavigateTo();


            var countryList = new List<string>();

            foreach (var countryElement in countriesPage.AllContriesList)
            {
                var currentText = countryElement.Text;
                countryList.Add(currentText);
            }

            //take europe countries names
            EuropeCountriesPage europe = new EuropeCountriesPage(driver);
            europe.NavigateTo();

            //make correct list for urls
            List<string> differentNames = new List<string>();

            var europeCountryList = new List<string>();
            foreach (var country in europe.AllEuropeContriesList)
            {
                var currentText = country.Text;
                switch (currentText)
                {
                    case "Bosnia and Herzegovina": currentText = "bosnia-and-herzegovina"; break;
                    case "Czech Republic": currentText = "the-czech-republic"; break;
                    case "Macedonia (FYROM)": currentText = "macedonia"; break;
                    case "Netherlands": currentText = "the-netherlands"; break;
                    case "United Kingdom (UK)": currentText = "the-united-kingdom"; break;
                    case "Vatican City (Holy See)": currentText = "the-vatican-city"; break;
                    case "San Marino": currentText = "san-marino"; break;
                }

                europeCountryList.Add(currentText);
            }

            //create urls list
            var urlList = new List<string>();
            foreach (var country in europeCountryList.Where(c => c.Length > 2))
            {
                var currentText = @"http://flagpedia.net/" + country;
                urlList.Add(currentText);
            }

            //scroll down and take screenshot foreach europe country
            foreach (var url in urlList)
            {
                FlagPage flag = new FlagPage(driver);
                driver.Navigate().GoToUrl(url);

                IAction scrollDown = new Actions(driver)
                    .MoveToElement(flag.FooterElement) // position mouse over scrollbar
                    .ClickAndHold()
                    .MoveByOffset(0, 450) // scroll down
                    .Release()
                    .Build();

                scrollDown.Perform();


                //{countryName}-{CapitalName}-{Code}.jpg
                var countryName = flag.CountryName.Text;
                var CapitalName = flag.CountryCapital.Text;
                var Code = flag.CountryCode.Text;
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                var location = @"..\..\Screenshots\";
                var filename = $"{countryName}-{CapitalName}-{Code}.jpg";
                var filenameJpg = location + filename;
                screenshot.SaveAsFile(filenameJpg, ScreenshotImageFormat.Jpeg);
            }

            //go to http://services.ce3c.be/ciprg/ 
            //Get all IP Ranges for all European countries 

            IPsPage ipPage = new IPsPage(driver);
            ipPage.NavigateTo();

            foreach (var country in europeCountryList.Where(c => c.Length > 2))
            {
                ipPage.Type(ipPage.CountryNamesInputElement, country);
                ipPage.GenerateBtnElement.Click();


                string DataDirectory = @"..\..\CountryIP\";
                string PageSourceHTML = driver.PageSource;

                string fileName = $"{country}.txt";
                System.IO.File.WriteAllText(DataDirectory + fileName, PageSourceHTML);


                driver.Navigate().Back();
            }

            driver.Quit();
        }


    }
}
