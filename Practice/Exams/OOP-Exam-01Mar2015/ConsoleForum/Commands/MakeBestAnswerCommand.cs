namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Posts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int answerId = int.Parse(this.Data[1]);
            var question = this.Forum.CurrentQuestion as Question;
            var currentUser = this.Forum.CurrentUser;

            if (currentUser == null)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var answer = question.Answers.FirstOrDefault(a => a.Id == answerId);

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (currentUser.Username == question.Author.Username || currentUser.Id == 1)
            {
                if (question.HasBestAnswer)
                {
                    throw new CommandException(string.Format(Messages.BestAnswerDenied, question.Id));
                }

                var bestAnswer = new BestAnswer(answerId, answer.Body, answer.Author);

                this.Forum.Answers.Remove(answer);
                this.Forum.Answers.Add(bestAnswer);
                question.Answers.Remove(answer);
                question.Answers.Add(bestAnswer);
                question.HasBestAnswer = true;

                this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, bestAnswer.Id));
            }
            else
            {
                throw new CommandException(Messages.NoPermission);                
            }
        }
    }
}
