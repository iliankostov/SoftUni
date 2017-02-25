namespace UniLogger.Appenders
{
    using System.IO;
    using Contracts;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string File
        {
            get;
            set;
        }

        public override void Append(IEvent @event)
        {
            if (this.ReportLevel <= @event.ReportLevel)
            {
                var formatedMessages = this.Layout.Format(@event);
                var path = @"../../" + this.File;

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine(formatedMessages);
                }
            }           
        }
    }
}