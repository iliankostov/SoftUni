namespace BattleShips.ConsoleClient.Core.Commands
{
    using BattleShips.ConsoleClient.Contracts;

    internal class ExitCommand : Command
    {
        public ExitCommand(IEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            this.Engine.Stop();
        }
    }
}