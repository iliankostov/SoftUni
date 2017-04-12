namespace AutomationTests
{
    using System.Reflection;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Data;

    using Pages.RegistrationPage;
    using Models;

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
            var dataReader = new DataReader<RegistrationUser>();
            var user = dataReader.GetData(MethodBase.GetCurrentMethod().Name);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(user);

            //// Assert
            registrationPage.AssertNamesErrorMessage();
        }

        [Test]
        public void RegistrationWithShortPhoneNumberShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var dataReader = new DataReader<RegistrationUser>();
            var user = dataReader.GetData(MethodBase.GetCurrentMethod().Name);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(user);

            //// Assert
            registrationPage.AssertPhoneErrorMessage();
        }

        [Test]
        public void RegistrationWithInvalidEmailShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var dataReader = new DataReader<RegistrationUser>();
            var user = dataReader.GetData(MethodBase.GetCurrentMethod().Name);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(user);

            //// Assert
            registrationPage.AssertInvalidEmailErrorMessage();
        }

        [Test]
        public void RegistrationWithoutEmailShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var dataReader = new DataReader<RegistrationUser>();
            var user = dataReader.GetData(MethodBase.GetCurrentMethod().Name);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(user);

            //// Assert
            registrationPage.AssertEmailErrorMessage();
        }

        [Test]
        public void RegistrationWithoutPasswordsShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var dataReader = new DataReader<RegistrationUser>();
            var user = dataReader.GetData(MethodBase.GetCurrentMethod().Name);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(user);

            //// Assert
            registrationPage.AssertPasswordErrorMessage();
        }

        [Test]
        public void RegistrationWithDiferentPasswordsShoulNotBeProcessed()
        {
            //// Arrange
            var registrationPage = new RegistrationPage(this.driver);
            var dataReader = new DataReader<RegistrationUser>();
            var user = dataReader.GetData(MethodBase.GetCurrentMethod().Name);

            //// Act
            registrationPage.Open();
            registrationPage.SubmitForm(user);

            //// Assert
            registrationPage.AssertDiferentPasswordsErrorMessage();
        }
    }
}
