namespace IssueTracker.Core
{
    using System;
    using Contracts;
    using Enumerations;

    public class EndpointActionDispatcher
    {
        private readonly IIssueTracker tracker;

        public EndpointActionDispatcher()
            : this(new IssueTracker())
        {
        }

        private EndpointActionDispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }

        // Bug: there is no logout command
        // Bug: Parameters["Id"] do not exists. Change Id to id!
        // Bug: tags have to be splited by |
        public string ProcessCommand(IEndpoint endpoint)
        {
            switch (endpoint.Action)
            {
                case "RegisterUser":
                    return this.tracker.RegisterUser(
                        endpoint.Parameters["username"], 
                        endpoint.Parameters["password"], 
                        endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.tracker.LoginUser(endpoint.Parameters["username"], endpoint.Parameters["password"]);
                case "LogoutUser":
                    return this.tracker.LogoutUser();
                case "CreateIssue":
                    return this.tracker.CreateIssue(
                        endpoint.Parameters["title"], 
                        endpoint.Parameters["description"], 
                        (IssuePriority)Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true), 
                        endpoint.Parameters["tags"].Split('|'));
                case "RemoveIssue":
                    return this.tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                case "AddComment":
                    int issueId = int.Parse(endpoint.Parameters["id"]);
                    string commentText = endpoint.Parameters["text"];
                    string addComment = this.tracker.AddComment(issueId, commentText);
                    return addComment;
                case "MyIssues":
                    return this.tracker.GetMyIssues();
                case "MyComments":
                    return this.tracker.GetMyComments();
                case "Search":
                    return this.tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.Action);
            }
        }
    }
}