namespace MassEffect.Engine.Commands
{
    using Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }
    }
}
