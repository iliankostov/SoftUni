namespace IssueTracker.Utilities
{
    public static class Messages
    {
        public const string AlreadyALoggedInUser = "There is already a logged in user";

        public const string PasswordDoNotMatch = "The provided passwords do not match";

        public const string NoCurrentlyLoggedInUser = "There is no currently logged in user";

        public const string NoIssues = "No issues";

        public const string NoComments = "No comments";

        public const string NoTagsProvided = "There are no tags provided";

        public const string NoIssuesMatchingTheTagsProvided = "There are no issues matching the tags provided";

        public const string CommentAddedSuccessfullyToIssue = "Comment added successfully to issue {0}";

        public const string ThereIsNoIssueWithId = "There is no issue with ID {0}";

        public const string IssueIdRemoved = "Issue {0} removed";

        public const string TheIssueWithIdDoesNotBelongToUser = "The issue with ID {0} does not belong to user {1}";

        public const string IssueCreatedSuccessfully = "Issue {0} created successfully";

        public const string UserLoggedOutSuccessfully = "User {0} logged out successfully";

        public const string UserLoggedInSuccessfully = "User {0} logged in successfully";

        public const string ThePasswordIsInvalidForUser = "The password is invalid for user {0}";

        public const string UserDoesNotExist = "A user with username {0} does not exist";

        public const string UserRegisteredSuccessfully = "User {0} registered successfully";

        public const string UserAlreadyExists = "A user with username {0} already exists";

        public const string InvalidPriority = "The priority is invalid";

        public const string DescriptionMinLenght = "The description must be at least {0} symbols long";

        public const string TitleMinLenght = "The title must be at least {0} symbols long";

        public const string TextLenghtExeptionMessage = "The text must be at least {0} symbols long";
    }
}