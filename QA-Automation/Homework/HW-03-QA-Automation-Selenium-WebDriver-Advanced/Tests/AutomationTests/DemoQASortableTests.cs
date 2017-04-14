namespace AutomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using AutomationTests.Utilities;

    [TestFixture]
    public class DemoQASortableTests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeEachTest()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterEachTest()
        {
            this.driver.Log().Quit();
        }

        
    }
}