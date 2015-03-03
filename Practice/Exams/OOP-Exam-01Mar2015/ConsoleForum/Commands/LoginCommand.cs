namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using Utility;


    class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = Data[1];
            string password = PasswordUtility.Hash(Data[2]);
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
            if (Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            Forum.CurrentUser = user;
            string loginSuccess = string.Format(Messages.LoginSuccess, username); 
            Console.WriteLine(loginSuccess);
        }
    }
}