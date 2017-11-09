using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertTargetAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.Target.GetAttribute("class"));
        }

        public static void AssertTargetToDropAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.TargetToDrop.GetAttribute("class"));
        }

        public static void AssertTargetToDropNotGreedyAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.TargetNotGreedy.GetAttribute("class"));
            Assert.AreEqual(classValue, page.TargetDropableNotGreedy.GetAttribute("class"));
        }

        public static void AssertTargetToDropGreedyAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.TargetGreedy.GetAttribute("class"));
            Assert.AreNotEqual(classValue, page.TargetDroppableGreedy.GetAttribute("class"));
        }


    }
}
