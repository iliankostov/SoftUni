namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;

    class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!Forum.Questions.Any())
            {
                Console.WriteLine(Messages.NoQuestions);
            }
            else
            {
                var questions = Forum.Questions.OrderBy(q => q.Id);

                foreach (var question in questions)
                {
                    Console.WriteLine(question);
                }
            }
        }
    }
}