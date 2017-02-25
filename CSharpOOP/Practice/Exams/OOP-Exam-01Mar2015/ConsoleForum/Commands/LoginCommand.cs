namespace ConsoleForum.Commands
{
    using System.Linq;

    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(Messages.AlreadyLoggedIn);
            }

            var currentUser = users.FirstOrDefault(u => u.Username == username && u.Password == password) as User;
            if (currentUser == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            this.Forum.CurrentUser = currentUser;
            this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, username));
        }
    }
}
