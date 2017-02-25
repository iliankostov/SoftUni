namespace Football
{
    using System;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    public class ExportJSON
    {
        public static void Main()
        {
            var context = new FootballEntities();

            var leagues = context.Leagues
                .Select(l => new
                             {
                                 leagueName = l.LeagueName,
                                 teams = l.Teams
                                    .OrderBy(t => t.TeamName)
                                    .Select(t => t.TeamName)
                             })
                .OrderBy(l => l.leagueName);

            var jsonString = JsonConvert.SerializeObject(leagues);
            File.AppendAllText(@"..\..\leagues-and-teams.json", jsonString);
            Console.WriteLine("Export to leagues-and-teams.json completed!");
        }
    }
}
