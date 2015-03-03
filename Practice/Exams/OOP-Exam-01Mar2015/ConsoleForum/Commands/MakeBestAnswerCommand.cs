namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using ConsoleForum.Entities.Posts;
    using Entities.Users;

    class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (Forum.IsLogged)
            {
                if (Forum.CurrentQuestion != null)
                {                                            
                    int answerId = int.Parse(Data[1]);
                    var currentId = Forum.CurrentQuestion.Answers.FirstOrDefault(c => c.Id == answerId);
                    if (currentId == null)
                    {
                        throw new CommandException(Messages.NoAnswer);
                    }

                    var currentUser = Forum.CurrentUser.Username;
                    var authorName = Forum.CurrentQuestion.Author.Username;
                    if (currentUser != authorName)
                    {
                        throw new CommandException(Messages.NoPermission);
                    }

                    var answer = Forum.CurrentQuestion.Answers.FirstOrDefault(a => a.Id == answerId);

                    if (answer == null)
                    {
                        throw new CommandException(Messages.NoAnswer);
                    }

                    // make best answer
                    var bestAnswer = new BestAnswer(answerId, answer.Body, Forum.CurrentUser);

                    Forum.Answers.Remove(answer);
                    Forum.Answers.Add(bestAnswer);

                    Forum.CurrentQuestion.Answers.Remove(answer);
                    Forum.CurrentQuestion.Answers.Add(bestAnswer);

                    string successBestAnswer = string.Format(Messages.BestAnswerSuccess, answerId);
                    Console.WriteLine(successBestAnswer);       
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