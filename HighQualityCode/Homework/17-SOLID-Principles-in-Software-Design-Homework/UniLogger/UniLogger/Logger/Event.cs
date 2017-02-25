namespace UniLogger.Logger
{
    using System;
    using Contracts;

    internal class Event : IEvent
    {
        public Event(DateTime date, ReportLevel reportLevel, string message)
        {
            this.DateAndTime = date;
            this.ReportLevel = reportLevel;
            this.Message = message;
        }

        public DateTime DateAndTime
        {
            get;
            set;
        }

        public ReportLevel ReportLevel
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}