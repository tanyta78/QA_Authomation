using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
   public static class DraggablePageAsserter
    {
        public static void AssertNewLocation(this DraggablePage page, int firstlocationX, int firstlocationY)
        {
           
            Assert.IsTrue(firstlocationX != page.Source.Location.X || firstlocationY!=page.Source.Location.Y);
        }

        public static void AssertNewLocationVertical(this DraggablePage page, int firstlocationX, int firstlocationY)
        {

            Assert.IsTrue(firstlocationX == page.SourceVertical.Location.X && firstlocationY != page.SourceVertical.Location.Y);
        }

        public static void AssertNewLocationHorizontally(this DraggablePage page, int firstlocationX, int firstlocationY)
        {

            Assert.IsTrue(firstlocationX != page.SourceHorizont.Location.X && firstlocationY == page.SourceHorizont.Location.Y);
        }

        public static void AssertNewLocationInContainer(this DraggablePage page, int firstlocationX, int firstlocationY,int containerX,int containerY,int containerWidth, int containerHeight)
        {

            Assert.IsTrue(firstlocationX != page.SourseContained.Location.X || firstlocationY != page.SourseContained.Location.Y);
            Assert.IsTrue(page.SourseContained.Location.X<(containerX+containerWidth) && page.SourseContained.Location.X > containerX && page.SourseContained.Location.Y>containerY && page.SourseContained.Location.Y<(containerY+containerHeight));
        }

        public static void AssertNewLocationInParentContainer(this DraggablePage page, int firstlocationX, int firstlocationY)
        {

            Assert.IsTrue(firstlocationX == (page.SourseParentContained.Location.X - 1) || firstlocationX == (page.SourseParentContained.Location.X + 1) && firstlocationY >= page.SourseParentContained.Location.Y);
           
        }
    }
}
