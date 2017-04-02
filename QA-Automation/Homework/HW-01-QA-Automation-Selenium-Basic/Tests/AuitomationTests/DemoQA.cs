namespace AuitomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    public class DemoQA
    {
        [Test]
        public void OpeningDemoQARegistrationPageShouldBeProcessedCorrectly()
        {
            //// Arrange
            var expectedUrl = "http://demoqa.com/registration/";

            //// Act
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://demoqa.com/";
            var registrationButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrationButton.Click();

            //// Assert
            Assert.AreEqual(expectedUrl, driver.Url);

            driver.Quit();
        }
    }
}
