namespace IssueTracker.Core
{
    using System;
    using Contracts;
    using UserInterface;

    public class Engine : IEngine
    {
        private readonly EndpointActionDispatcher commandProcessor;

        private readonly IUserInterface ui;

        public Engine(EndpointActionDispatcher commandProcessor, IUserInterface ui)
        {
            this.commandProcessor = commandProcessor;
            this.ui = ui;
        }

        public Engine()
            : this(new EndpointActionDispatcher(), new ConsoleUserInterface())
        {
            // DI: Added IUserInterface and ConsoleUserInterface types
        }

        // Bug: url must be equea to null for break.
        // Bug: url must be different from null or empty
        public void Run()
        {
            while (true)
            {
                string url = this.ui.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        Endpoint command = new Endpoint(url);
                        string viewResult = this.commandProcessor.ProcessCommand(command);
                        this.ui.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        this.ui.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}