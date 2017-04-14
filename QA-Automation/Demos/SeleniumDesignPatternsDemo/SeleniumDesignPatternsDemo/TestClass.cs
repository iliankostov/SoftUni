using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.HomePage;
using SeleniumDesignPatternsDemo.Pages.RegistrationPage;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebDriverFirstTests
{
    [TestFixture]
    public class RegisterInDemoQA
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            //this.driver = new InternetExplorerDriver();
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();

            //If you use Internet Explorer and browser don't close after test
            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.Start();
            //
            //cmd.StandardInput.WriteLine("taskkill /F /IM iexplore.exe");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        [Test, Property("Priority", 2)]
        [Author("Ventsislav Ivanov")]
        public void NavigateToRegistrationPage()
        {
            var homePage = new HomePage(driver);
            var registrationPage = new RegistrationPage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();
            homePage.RegirstratonButton.Click();

            registrationPage.AssertRegistrationPageIsOpen("Registration");
        }

        //Test with Valid Data, if you want to execute it change Username and Mail
        //[Test]
        //public void RegistrateWithValidData()
        //{
        //    var regPage = new RegistrationPage(this.driver);
        //    RegistrationUser user = new RegistrationUser("Ventsislav",
        //                                                 "Ivanov",
        //                                                 new List<bool>(new bool[] { true, false, false }),
        //                                                 new List<bool>(new bool[] { true, true, true }),
        //                                                 "Bulgaria",
        //                                                 "3",
        //                                                 "1",
        //                                                 "1989",
        //                                                 "8888888888",
        //                                                 "Buro",
        //                                                 "burkata@abv.bg",
        //                                                 @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
        //                                                 "OPSA",
        //                                                 "12345678",
        //                                                 "12345678");
        //
        //    regPage.NavigateTo();
        //    regPage.FillRegistrationForm(user);
        //
        //    regPage.AssesrtSuccessMessage("Thank you for your registration");
        //}

        [Test]
        public void RegistrateWithOutFirstName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
        }

        [Test]
        public void RegistrateWithOutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ventsislav",
                                                         "Ivanov",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "Buro",
                                                         "burkata@abv.bg",
                                                         @"C:\Users\Buro\Desktop\Seminar\Pics\enviroment.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("This field is required");
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
