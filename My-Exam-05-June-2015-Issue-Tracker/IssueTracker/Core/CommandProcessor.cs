namespace IssueTracker.Core
{
    using System;

    using IssueTracker.Contracts;
    using IssueTracker.Enumerations;
    using IssueTracker.Models;

    public class CommandProcessor
    {
        public CommandProcessor()
            : this(new IssueTracker())
        {
        }

        private CommandProcessor(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        private IIssueTracker Tracker { get; set; }

        // Bug: there is no logout command
        // Bug: Parameters["Id"] do not exists. Change Id to id!
        // Bug: tags have to be splited by |
        public string ProcessCommand(ICommand command)
        {
            switch (command.Action)
            {
                case "RegisterUser":
                    return this.Tracker.RegisterUser(
                        command.Parameters["username"], 
                        command.Parameters["password"], 
                        command.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.Tracker.LoginUser(command.Parameters["username"], command.Parameters["password"]);
                case "LogoutUser":
                    return this.Tracker.LogoutUser();
                case "CreateIssue":
                    return this.Tracker.CreateIssue(
                        command.Parameters["title"], 
                        command.Parameters["description"], 
                        (IssuePriority)Enum.Parse(typeof(IssuePriority), command.Parameters["priority"], true), 
                        command.Parameters["tags"].Split('|'));
                case "RemoveIssue":
                    return this.Tracker.RemoveIssue(int.Parse(command.Parameters["id"]));
                case "AddComment":                
                    int issueId = int.Parse(command.Parameters["id"]);
                    string commentText = command.Parameters["text"];
                    string addComment = this.Tracker.AddComment(issueId, commentText);
                    return addComment;
                case "MyIssues":
                    return this.Tracker.GetMyIssues();
                case "MyComments":
                    return this.Tracker.GetMyComments();
                case "Search":
                    return this.Tracker.SearchForIssues(command.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", command.Action);
            }
        }
    }
}