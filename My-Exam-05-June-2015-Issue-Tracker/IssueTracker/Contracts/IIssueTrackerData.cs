namespace IssueTracker.Contracts
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;

    public interface IIssueTrackerData
    {
        User LoggedInUser { get; set; }

        IDictionary<string, User> UsersByUsername { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> CommentsByUser { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}