using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
   public static class SortablePageAsserter
    {
        public static void IsMovedItemOneToItemFourPosition(this SortablePage page, string textValue)
        {
            Assert.AreEqual(textValue, page.ItemFive.Text);
        }

        public static void IsMovedItemOneToLastPosition(this SortablePage page, string textValue)
        {
            Assert.AreEqual(textValue, page.ItemSeven.Text);
        }
        public static void IsMovedItemOneConected(this SortablePage page, string textValue)
        {
            Assert.AreEqual(textValue, page.ItemOneConnectedDefault.Text);
        }
    }
}
