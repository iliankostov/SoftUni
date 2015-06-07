namespace IssueTracker
{
    using System.Globalization;
    using System.Threading;

    using IssueTracker.Core;

    internal class IssueTrackerMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new Engine();
            engine.Run();
        }
    }
}