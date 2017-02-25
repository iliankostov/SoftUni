namespace Football
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExportXML
    {
        public static void Main()
        {
            var context = new FootballEntities();

            var internationalMatches = context.InternationalMatches
                .Select(
                    im => new
                              {
                                  HomeCountryName = im.HomeCountry.CountryName,
                                  HomeCountryCode = im.HomeCountry.CountryCode,
                                  AwayCountryName = im.AwayCountry.CountryName,
                                  AwayCountryCode = im.AwayCountry.CountryCode,
                                  League = im.League.LeagueName,
                                  HomeGoals = im.HomeGoals,
                                  AwayGoals = im.AwayGoals,
                                  MatchDate = im.MatchDate
                              })
                              .OrderBy(im => im.MatchDate)
                              .ThenBy(im => im.HomeCountryName)
                              .ThenBy(im => im.AwayCountryName);

            var xMatches = new XElement("matches");

            foreach (var match in internationalMatches)
            {
                var xMatch = new XElement("match");

                if (match.MatchDate != null)
                {
                    DateTime dateTime;
                    DateTime.TryParse(match.MatchDate.ToString(), out dateTime);
                    if (dateTime.TimeOfDay.TotalSeconds == 0)
                    {
                        var xDate = new XAttribute("date", dateTime.ToString("dd-MMM-yyyy"));
                        xMatch.Add(xDate);
                    }
                    else
                    {
                        var xDateTime = new XAttribute("date-time", dateTime.ToString("dd-MMM-yyyy HH:MM"));
                        xMatch.Add(xDateTime);
                    }
                }

                xMatch.Add(new XElement("home-country", match.HomeCountryName, new XAttribute("code", match.HomeCountryCode)));
                xMatch.Add(new XElement("away-country", match.AwayCountryName, new XAttribute("code", match.AwayCountryCode)));

                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    xMatch.Add(new XElement("score", string.Format("{0}-{1}", match.HomeGoals, match.AwayGoals)));
                }

                if (match.League != null)
                {
                    xMatch.Add(new XElement("league", match.League));
                }

                xMatches.Add(xMatch);
            }

            new XDocument(xMatches).Save(@"..\..\international-matches.xml");
            Console.WriteLine("Export to international-matches.xml complited!");
        }
    }
}
