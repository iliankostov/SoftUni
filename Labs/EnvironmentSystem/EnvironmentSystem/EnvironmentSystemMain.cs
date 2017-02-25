namespace EnvironmentSystem
{
    using EnvironmentSystem.Core;

    public class EnvironmentSystemMain
    {
        static void Main()
        {
            var keyboardController = new KeyboardController();
            var engine = new AdvancedEngine(keyboardController);
            engine.Run();
        }
    }
}
