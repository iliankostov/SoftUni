namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    using Entities.Posts;

    class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (Forum.IsLogged)
            {
                var questions = Forum.Questions;
                var author = Forum.CurrentUser;

                int id = questions.Count + 1;
                string title = Data[1];
                string body = Data[2];

                var question = new Question(title, id, author, body);

                questions.Add(question);
                string possedSuccess = string.Format(Messages.PostQuestionSuccess, question.Id);
                Console.WriteLine(possedSuccess);
            }
            else
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}