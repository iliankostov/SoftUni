namespace UniLogger.Contracts
{
    using System;
    using Logger;

    public interface IEvent
    {
        DateTime DateAndTime
        {
            get;
            set;
        }

        ReportLevel ReportLevel
        {
            get;
            set;
        }

        string Message
        {
            get;
            set;
        }
    }
}