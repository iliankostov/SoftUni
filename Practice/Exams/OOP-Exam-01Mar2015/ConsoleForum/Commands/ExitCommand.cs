namespace ConsoleForum.Commands
{
    using Contracts;

    class ExitCommand : AbstractCommand
    {
        public ExitCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            Forum.HasStarted = false;
        }
    }
}
