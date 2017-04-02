namespace AuitomationTests
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
        public void SearchingInGoogleAndOpeningSeleniumWebsiteShouldRenderACorrectTitle()
        {
            //// Arrange
            var expectedHeading = "Курс QA Automation - март 2017";
            IWebDriver driver = new ChromeDriver();

            //// Act
            driver.Url = "http://softuni.bg";

            var educationsLink = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a"));
            educationsLink.Click();

            var courseLink = driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/div/div/div/div[2]/div[2]/ul/li[6]/a"));
            courseLink.Click();

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
