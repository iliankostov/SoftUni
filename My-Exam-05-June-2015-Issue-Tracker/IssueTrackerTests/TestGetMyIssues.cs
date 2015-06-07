namespace IssueTrackerTests
{
    using System;
    using System.Collections.Generic;

    using IssueTracker.Enumerations;
    using IssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestGetMyIssues
    {
        [TestMethod]
        public void WhenThereAreNotLoggedInUserOutputMustBeAccessDenied()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            string output = tracker.GetMyIssues();
            const string Expexted = "There is no currently logged in user";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenUserDoesNotHaveIssuesOutputMustBeNoIssues()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            tracker.LoginUser("ilian", "123");
            string output = tracker.GetMyIssues();
            const string Expexted = "No issues";
            Assert.AreEqual(output, Expexted);
        }

        [TestMethod]
        public void WhenUserHasGotIssuesOutputMustBeIssuesByLine()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            tracker.LoginUser("ilian", "123");
            tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, new[] { "issue", "new" });
            tracker.CreateIssue("Another issue", "This is a another issue", IssuePriority.High, new[] { "issue", "another" });
            string output = tracker.GetMyIssues();
            const string Expexted = @"Another issue
Priority: ***
This is a another issue
Tags: another,issue
New issue
Priority: ***
This is a new issue
Tags: issue,new";
            Assert.AreEqual(output, Expexted);
        }
    }
}