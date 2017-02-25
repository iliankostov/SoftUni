namespace Football
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ImportFromXML
    {
        public static void Main()
        {
            var context = new FootballEntities();
            var leaguesAndTeams = XDocument.Load(@"..\..\leagues-and-teams.xml");

            var xLeaguesAndTeams = leaguesAndTeams.XPathSelectElements("/leagues-and-teams/league");

            int count = 1;

            foreach (var xLeague in xLeaguesAndTeams)
            {
                Console.WriteLine("Processing league #{0} ...", count);

                League league = null;

                if (xLeague.Element("league-name") != null)
                {
                    var leagueName = xLeague.Element("league-name").Value;

                    var existingLeague = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);

                    if (existingLeague != null)
                    {
                        league = existingLeague;
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                    else
                    {
                        league = new League()
                                     {
                                         LeagueName = xLeague.Element("league-name").Value
                                     };
                        context.Leagues.Add(league);
                        Console.WriteLine("Created league: {0}", league.LeagueName);
                    }
                }

                if (xLeague.Element("teams") != null)
                {
                    var xTeams = xLeague.XPathSelectElements("teams/team");

                    foreach (var xTeam in xTeams)
                    {
                        var teamName = xTeam.Attribute("name").Value;
                        var teamCountry = xTeam.Attribute("country");

                        string countryName = null;
                        if (teamCountry != null)
                        {
                            countryName = teamCountry.Value;
                        }

                        Team team = context.Teams.FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == countryName);

                        if (team != null)
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamName, countryName ?? "no country");
                        }
                        else
                        {
                            team = new Team();
                            team.TeamName = teamName;
                            team.Country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);

                            context.Teams.Add(team);
                            Console.WriteLine("Created team: {0} ({1})", team.TeamName, countryName ?? "no country");
                        }

                        if (league != null)
                        {
                            if (team.Leagues.Contains(league))
                            {
                                Console.WriteLine("Existing team in league: {0} belongs to {1}",
                                    team.TeamName, league.LeagueName);
                            }
                            else
                            {
                                team.Leagues.Add(league);
                                context.SaveChanges();
                                Console.WriteLine("Added team to league: {0} to league {1}",
                                    team.TeamName, league.LeagueName);
                            }
                        }
                    }
                }

                context.SaveChanges();
                count++;
            }
        }
    }
}
