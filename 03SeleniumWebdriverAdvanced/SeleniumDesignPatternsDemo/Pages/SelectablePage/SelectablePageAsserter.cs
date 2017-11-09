using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public static class SelectablePageAsserter
    {
        public static void IsSelectedItemOne(this SelectablePage page,string classValue)
        {
            Assert.AreEqual(classValue, page.ItemOne.GetAttribute("class"));
        }

        public static void AreNotSelected(this SelectablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.ItemTwo.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemThree.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemFour.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemFive.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemSix.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemSeven.GetAttribute("class"));
        }

        public static void AreAllSelected(this SelectablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.ItemOne.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemTwo.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemThree.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemFour.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemFive.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemSix.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemSeven.GetAttribute("class"));
        }

        public static void AreAllSelectedAsGrid(this SelectablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.ItemOneAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemTwoAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemThreeAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemFourAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemFiveAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemSixAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemSevenAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemEightAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemNineAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemTenAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemElevenAsGrid.GetAttribute("class"));
            Assert.AreEqual(classValue, page.ItemTwelveAsGrid.GetAttribute("class"));
        }

    }
}
