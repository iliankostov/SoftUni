namespace AutomationTests
{
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Data;
    using Models;

    using Pages.RegistrationPage;

    [TestFixture]
    public class DemoQANegative
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
            this.driver.Quit();
        }

        [Test]
        public void RegistrationWithoutNamesShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var userData = DataReader.RegistrationUser(MethodBase.GetCurrentMethod().Name);
            var registrationUser = new RegistrationUser(userData);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(registrationUser);

            //// Assert
            registrationPage.AssertNamesErrorMessage();
        }

        [Test]
        public void RegistrationWithShortPhoneNumberShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var userData = DataReader.RegistrationUser(MethodBase.GetCurrentMethod().Name);
            var registrationUser = new RegistrationUser(userData);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(registrationUser);

            //// Assert
            registrationPage.AssertPhoneErrorMessage();
        }

        [Test]
        public void RegistrationWithInvalidEmailShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var userData = DataReader.RegistrationUser(MethodBase.GetCurrentMethod().Name);
            var registrationUser = new RegistrationUser(userData);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(registrationUser);

            //// Assert
            registrationPage.AssertInvalidEmailErrorMessage();
        }

        [Test]
        public void RegistrationWithoutEmailShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var userData = DataReader.RegistrationUser(MethodBase.GetCurrentMethod().Name);
            var registrationUser = new RegistrationUser(userData);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(registrationUser);

            //// Assert
            registrationPage.AssertEmailErrorMessage();
        }

        [Test]
        public void RegistrationWithoutPasswordsShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var userData = DataReader.RegistrationUser(MethodBase.GetCurrentMethod().Name);
            var registrationUser = new RegistrationUser(userData);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(registrationUser);

            //// Assert
            registrationPage.AssertPasswordErrorMessage();
        }

        [Test]
        public void RegistrationWithDiferentPasswordsShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var userData = DataReader.RegistrationUser(MethodBase.GetCurrentMethod().Name);
            var registrationUser = new RegistrationUser(userData);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(registrationUser);

            //// Assert
            registrationPage.AssertDiferentPasswordsErrorMessage();
        }
    }
}
