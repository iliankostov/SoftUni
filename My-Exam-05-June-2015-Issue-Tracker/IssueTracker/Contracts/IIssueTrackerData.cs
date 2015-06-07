namespace IssueTracker.Contracts
{
    using System.Collections.Generic;

    using IssueTracker.Models;

    using Wintellect.PowerCollections;

    internal interface IIssueTrackerData
    {
        User LoggedInUser { get; set; }

        IDictionary<string, User> Users { get; }

        OrderedDictionary<int, Issue> IssuesWithIds { get; }

        MultiDictionary<string, Issue> IssuesByAuthors { get; }

        MultiDictionary<string, Issue> IssuesByTags { get; }

        MultiDictionary<User, Comment> UsersComments { get; }

        int AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }
}