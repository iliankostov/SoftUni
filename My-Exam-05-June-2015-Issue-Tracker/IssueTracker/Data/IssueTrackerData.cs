namespace IssueTracker.Data
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Wintellect.PowerCollections;

    public class IssueTrackerData : IIssueTrackerData
    {
        private int nextIssueId;

        public IssueTrackerData()
        {
            this.nextIssueId = 1;
            this.UsersByUsername = new Dictionary<string, User>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.CommentsByUser = new MultiDictionary<User, Comment>(true);
        }

        public User LoggedInUser { get; set; }

        public IDictionary<string, User> UsersByUsername { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }

        public MultiDictionary<User, Comment> CommentsByUser { get; set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.nextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.nextIssueId++;
            this.IssuesByUsername[this.LoggedInUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesByUsername[this.LoggedInUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}