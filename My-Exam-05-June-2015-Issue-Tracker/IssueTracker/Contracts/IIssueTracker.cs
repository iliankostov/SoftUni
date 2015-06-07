namespace IssueTracker.Contracts
{
    using IssueTracker.Enumerations;

    /// <summary>
    /// The IssueTracker interface.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// The register user.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <param name="confirmPassword">
        /// The confirm password.
        /// </param>
        /// <returns>
        /// Message for sucess or failed registration.
        /// </returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// The login user.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Message for sucess or failed login.
        /// </returns>
        string LoginUser(string username, string password);

        /// <summary>
        /// The logout user.
        /// </summary>
        /// <returns>
        /// Message for sucess or failed logout.
        /// </returns>
        string LogoutUser();

        /// <summary>
        /// The create issue.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="priority">
        /// The priority.
        /// </param>
        /// <param name="tags">
        /// The tags.
        /// </param>
        /// <returns>
        /// Message for sucess or failed creating issue.
        /// </returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// The remove issue.
        /// </summary>
        /// <param name="issueId">
        /// The issue id.
        /// </param>
        /// <returns>
        /// Message for sucess or failed removing issue.
        /// </returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// The add comment.
        /// </summary>
        /// <param name="issueId">
        /// The issue id.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// Message for sucess or failed add comment to issue.
        /// </returns>
        string AddComment(int issueId, string text);

        /// <summary>
        /// The get my issues.
        /// </summary>
        /// <returns>
        /// All my issues.
        /// </returns>
        string GetMyIssues();

        /// <summary>
        /// The get my comments.
        /// </summary>
        /// <returns>
        /// All my comments.
        /// </returns>
        string GetMyComments();

        /// <summary>
        /// The search for issues.
        /// </summary>
        /// <param name="tags">
        /// The tags.
        /// </param>
        /// <returns>
        /// Search issues by givven tags.
        /// </returns>
        string SearchForIssues(string[] tags);
    }
}