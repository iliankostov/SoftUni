namespace UniLogger.Logger
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IList<IAppender> Appenders
        {
            get;
            set;
        }

        public void Info(string message)
        {
            this.Log(message, ReportLevel.Info);
        }

        public void Warn(string message)
        {
            this.Log(message, ReportLevel.Warning);
        }

        public void Error(string message)
        {
            this.Log(message, ReportLevel.Error);
        }

        public void Critical(string message)
        {
            this.Log(message, ReportLevel.Critical);
        }

        public void Fatal(string message)
        {
            this.Log(message, ReportLevel.Fatal);
        }

        private void Log(string msg, ReportLevel reportLevel)
        {
            var date = DateTime.Now;
            var @event = new Event(date, reportLevel, msg);
            foreach (var appender in this.Appenders)
            {
                appender.Append(@event);
            }
        }
    }
}