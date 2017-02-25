namespace IssueTracker
{
    using System.Globalization;
    using System.Threading;
    using Core;

    internal class IssueTrackerMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Engine engine = new Engine();
            engine.Run();
        }
    }
}