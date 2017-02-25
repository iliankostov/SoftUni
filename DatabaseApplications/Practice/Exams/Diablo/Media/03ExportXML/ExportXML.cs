namespace Diablo
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExportXML
    {
        public static void Main()
        {
            var context = new DiabloEntities();

            var finishedGames = context.Games
                .Where(g => g.IsFinished)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Duration)
                .Select(g => new
                             {
                                 GameName = g.Name,
                                 Duration = g.Duration,
                                 Users = g.UsersGames.Select(u => new
                                                                      {
                                                                          Username = u.User.Username,
                                                                          IpAddress = u.User.IpAddress
                                                                      })
                             });

            var xGames = new XElement("games");

            foreach (var finishedGame in finishedGames)
            {
                var xGame = new XElement("game");
                xGame.Add(new XAttribute("name", finishedGame.GameName));

                if (finishedGame.Duration != null)
                {
                    xGame.Add(new XAttribute("duration", finishedGame.Duration));
                }

                var xUsers = new XElement("users");
                foreach (var user in finishedGame.Users)
                {
                    var xUser = new XElement(
                        "user", 
                        new XAttribute("username", user.Username), 
                        new XAttribute("ip-address", user.IpAddress));
                    xUsers.Add(xUser);
                }

                xGame.Add(xUsers);
                xGames.Add(xGame);
            }

            new XDocument(xGames).Save(@"..\..\finished-games.xml");
            Console.WriteLine("Export finished-games.xml complited!");
        }
    }
}
