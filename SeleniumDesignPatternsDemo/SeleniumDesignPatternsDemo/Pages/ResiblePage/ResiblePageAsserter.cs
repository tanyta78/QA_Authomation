using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.ResiblePage
{
    public static class ResiblePageAsserter
    {
        public static void AssertNewSize(this ResiblePage page, int pixelToWidth, int pixelsToheight)
        {
            Assert.AreEqual(page.Width+pixelToWidth, page.ResizeWindow.Size.Width);
            Assert.AreEqual(page.Height+pixelsToheight, page.ResizeWindow.Size.Height);
        }

        public static void AssertNewSizeAnime(this ResiblePage page, int pixelToWidth, int pixelsToheight)
        {
           // Assert.AreEqual(page.Width + pixelToWidth, page.ResizeWindowAnime.Size.Width);
           // Assert.AreEqual(page.Height + pixelsToheight, page.ResizeWindowAnime.Size.Height);
            Assert.IsTrue(page.ResizeWindowAnime.Size.Width>page.Width);
            Assert.IsTrue(page.ResizeWindowAnime.Size.Height>page.Height);
        }

        public static void AssertNewSizeConstrain(this ResiblePage page)
        {
           
            Assert.IsTrue(page.ResizeWindowConstrain.Size.Width > page.Width);
            Assert.IsTrue(page.ResizeWindowConstrain.Size.Height > page.Height);
            Assert.IsTrue(page.ResizeWindowConstrain.Size.Width< page.WindowContainer.Size.Width);
            Assert.IsTrue(page.ResizeWindowConstrain.Size.Height < page.WindowContainer.Size.Height);
        }
    }
}
