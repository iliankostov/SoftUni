namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;

    using ConsoleForum.Contracts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions.OrderBy(q => q.Id);
            if (!questions.Any())
            {
                throw new CommandException(Messages.NoQuestions);
            }

            this.Forum.Output.AppendLine(string.Join(Environment.NewLine, questions));
        }
    }
}
