namespace Diablo
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ImportFromXML
    {
        public static void Main()
        {
            var context = new DiabloEntities();

            var xDocument = XDocument.Load(@"..\..\users-and-games.xml");

            var xUsers = xDocument.XPathSelectElements("/users/user");

            foreach (var xUser in xUsers)
            {
                var xGames = xUser.XPathSelectElements("games/game");

                bool gameFail = false;

                using (var dbContextTransactions = context.Database.BeginTransaction())
                {
                    var user = CreateUser(xUser, context);

                    foreach (var xGame in xGames)
                    {
                        gameFail = CreateGame(xGame, context, user, gameFail);
                    }

                    if (gameFail)
                    {
                        dbContextTransactions.Rollback();
                    }
                    else
                    {
                        dbContextTransactions.Commit();
                    }
                }              
            }
        }

        private static bool CreateGame(XElement xGame, DiabloEntities context, User user, bool gameFail)
        {
            var gameName = xGame.Element("game-name").Value;
            var characterName = xGame.Element("character").Attribute("name").Value;
            var characterCash = decimal.Parse(xGame.Element("character").Attribute("cash").Value);
            var characterLevel = int.Parse(xGame.Element("character").Attribute("level").Value);
            DateTime gameJoinedOn;
            bool isValidDate = DateTime.TryParse(xGame.Element("joined-on").Value, out gameJoinedOn);

            Game game = context.Games.FirstOrDefault(g => g.Name == gameName);
            var characterId = context.Characters
                .Where(ch => ch.Name == characterName)
                .Select(ch => ch.Id)
                .FirstOrDefault();

            if (game != null && user != null && characterCash >= 0 && isValidDate)
            {
                UsersGame usersGame = new UsersGame();
                usersGame.GameId = game.Id;
                usersGame.CharacterId = characterId;
                usersGame.Cash = characterCash;
                usersGame.Level = characterLevel;
                usersGame.JoinedOn = gameJoinedOn;
                usersGame.UserId = user.Id;

                context.UsersGames.Add(usersGame);
                context.SaveChanges();
                Console.WriteLine("User {0} successfully added to game {1}", user.Username, game.Name);
            }
            else
            {
                gameFail = true;
            }

            return gameFail;
        }

        private static User CreateUser(XElement xUser, DiabloEntities context)
        {
            User user;
            var xUsername = xUser.Attribute("username").Value;

            if (!context.Users.Any(u => u.Username == xUsername))
            {
                user = new User();

                user.FirstName = null;
                if (xUser.Attribute("first-name") != null)
                {
                    user.FirstName = xUser.Attribute("first-name").Value;
                }

                user.LastName = null;
                if (xUser.Attribute("last-name") != null)
                {
                    user.LastName = xUser.Attribute("last-name").Value;
                }

                user.Email = null;
                if (xUser.Attribute("email") != null)
                {
                    user.Email = xUser.Attribute("email").Value;
                }

                user.Username = xUsername;
                user.IsDeleted = xUser.Attribute("is-deleted").Value != "0";
                user.IpAddress = xUser.Attribute("ip-address").Value;
                user.RegistrationDate = Convert.ToDateTime(xUser.Attribute("registration-date").Value);

                context.Users.Add(user);
                Console.WriteLine("Successfully added user {0}", user.Username);
                context.SaveChanges();
                return user;
            }

            Console.WriteLine("User {0} already exists", xUsername);
            return null;
        }
    }
}
