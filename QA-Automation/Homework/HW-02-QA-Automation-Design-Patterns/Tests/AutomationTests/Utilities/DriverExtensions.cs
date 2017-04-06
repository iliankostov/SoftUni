namespace AutomationTests.Utilities
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public static class DriverExtensions
    {
        public static void Type(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickOnElements(this List<IWebElement> elements, List<bool> conditions)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i])
                {
                    elements[i].Click();
                }
            }
        }
    }
}
