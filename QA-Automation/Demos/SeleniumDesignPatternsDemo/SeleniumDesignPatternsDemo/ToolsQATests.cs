using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.AutomationPracticePage;
using SeleniumDesignPatternsDemo.Pages.DroppablePage;
using SeleniumDesignPatternsDemo.Pages.ResiblePage;
using SeleniumDesignPatternsDemo.Pages.ToolsQAHomePage;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace SeleniumDesignPatternsDemo
{
    [TestFixture]
    public class ToolsQATests
    {
        private IWebDriver driver;

        [Test]
        [Property("ToolsQA", 3)]
        public void HandlePopUp()
        {
            this.driver = new ChromeDriver();
            var automationPage = new AutomationPage(this.driver);
            var homePage = new ToolsQAHomePage(this.driver);

            automationPage.NavigateTo();
            automationPage.NewTabButton.Click();
            this.driver.SwitchTo().ActiveElement();
            var secondTab = this.driver.WindowHandles.Last();

            Assert.AreEqual("http://toolsqa.com/wp-content/uploads/2014/08/Toolsqa.jpg",
                homePage.Logo.GetAttribute("src"));
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }

        [Test]
        [Property("ToolsQA", 3)]
        public void DroppableFirstTry()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
            
        }

        [Test]
        [Property("ToolsQA", 3)]
        public void ResizeFirstTry()
        {
            this.driver = new ChromeDriver();
            var resizblePage = new ResiblePage(this.driver);

            resizblePage.IncreaseWidthAndheightBy(100);

            resizblePage.AssertNewSize(100, 100);
        }

        [Test]
        public void NavigateToSoftUni()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            driver.Url = "http://softuni.bg";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement loginButton = wait.Until<IWebElement>((w) =>{return w.FindElement(By.LinkText("Вход")); });
            loginButton.Click();

            var softUniUser = AccessExcelData.GetTestData("Login");
            IWebElement userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys(softUniUser.Username);
            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys(softUniUser.Password);
            IWebElement login = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div[2]/div[1]/form/input[2]"));
            login.Click();
            IWebElement logo = driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[1]"));
            

            Assert.IsTrue(logo.Displayed);
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);
                
                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }

        }
    }
}
