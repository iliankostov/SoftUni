namespace UniLogger.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format(IEvent @event)
        {
            return string.Format("{0} - {1} - {2}", @event.DateAndTime, @event.ReportLevel, @event.Message);
        }
    }
}