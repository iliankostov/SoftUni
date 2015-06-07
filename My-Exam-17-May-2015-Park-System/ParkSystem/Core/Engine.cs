namespace ParkSystem.Core
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private ProcessCommand ex;

        public Engine()
        {
            this.ex = new ProcessCommand();
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.ex.Output(command);
                        Console.WriteLine(commandResult);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}