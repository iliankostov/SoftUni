namespace AutomationTests.Utilities
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium;

    public static class DriverExtensions
    {
        public static void Type(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickOnElements(this List<IWebElement> elements, string data)
        {
            var conditions = data.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i] == 1)
                {
                    elements[i].Click();
                }
            }
        }

        public static string ToAbsolutePath(this string relativePath)
        {
            return Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, relativePath));
        }
    }
}
