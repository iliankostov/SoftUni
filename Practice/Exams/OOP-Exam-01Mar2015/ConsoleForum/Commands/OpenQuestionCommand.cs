namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;

    class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int id = int.Parse(Data[1]);
            var questions = Forum.Questions;
            var question = questions.FirstOrDefault(q => q.Id == id);
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }
            Forum.CurrentQuestion = question;
            Console.WriteLine(question);
        }
    }
}