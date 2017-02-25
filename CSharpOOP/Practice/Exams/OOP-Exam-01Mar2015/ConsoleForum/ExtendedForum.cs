namespace ConsoleForum
{
    using System;
    using System.Linq;

    using ConsoleForum.Entities.Posts;

    public class ExtendedForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
            Console.WriteLine(Utility.Constants.WelcomeDelimeter);
            Console.WriteLine(
                this.IsLogged
                    ? string.Format(Messages.UserWelcomeMessage, this.CurrentUser.Username)
                    : Messages.GuestWelcomeMessage);

            int hotQuestion = this.Questions.Count(q => q.Answers.Any(a => a is BestAnswer));
            int activeUsers = this.Answers.GroupBy(a => a.Author.Id).Count(group => group.Count() >= 3);

            Console.WriteLine(Messages.GeneralHeaderMessage, hotQuestion, activeUsers);
            Console.WriteLine(Utility.Constants.WelcomeDelimeter);
            base.ExecuteCommandLoop();
        }
    }
}
