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
    }
}
