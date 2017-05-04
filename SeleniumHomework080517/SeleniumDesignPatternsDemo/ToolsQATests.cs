using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.AutomationPracticePage;
using SeleniumDesignPatternsDemo.Pages.DroppablePage;
using SeleniumDesignPatternsDemo.Pages.ResiblePage;
using SeleniumDesignPatternsDemo.Pages.ToolsQAHomePage;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using SeleniumDesignPatternsDemo.Pages.DraggablePage;
using SeleniumDesignPatternsDemo.Pages.SelectablePage;
using SeleniumDesignPatternsDemo.Pages.SortablePage;

namespace SeleniumDesignPatternsDemo
{
    [TestFixture]
    public class ToolsQATests
    {
        public IWebDriver driver;
        //[SetUp]
        //public void Init()
        //{
        //    this.driver = new ChromeDriver();
        //}

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

        }

        [Test]
        [Property("ToolsQA", 3)]
        public void HandlePopUp()
        {
            this.driver = new ChromeDriver();
            var automationPage = new AutomationPage(this.driver);
            var homePage = new ToolsQAHomePage(this.driver);

            automationPage.NavigateTo();
            automationPage.NewTabButton.Click();
            this.driver.SwitchTo().ActiveElement();
            var secondTab = this.driver.WindowHandles.Last();

            Assert.AreEqual("http://toolsqa.com/wp-content/uploads/2014/08/Toolsqa.jpg",
                homePage.Logo.GetAttribute("src"));
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }

        [Test]
        [Property("ToolsQADrop", 3)]
        public void DroppableFirstTry()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
           
        }

        [Test]
        [Property("ToolsQADrop", 3)]
        public void DroppableAccept()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDropAccept();

            droppablePage.AssertTargetToDropAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

        }

        [Test]
        [Property("ToolsQADrop", 3)]
        public void NonDroppableAccept()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDropNotAccept();

            droppablePage.AssertTargetToDropAttributeValue("ui-widget-header ui-droppable");

        }

        [Test]
        [Property("ToolsQADrop", 3)]
        public void InnerDropableNotGreedy()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDropPropagationNotGreedy();

            droppablePage.AssertTargetToDropNotGreedyAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
            droppablePage.AssertTargetToDropGreedyAttributeValue("ui-widget-header ui-droppable");

        }

        [Test]
        [Property("ToolsQADrop", 3)]
        public void InnerDropableGreedy()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDropPropagationGreedy();

            droppablePage.AssertTargetToDropGreedyAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
           

        }

        [Test]
        [Property("ToolsQAResize", 3)]
        public void ResizeFirstTry()
        {
            this.driver = new ChromeDriver();
            var resizblePage = new ResiblePage(this.driver);

            resizblePage.IncreaseWidthAndheightBy(100);

            resizblePage.AssertNewSize(233,233);
        }

        [Test]
        [Property("ToolsQAResize", 3)]
        public void ResizeAnimate()
        {
            this.driver = new ChromeDriver();
            var resizablePage = new ResiblePage(this.driver);

            resizablePage.AnimateResize(100);
           // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
           
            resizablePage.AssertNewSizeAnime(298,298);
            
        }

        [Test]
        [Property("ToolsQAResize", 3)]
        public void ResizeConstrain()
        {
            this.driver = new ChromeDriver();
            var resizablePage = new ResiblePage(this.driver);

            resizablePage.ConstrainResize(20);
            resizablePage.AssertNewSizeConstrain();

        }

        [Test]
        [Property("ToolsQADrag", 3)]
        public void DraggableFirstTry()
        {
            this.driver = new ChromeDriver();
            var draggablePage= new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            var firstlocationX = draggablePage.Source.Location.X;
            var firstlocationY = draggablePage.Source.Location.Y;

            draggablePage.DragAndDrop(20);
            draggablePage.AssertNewLocation(firstlocationX,firstlocationY);


        }

        [Test]
        [Property("ToolsQADrag", 3)]
        public void DraggableVertically()
        {
            this.driver = new ChromeDriver();
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            var newTag = this.driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var firstlocationX = draggablePage.SourceVertical.Location.X;
            var firstlocationY = draggablePage.SourceVertical.Location.Y;

            draggablePage.DragAndDropVertical(20);
            draggablePage.AssertNewLocationVertical(firstlocationX, firstlocationY);

        }

        [Test]
        [Property("ToolsQADrag", 3)]
        public void DraggableHorizontally()
        {
            this.driver = new ChromeDriver();
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            var newTag = this.driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var firstlocationX = draggablePage.SourceHorizont.Location.X;
            var firstlocationY = draggablePage.SourceHorizont.Location.Y;

            draggablePage.DragAndDropHorizontal(20);
            draggablePage.AssertNewLocationHorizontally(firstlocationX, firstlocationY);

        }

        [Test]
        [Property("ToolsQADrag", 3)]
        public void DraggableInContainer()
        {
            this.driver = new ChromeDriver();
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            var newTag = this.driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var firstlocationX = draggablePage.SourseContained.Location.X;
            var firstlocationY = draggablePage.SourseContained.Location.Y;
            var containerX = draggablePage.Container.Location.X;
            var containerY = draggablePage.Container.Location.Y;
            var containerWidth = draggablePage.Container.Size.Width;
            var containerHeight = draggablePage.Container.Size.Height;
          
            draggablePage.DragAndDropInContainer(20);
            draggablePage.AssertNewLocationInContainer(firstlocationX,firstlocationY,containerX,containerY,containerWidth,containerHeight);

        }

        [Test]
        [Property("ToolsQADrag", 3)]
        public void DraggableInParentContainer()
        {
            this.driver = new ChromeDriver();
            var draggablePage = new DraggablePage(this.driver);
            draggablePage.NavigateTo();
            var newTag = this.driver.FindElement(By.XPath(" //*[@id=\"ui-id-2\"]"));
            newTag.Click();
            var firstlocationX = draggablePage.SourseParentContained.Location.X;
            var firstlocationY = draggablePage.SourseParentContained.Location.Y;
            var containerX = draggablePage.ParentContainer.Location.X;
            var containerY = draggablePage.ParentContainer.Location.Y;
            var containerWidth = draggablePage.Container.Size.Width;
            var containerHeight = draggablePage.Container.Size.Height;

            draggablePage.DragAndDropInParentContainer(50);
            draggablePage.AssertNewLocationInParentContainer(firstlocationX, firstlocationY);

        }

        [Test]
        [Property("ToolsQASelect", 3)]
        public void SelectOneElement()
        {
            this.driver = new ChromeDriver();
            var selectablePage = new SelectablePage(this.driver);
            selectablePage.NavigateTo();
            
            selectablePage.SelectItemOne();
            selectablePage.IsSelectedItemOne("ui-widget-content ui-corner-left ui-selectee ui-selected");
            selectablePage.AreNotSelected("ui-widget-content ui-corner-left ui-selectee");

        }

        [Test]
        [Property("ToolsQASelect", 3)]
        public void SelectAllElements()
        {
            this.driver = new ChromeDriver();
            var selectablePage = new SelectablePage(this.driver);
            selectablePage.NavigateTo();

            selectablePage.SelectMoreItems();
            selectablePage.AreAllSelected("ui-widget-content ui-corner-left ui-selectee ui-selected");
           

        }

        [Test]
        [Property("ToolsQASelect", 3)]
        public void SelectAllElementsAsGrid()
        {
            this.driver = new ChromeDriver();
            var selectablePage = new SelectablePage(this.driver);
            selectablePage.NavigateTo();
            var newTag = this.driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            newTag.Click();

            selectablePage.SelectMoreItemsAsGrid();
            selectablePage.AreAllSelectedAsGrid("ui-state-default ui-corner-left ui-selectee ui-selected");


        }

        [Test]
        [Property("ToolsQASortable", 3)]
        public void MoveItemOneToSort()
        {
            this.driver = new ChromeDriver();
            var sortablePage = new SortablePage(this.driver);
            sortablePage.NavigateTo();
         
            sortablePage.MoveItemOneToItemFivePosition();
            sortablePage.IsMovedItemOneToItemFourPosition("Item 1");

        }

        [Test]
        [Property("ToolsQASortable", 3)]
        public void MoveItemOneToLast()
        {
            this.driver = new ChromeDriver();
            var sortablePage = new SortablePage(this.driver);
            sortablePage.NavigateTo();

            sortablePage.MoveItemOneToEndPosition();
            sortablePage.IsMovedItemOneToLastPosition("Item 1");

        }

        [Test]
        [Property("ToolsQASortable", 3)]
        public void MoveItemOneConnected()
        {
            this.driver = new ChromeDriver();
            var sortablePage = new SortablePage(this.driver);
            sortablePage.NavigateTo();
            var newTag = this.driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            newTag.Click();

            sortablePage.MoveItemOneToEndPositionConnected();
            sortablePage.IsMovedItemOneConected("Item 2");

        }


        [Test]
        public void NavigateToSoftUni()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            driver.Url = "http://softuni.bg";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement loginButton = wait.Until<IWebElement>((w) => { return w.FindElement(By.LinkText("Вход")); });
            loginButton.Click();

            var softUniUser = AccessExcelData.GetTestData("Login");
            IWebElement userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys(softUniUser.Username);
            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys(softUniUser.Password);
            IWebElement login = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div[2]/div[1]/form/input[2]"));
            login.Click();
            IWebElement logo = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[1]"));


            Assert.IsTrue(logo.Displayed);
        }

       
    }
}
