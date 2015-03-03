namespace ConsoleForum.Commands
{
    using System;
    using ConsoleForum.Entities.Posts;
    using Contracts;

    class PostAnswerCommand: AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (Forum.IsLogged)
            {
                if (Forum.CurrentQuestion != null)
                {
                    string body = Data[1];
                    var author = Forum.CurrentUser;
                    var question = Forum.CurrentQuestion;
                    var answers = question.Answers;
                    int id = answers.Count + 1;

                    var answer = new Answer(id, body, author);
                    answers.Add(answer);
                    question.Answers.Add(answer);

                    string answerSuccess = string.Format(Messages.PostAnswerSuccess, id);
                    Console.WriteLine(answerSuccess);
                }
                else
                {
                    throw new CommandException(Messages.NoQuestionOpened);
                }               
            }
            else
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}