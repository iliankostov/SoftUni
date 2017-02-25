namespace UniLogger.Appenders
{
    using System;
    using Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {   
        }

        public override void Append(IEvent @event)
        {
            if (this.ReportLevel <= @event.ReportLevel)
            {
                var formatedMessages = this.Layout.Format(@event);
                Console.WriteLine(formatedMessages);
            }           
        }
    }
}