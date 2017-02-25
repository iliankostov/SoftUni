namespace IssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Enumerations;
    using Models;
    using Utilities;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker()
            : this(new IssueTrackerData())
        {
        }

        public IssueTracker(IIssueTrackerData trackerData)
        {
            this.Data = trackerData;
        }

        public IIssueTrackerData Data { get; private set; }

        // BUG: if there is logged in user return
        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.LoggedInUser != null)
            {
                return Messages.AlreadyALoggedInUser;
            }

            if (password != confirmPassword)
            {
                return Messages.PasswordDoNotMatch;
            }

            if (this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format(Messages.UserAlreadyExists, username);
            }

            User user = new User(username, password);
            this.Data.UsersByUsername.Add(username, user);
            return string.Format(Messages.UserRegisteredSuccessfully, username);
        }

        // BUG: if there is logged in user return
        public string LoginUser(string username, string password)
        {
            if (this.Data.LoggedInUser != null)
            {
                return Messages.AlreadyALoggedInUser;
            }

            if (!this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format(Messages.UserDoesNotExist, username);
            }

            var user = this.Data.UsersByUsername[username];
            if (user.Password != HashUtilities.HashPassword(password))
            {
                return string.Format(Messages.ThePasswordIsInvalidForUser, username);
            }

            this.Data.LoggedInUser = user;

            return string.Format(Messages.UserLoggedInSuccessfully, username);
        }

        public string LogoutUser()
        {
            if (this.Data.LoggedInUser == null)
            {
                return Messages.NoCurrentlyLoggedInUser;
            }

            string username = this.Data.LoggedInUser.Username;
            this.Data.LoggedInUser = null;
            return string.Format(Messages.UserLoggedOutSuccessfully, username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.Data.LoggedInUser == null)
            {
                return Messages.NoCurrentlyLoggedInUser;
            }

            Issue issue = new Issue(title, description, priority, tags.Distinct().ToList());
            int issueId = this.Data.AddIssue(issue);

            return string.Format(Messages.IssueCreatedSuccessfully, issueId);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.LoggedInUser == null)
            {
                return Messages.NoCurrentlyLoggedInUser;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Messages.ThereIsNoIssueWithId, issueId);
            }

            Issue issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUsername[this.Data.LoggedInUser.Username].Contains(issue))
            {
                return string.Format(
                    Messages.TheIssueWithIdDoesNotBelongToUser, 
                    issueId, 
                    this.Data.LoggedInUser.Username);
            }

            this.Data.RemoveIssue(issue);
            return string.Format(Messages.IssueIdRemoved, issueId);
        }

        // BUG: when check for issueId do not add 1
        public string AddComment(int issueId, string text)
        {
            if (this.Data.LoggedInUser == null)
            {
                return Messages.NoCurrentlyLoggedInUser;
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format(Messages.ThereIsNoIssueWithId, issueId);
            }

            Issue issue = this.Data.IssuesById[issueId];
            Comment comment = new Comment(this.Data.LoggedInUser, text);
            issue.AddComment(comment);
            this.Data.CommentsByUser[this.Data.LoggedInUser].Add(comment);
            return string.Format(Messages.CommentAddedSuccessfullyToIssue, issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.LoggedInUser == null)
            {
                return Messages.NoCurrentlyLoggedInUser;
            }

            ICollection<Issue> issues = this.Data.IssuesByUsername[this.Data.LoggedInUser.Username];
            if (!issues.Any())
            {
                // PERFORMANCE: Unneeded operations, string concatenation in a loop
                return Messages.NoIssues;
            }

            return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (this.Data.LoggedInUser == null)
            {
                return Messages.NoCurrentlyLoggedInUser;
            }

            // PERFORMANCE: Values were not retrieve from correct dictionary
            ICollection<Comment> comments = this.Data.CommentsByUser[this.Data.LoggedInUser];
            if (!comments.Any())
            {
                return Messages.NoComments;
            }

            return string.Join(Environment.NewLine, comments.Select(c => c.ToString()));
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return Messages.NoTagsProvided;
            }

            HashSet<Issue> issues = new HashSet<Issue>();
            foreach (string tag in tags)
            {
                foreach (Issue issue in this.Data.IssuesByTag[tag])
                {
                    issues.Add(issue);
                }
            }

            if (!issues.Any())
            {
                return Messages.NoIssuesMatchingTheTagsProvided;
            }

            return string.Join(
                Environment.NewLine, 
                issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
    }
}