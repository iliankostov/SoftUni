namespace IssueTrackerTests
{
    using IssueTracker;
    using IssueTracker.Enumerations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSearchForIssues
    {
        [TestMethod]
        public void TestIfThereIsAnyTags()
        {
            var tracker = new IssueTracker();
            tracker.RegisterUser("ilian", "123", "123");
            tracker.CreateIssue("New issue", "This is a new issue", IssuePriority.High, new[] { "issue", "new" });
            string output = tracker.SearchForIssues(new[] { string.Empty });
            const string Expexted = "There are no issues matching the tags provided";
            Assert.AreEqual(output, Expexted);
        }
    }
}