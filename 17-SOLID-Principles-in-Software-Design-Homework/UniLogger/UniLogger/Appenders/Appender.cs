namespace UniLogger.Appenders
{
    using Contracts;
    using Logger;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.All;
        }

        public ILayout Layout
        {
            get;
            set;
        }

        public ReportLevel ReportLevel
        {
            get;
            set;
        }

        public abstract void Append(IEvent @event);
    }
}