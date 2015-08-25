namespace BattleShips.ConsoleClient.Core.Commands
{
    using BattleShips.ConsoleClient.Contracts;

    public abstract class Command : ICommand
    {
        protected Command(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine { get; private set; }

        public abstract void Execute(string[] commandArgs);
    }
}