namespace AutomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class QAAutomation
    {
        [Test]
        public void OpeningTheSoftUniCourseShouldRenderEqualHeadings()
        {
            //// Arrange
            var expectedHeading = "Курс QA Automation - март 2017";
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //// Act
            driver.Url = "http://softuni.bg";

            var educationsLink = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a"));
            educationsLink.Click();

            var activeCourses = driver.FindElements(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/div/div/div/div[2]/div[2]/ul/li"));

            foreach (var activeCourse in activeCourses)
            {
                if (activeCourse.Text == "QA Automation - март 2017")
                {
                    activeCourse.Click();
                    break;
                }
            }

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var headings = wait.Until((w) =>
            {
                return new List<IWebElement>()
                {
                    w.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div/h1")),
                    w.FindElement(By.XPath("/html/body/div[3]/div[2]/div/article/div[1]/h2"))
                };
            });

            //// Assert
            foreach (var heading in headings)
            {
                Assert.AreEqual(expectedHeading, heading.Text);
            }

            driver.Quit();
        }
    }
}
