namespace UniLogger.Layouts
{
    using System.Text;
    using Contracts;

    public class XmlLayout : ILayout
    {
        public string Format(IEvent @event)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("<log>");
            output.AppendFormat("   <date>{0}</date>", @event.DateAndTime).AppendLine();
            output.AppendFormat("   <level>{0}</level>", @event.ReportLevel).AppendLine();
            output.AppendFormat("   <message>{0}</message>", @event.Message).AppendLine();
            output.Append("</log>");

            return output.ToString();
        }
    }
}