namespace AutomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;

    [TestFixture]
    public class GoogleSearch
    {
        [Test]
        public void SearchingInGoogleAndOpeningSeleniumWebsiteShouldRenderACorrectTitle()
        {
            //// Arrange
            var expectedTitle = "Selenium - Web Browser Automation";
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //// Act
            driver.Url = "http://google.com";
            var searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("selenium");
            var searchButton = driver.FindElement(By.Id("_fZl"));
            searchButton.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var firstLink = wait.Until((w) =>
            {
                return w.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/h3/a"));
            });
            firstLink.Click();
            var actualTitle = driver.Title;

            //// Assert
            Assert.AreEqual(expectedTitle, actualTitle);
            driver.Quit();
        }
    }
}
