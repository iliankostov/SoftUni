namespace UniLoggerMain
{
    using UniLogger.Appenders;
    using UniLogger.Contracts;
    using UniLogger.Layouts;
    using UniLogger.Logger;

    internal class UniLoggerMain
    {
        public static void Main()
        {
            //// Test 1
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("Error parsing JSON.");
            //logger.Info(string.Format("User {0} successfully registered.", "Pesho"));

            // Test 2
            var simpleLayout = new SimpleLayout();

            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout) { File = "log.txt" };

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info(string.Format("User {0} successfully registered.", "Pesho"));
            logger.Warn("Warning - missing files.");

            //// Test 3
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);

            //logger.Fatal("mscorlib.dll does not respond");
            //logger.Critical("No connection string found in App.config");

            //// Test 4
            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("Everything seems fine");
            //logger.Warn("Warning: ping is too high - disconnect imminent");
            //logger.Error("Error parsing request");
            //logger.Critical("No connection string found in App.config");
            //logger.Fatal("mscorlib.dll does not respond");
        }
    }
}