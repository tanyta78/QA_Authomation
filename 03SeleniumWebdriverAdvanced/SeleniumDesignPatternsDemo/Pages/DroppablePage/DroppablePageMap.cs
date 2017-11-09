using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public partial class DroppablePage
    {
        public IWebElement Source
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]/p"));
            }
        }
       
        public IWebElement Target
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableview"));
            }
        }

        public IWebElement DragNonValid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggable-nonvalid\"]"));
            }
        }

        public IWebElement DragAccept
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableaccept\"]"));
            }
        }

        
        public IWebElement TargetToDrop
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppableaccept\"]"));
            }
        }

        public IWebElement SourceToDrop
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableprop\"]"));
            }
        }

        public IWebElement TargetDropableNotGreedy
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppableprop\"]"));
            }
        }

        public IWebElement TargetNotGreedy
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppable-inner\"]"));
            }
        }

        public IWebElement TargetGreedy
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppable2-inner\"]"));
            }
        }

        public IWebElement TargetDroppableGreedy
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppableprop2\"]"));
            }
        }
    }

}
