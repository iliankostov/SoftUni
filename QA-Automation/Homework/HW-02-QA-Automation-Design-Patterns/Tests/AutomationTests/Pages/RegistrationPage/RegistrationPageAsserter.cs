﻿namespace AutomationTests.Pages.RegistrationPage
{
    using NUnit.Framework;

    public static class RegistrationPageAsserter
    {
        public static void AssertNamesErrorMessage(this RegistrationPage page)
        {
            Assert.IsTrue(page.Elements.ErrorMessagesForNames.Displayed);
            StringAssert.Contains(Constants.ERROR_REQUIRED, page.Elements.ErrorMessagesForNames.Text);
        }

        public static void AssertPhoneErrorMessage(this RegistrationPage page)
        {
            Assert.IsTrue(page.Elements.ErrorMessagesForPhone.Displayed);
            StringAssert.Contains(Constants.ERROR_PHONE, page.Elements.ErrorMessagesForPhone.Text);
        }

        public static void AssertInvalidEmailErrorMessage(this RegistrationPage page)
        {
            Assert.IsTrue(page.Elements.ErrorMessagesForEmail.Displayed);
            StringAssert.Contains(Constants.ERROR_EMAIL, page.Elements.ErrorMessagesForEmail.Text);
        }

        public static void AssertEmailErrorMessage(this RegistrationPage page)
        {
            Assert.IsTrue(page.Elements.ErrorMessagesForEmail.Displayed);
            StringAssert.Contains(Constants.ERROR_REQUIRED, page.Elements.ErrorMessagesForEmail.Text);
        }

        public static void AssertPasswordErrorMessage(this RegistrationPage page)
        {
            Assert.IsTrue(page.Elements.ErrorMessagesForPassword.Displayed);
            StringAssert.Contains(Constants.ERROR_REQUIRED, page.Elements.ErrorMessagesForPassword.Text);
            Assert.IsTrue(page.Elements.ErrorMessagesForConfirmPassword.Displayed);
            StringAssert.Contains(Constants.ERROR_REQUIRED, page.Elements.ErrorMessagesForConfirmPassword.Text);
        }

        public static void AssertDiferentPasswordsErrorMessage(this RegistrationPage page)
        {
            Assert.IsTrue(page.Elements.ErrorMessagesForConfirmPassword.Displayed);
            StringAssert.Contains(Constants.ERROR_PASSWORD_NOT_MATCH, page.Elements.ErrorMessagesForConfirmPassword.Text);
        }
    }
}
