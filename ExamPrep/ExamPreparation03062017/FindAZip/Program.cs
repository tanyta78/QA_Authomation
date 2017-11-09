using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using FindAZip.Models;
using FindAZip.Pages.ContentPage;
using FindAZip.Pages.GooglePage;
using FindAZip.Pages.NavigationPage;
using FindAZip.Pages.TargetPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FindAZip
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //FirefoxProfile profile = new FirefoxProfile();
            //profile.AddExtension(@"..\..\Extensions\adblock_firefox.xpi");
            //FirefoxDriver driver = new FirefoxDriver(profile);

            ChromeOptions options = new ChromeOptions();
            options.AddExtension(@"..\..\Extensions\adblock_chrome.crx");
            ChromeDriver driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();
            driver.Url = @"http://www.findazip.com/";

            NavigationPage nav = new NavigationPage(driver);
            nav.citiesWithV.Click();

            TargetPage target = new TargetPage(driver);
            var cities = target.Cities;

            ContentPage content = new ContentPage(driver);
            var citiesURLs = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                citiesURLs.Add(cities[i].GetAttribute("href"));
            }

            var citiesForClick = new List<CityInfo>();
            foreach (var citiesUrL in citiesURLs)
            {
                driver.Url = citiesUrL;
                citiesForClick.Add(new CityInfo(content.Name.Text,
                                                content.State.Text,
                                                content.Zip.Text,
                                                content.Longitude.Text,
                                                content.Latidude.Text));
            }

            driver.Url = @"https://www.google.bg/maps/";
            GooglePage google = new GooglePage(driver);

            foreach (var cityInfo in citiesForClick)
            {
                //google.Search.Clear();
                //google.Search.SendKeys($"{cityInfo.Latitude}, {cityInfo.Longitude}");
                //google.Search.SendKeys(Keys.Enter);

                driver.Url = $"https://www.google.bg/maps/@{cityInfo.Latitude},{cityInfo.Longitude},15z";

                Thread.Sleep(5000);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile($"{cityInfo.Name}-{cityInfo.State}-{cityInfo.Zip}.jpg", ScreenshotImageFormat.Jpeg);
            }
        }
    }
}
