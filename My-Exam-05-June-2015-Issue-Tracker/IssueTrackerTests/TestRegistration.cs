namespace IssueTrackerTests
{
    using IssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestRegistration
    {
        [TestMethod]
        public void WhenRegisterUserOutputMustBeSuccess()
        {
            var tracker = new IssueTracker();
            string output = tracker.RegisterUser("ilian", "123", "123");
            const string Expexted = "User ilian registered successfully";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenRegisterUserPasswordDidNotMatchOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            string output = tracker.RegisterUser("ilian", "123", "1234");
            const string Expexted = "The provided passwords do not match";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenRegisterUserWithExistingUsernameOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            string output = tracker.RegisterUser("ilian", "123", "123");
            const string Expexted = "A user with username ilian already exists";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenThereAreLoggedInUserOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            tracker.LoginUser("ilian", "123");
            string output = tracker.RegisterUser("dragan", "123", "123");
            const string Expexted = "There is already a logged in user";
            Assert.AreEqual(output, Expexted);
        }
    }
}