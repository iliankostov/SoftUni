namespace IssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::IssueTracker.Contracts;
    using global::IssueTracker.Enumerations;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker()
            : this(new IssueTrackerData())
        {
        }

        private IssueTracker(IIssueTrackerData trackerData)
        {
            this.TrackerData = trackerData as IssueTrackerData;
        }

        private IssueTrackerData TrackerData { get; set; }

        // Bug: if there is logged in user stop
        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.TrackerData.LoggedInUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match");
            }

            if (this.TrackerData.Users.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.TrackerData.Users.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        // Bug: if there is logged in user stop
        public string LoginUser(string username, string password)
        {
            if (this.TrackerData.LoggedInUser != null)
            {
                return string.Format("There is already a logged in user");
            }

            if (!this.TrackerData.Users.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.TrackerData.Users[username];
            if (user.Password != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.TrackerData.LoggedInUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.TrackerData.LoggedInUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            string username = this.TrackerData.LoggedInUser.Username;
            this.TrackerData.LoggedInUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.TrackerData.LoggedInUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            issue.Id = this.TrackerData.NextIssueId;
            this.TrackerData.IssuesWithIds.Add(issue.Id, issue);
            this.TrackerData.NextIssueId++;
            this.TrackerData.IssuesByAuthors[this.TrackerData.LoggedInUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.TrackerData.IssuesByTags[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.TrackerData.LoggedInUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.TrackerData.IssuesWithIds.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.TrackerData.IssuesWithIds[issueId];
            if (!this.TrackerData.IssuesByAuthors[this.TrackerData.LoggedInUser.Username].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.TrackerData.LoggedInUser.Username);
            }

            this.TrackerData.IssuesByAuthors[this.TrackerData.LoggedInUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.TrackerData.IssuesByTags[tag].Remove(issue);
            }

            this.TrackerData.IssuesWithIds.Remove(issue.Id);
            return string.Format("Issue {0} removed", issueId);
        }

        // Bug: when check for issueId do not add 1
        public string AddComment(int issueId, string text)
        {
            if (this.TrackerData.LoggedInUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.TrackerData.IssuesWithIds.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.TrackerData.IssuesWithIds[issueId];
            var comment = new Comment(this.TrackerData.LoggedInUser, text);
            issue.AddComment(comment);
            this.TrackerData.UsersComments[this.TrackerData.LoggedInUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        // Bug change return values if any
        public string GetMyIssues()
        {
            if (this.TrackerData.LoggedInUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var issues = this.TrackerData.IssuesByAuthors[this.TrackerData.LoggedInUser.Username];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (this.TrackerData.LoggedInUser == null)
            {
                return string.Format("There is no currently logged in user");
            }

            var comments = new List<Comment>();
            this.TrackerData.IssuesWithIds.Select(i => i.Value.Comments).ToList().ForEach(item => comments.AddRange(item));
            var resultComments =
                comments.Where(c => c.Author.Username == this.TrackerData.LoggedInUser.Username).ToList();
            var strings = resultComments.Select(x => x.ToString());
            if (!strings.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, strings);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return "There are no tags provided";
            }

            var i = new List<Issue>();
            foreach (var t in tags)
            {
                i.AddRange(this.TrackerData.IssuesByTags[t]);
            }

            if (!i.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var newi = i.Distinct();
            if (!newi.Any())
            {
                return "No issues";
            }

            return string.Join(
                Environment.NewLine,
                newi.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
    }
}