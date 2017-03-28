using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumWebDriverFirstTests
{
    [TestFixture]
    public class RegisterInDemoQA
    {
        [Test]
        public void RegistrateWithValidData()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://www.demoqa.com";
            IWebElement registrateButton = driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a"));
            registrateButton.Click();
            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Ventsislav");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Ivanov");
            IWebElement matrialStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            matrialStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[1].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "Ivanov8");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "Ivanov8@abv.bg");
            IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\Buro\Desktop\big-logo.png");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "I think I'm Ready with this test!");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();
            IWebElement registrationMessage = driver.FindElement(By.ClassName("piereg_message"));

            Assert.IsTrue(registrateButton.Displayed);
            Assert.AreEqual("Thank you for your registration", registrationMessage.Text);
            StringAssert.Contains("Thank you", registrateButton.Text);
            driver.Quit();
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
