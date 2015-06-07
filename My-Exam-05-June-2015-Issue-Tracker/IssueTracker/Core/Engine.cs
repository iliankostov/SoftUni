namespace IssueTracker.Core
{
    using System;

    using IssueTracker.Contracts;

    public class Engine : IEngine
    {
        private readonly CommandProcessor commandProcessor;

        public Engine(CommandProcessor commandProcessor)
        {
            this.commandProcessor = commandProcessor;
        }

        public Engine()
            : this(new CommandProcessor())
        {
        }

        // Bug: url must be equea to null for break.
        // Bug: url must be different from null or empty
        public void Run()
        {
            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var command = new Command(url);
                        string viewResult = this.commandProcessor.ProcessCommand(command);
                        Console.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}