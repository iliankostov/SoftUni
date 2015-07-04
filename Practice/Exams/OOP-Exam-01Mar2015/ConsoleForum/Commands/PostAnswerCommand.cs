namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            IUser author = this.Forum.CurrentUser;
            var question = this.Forum.CurrentQuestion as Question;
            if (author == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int anwerId = this.Forum.Answers.Count + 1;
            string body = this.Data[1];

            var answer = new Answer(anwerId, body, author);

            question.AddAnswer(answer);
            this.Forum.Answers.Add(answer);
            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, anwerId));
        }
    }
}
