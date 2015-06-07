namespace IssueTrackerTests
{
    using IssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestLogin
    {
        [TestMethod]
        public void WhenLoginUserWithInvalidUsernameOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            string output = tracker.LoginUser("ilia", "123");
            const string Expexted = "A user with username ilia does not exist";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenLoginUserWtihInvalidPasswordOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            string output = tracker.LoginUser("ilian", "1234");
            const string Expexted = "The password is invalid for user ilian";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenThereAreLoggedInUserOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            tracker.RegisterUser("dragan", "123", "123");
            tracker.LoginUser("ilian", "123");
            string output = tracker.LoginUser("dragan", "123");
            const string Expexted = "There is already a logged in user";
            Assert.AreEqual(output, Expexted);
        }
    }
}