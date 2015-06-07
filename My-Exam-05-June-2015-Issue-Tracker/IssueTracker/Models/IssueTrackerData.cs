namespace IssueTracker.Models
{
    using System.Collections.Generic;

    using Contracts;

    using Wintellect.PowerCollections;

    public class IssueTrackerData : IIssueTrackerData
    {
        public IssueTrackerData()
        {
            this.NextIssueId = 1;
            this.Users = new Dictionary<string, User>();

            this.Issues = new MultiDictionary<Issue, string>(true);
            this.IssuesWithIds = new OrderedDictionary<int, Issue>();
            this.IssuesByAuthors = new MultiDictionary<string, Issue>(true);
            this.Issues3 = new MultiDictionary<string, Issue>(true);
            this.IssuesByTags = new MultiDictionary<string, Issue>(true);

            this.UsersComments = new MultiDictionary<User, Comment>(true);
            this.Comments = new Dictionary<Comment, User>();
        }

        public int NextIssueId { get; set; }

        public User LoggedInUser { get; set; }

        public IDictionary<string, User> Users { get; set; }

        public MultiDictionary<Issue, string> Issues { get; set; }

        public OrderedDictionary<int, Issue> IssuesWithIds { get; set; }

        public MultiDictionary<string, Issue> IssuesByAuthors { get; set; }

        public MultiDictionary<string, Issue> Issues3 { get; set; }

        public MultiDictionary<string, Issue> IssuesByTags { get; set; }

        public MultiDictionary<User, Comment> UsersComments { get; set; }

        public Dictionary<Comment, User> Comments { get; set; }
        
        public int AddIssue(Issue p)
        {
            return 0;
        }

        public void RemoveIssue(Issue p)
        {
        }
    }
}