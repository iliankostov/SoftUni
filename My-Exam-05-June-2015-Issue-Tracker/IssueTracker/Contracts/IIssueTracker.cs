namespace IssueTracker.Contracts
{
    using Enumerations;

    /// <summary>
    /// Contains methods for working with issue tracking system.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Register a user in the database
        /// </summary>
        /// <param name="username">
        /// The username of the user who want to register
        /// </param>
        /// <param name="password">
        /// The password of the user who want to register
        /// </param>
        /// <param name="confirmPassword">
        /// The password confirmation of the user who want to register. In order to be a valid registration, the two password values must match
        /// </param>
        /// <returns>
        /// Returns a success message in case of successful registration or an error message otherwise
        /// </returns>
        /// <exception cref="System.ArgumentException">If the password don't match.</exception>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// Login a user if exist in the database
        /// </summary>
        /// <param name="username">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// Message for success or failed login.
        /// </returns>
        string LoginUser(string username, string password);

        /// <summary>
        /// The logout user.
        /// </summary>
        /// <returns>
        /// Message for success or failed logout.
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
        /// Message for success or failed creating issue.
        /// </returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// The remove issue.
        /// </summary>
        /// <param name="issueId">
        /// The issue id.
        /// </param>
        /// <returns>
        /// Message for success or failed removing issue.
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
        /// Message for success or failed add comment to issue.
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
        /// Search issues by given tags.
        /// </returns>
        string SearchForIssues(string[] tags);
    }
}