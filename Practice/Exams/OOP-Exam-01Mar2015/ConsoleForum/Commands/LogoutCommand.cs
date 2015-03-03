namespace ConsoleForum.Commands
{
    using System;
    using Contracts;

    class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (Forum.IsLogged)
            {
                Forum.CurrentUser = null;
                // Forum.CurrentQuestion = null;
                Console.WriteLine(Messages.LogoutSuccess);
            }
            else
            {
                throw new CommandException(Messages.NotLogged);
            }           
        }
    }
}