namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            IUser author = this.Forum.CurrentUser;
            if (author == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            int questionId = this.Forum.Questions.Count + 1;
            string title = this.Data[1];
            string body = this.Data[2];

            var question = new Question(questionId, body, author, title);
            this.Forum.Questions.Add(question);
            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, questionId));
        }
    }
}
