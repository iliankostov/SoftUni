namespace EventsInGivenDateRange
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    using Wintellect.PowerCollections;

    internal class EventsInGivenDateRange
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var events = new OrderedMultiDictionary<DateTime, string>(true);
            StringBuilder output = new StringBuilder();

            Console.WriteLine("Input:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string eventEntry = Console.ReadLine();
                var eventTokens = eventEntry.Split('|');
                string eventName = eventTokens[0].Trim();
                DateTime eventDate = DateTime.Parse(eventTokens[1].Trim());
                events.Add(eventDate, eventName);
            }

            int d = int.Parse(Console.ReadLine());
            for (int i = 0; i < d; i++)
            {
                string datesLine = Console.ReadLine();
                var dates = datesLine.Split('|');
                DateTime startDate = DateTime.Parse(dates[0].Trim());
                DateTime endDate = DateTime.Parse(dates[1].Trim());

                var eventsInRange = events.Range(startDate, true, endDate, true);

                output.AppendLine(eventsInRange.KeyValuePairs.Count.ToString());
                foreach (var e in eventsInRange)
                {
                    foreach (var eventName in e.Value)
                    {
                        output.AppendFormat("{0} | {1:dd-MMM-yyyy}", eventName, e.Key).AppendLine();
                    }
                }
            }

            Console.WriteLine("\nOutput:");
            Console.WriteLine(output.ToString());
        }
    }
}