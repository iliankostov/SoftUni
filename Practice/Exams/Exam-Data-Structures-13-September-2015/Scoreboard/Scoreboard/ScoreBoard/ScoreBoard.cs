namespace ScoreBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Schema;
    using Wintellect.PowerCollections;

    public class ScoreBoard
    {
        private static HashSet<User> users = new HashSet<User>();

        private static HashSet<Game> games = new HashSet<Game>();

        private static Dictionary<Game, OrderedBag<int>> scoresByGames = new Dictionary<Game, OrderedBag<int>>();

        private static Dictionary<Game, OrderedDictionary<int, OrderedBag<User>>> scoreboard =
            new Dictionary<Game, OrderedDictionary<int, OrderedBag<User>>>();

        private static void Main()
        {
            string command = string.Empty;

            while (command != "End")
            {
                var args = Console.ReadLine().Split(' ');
                command = args[0];
                switch (command)
                {
                    case "RegisterUser":
                        Console.WriteLine(RegisterUser(args[1], args[2]));
                        break;
                    case "RegisterGame":
                        Console.WriteLine(RegisterGame(args[1], args[2]));
                        break;
                    case "AddScore":
                        Console.WriteLine(AddScore(args[1], args[2], args[3], args[4], args[5]));
                        break;
                    case "ShowScoreboard":
                        Console.WriteLine(ShowScoreboard(args[1]));
                        break;
                    case "ListGamesByPrefix":
                        Console.WriteLine(ListGamesByPrefix(args[1]));
                        break;
                    case "DeleteGame":
                        Console.WriteLine(DeleteGame(args[1], args[2]));
                        break;
                    case "End":
                        break;
                    default:
                        break;
                }
            }
        }

        private static string RegisterUser(string username, string password)
        {
            var user = new User
            {
                Username = username,
                Password = password
            };

            if (users.Contains(user))
            {
                return "Duplicated user";
            }

            users.Add(user);
            return "User registered";
        }

        private static string RegisterGame(string gameName, string password)
        {
            var game = new Game
            {
                GameName = gameName,
                GamePassword = password
            };

            if (games.Contains(game))
            {
                return "Duplicated game";
            }

            games.Add(game);
            return "Game registered";
        }

        private static string ListGamesByPrefix(string prefix)
        {
            var result = games
                .Where(g => g.GameName.Substring(0, prefix.Length) == prefix)
                .OrderBy(g => g.GameName)
                .Take(10)
                .ToList();

            if (!result.Any())
            {
                return "No matches";
            }

            return string.Join(", ", result);
        }

        private static string DeleteGame(string gameName, string gamePassword)
        {
            var game = games.FirstOrDefault(g => g.GameName == gameName && g.GamePassword == gamePassword);
            if (game == null)
            {
                return "Cannot delete game";
            }

            games.Remove(game);
            scoresByGames.Remove(game);
            scoreboard.Remove(game);
            return "Game deleted";
        }

        private static string AddScore(string username, string userPassword, string gameName, string gamePassword, string scoreString)
        {
            var score = int.Parse(scoreString);

            var user = users.FirstOrDefault(u => u.Username == username && u.Password == userPassword);
            if (user == null)
            {
                return "Cannot add score";
            }

            var game = games.FirstOrDefault(g => g.GameName == gameName && g.GamePassword == gamePassword);
            if (game == null)
            {
                return "Cannot add score";
            }

            if (!scoresByGames.ContainsKey(game))
            {
                scoresByGames[game] = new OrderedBag<int>();
            }

            scoresByGames[game].Add(score);

            if (!scoreboard.ContainsKey(game))
            {
                scoreboard[game] = new OrderedDictionary<int, OrderedBag<User>>();
            }

            if (!scoreboard[game].ContainsKey(score))
            {
                scoreboard[game][score] = new OrderedBag<User>();
            }

            scoreboard[game][score].Add(user);

            return "Score added";
        }

        private static string ShowScoreboard(string gameName)
        {
            var game = games.FirstOrDefault(g => g.GameName == gameName);
            if (game == null)
            {
                return "Game not found";
            }

            if (!scoreboard.ContainsKey(game))
            {
                return "No score";
            }

            var topTenScore = scoresByGames[game].Reversed().Take(10).ToList();

            var view = scoreboard[game].Range(topTenScore.Min(), true, topTenScore.Max(), true);

            var result = new List<string>();

            foreach (var keyValuePair in view.Reversed())
            {
                var score = keyValuePair.Key;

                foreach (var user in keyValuePair.Value)
                {
                    if (result.Count == 10)
                    {
                        break;
                    }

                    result.Add(string.Format("#{0} {1} {2}", result.Count + 1, user.Username, score));
                }
            }

            return string.Join(Environment.NewLine, result);
        }
    }

    public class Game : IEquatable<Game>
    {
        public string GameName { get; set; }

        public string GamePassword { get; set; }

        public bool Equals(Game other)
        {
            return this.GameName.Equals(other.GameName);
        }

        public override int GetHashCode()
        {
            return this.GameName.GetHashCode();
        }

        public override string ToString()
        {
            return this.GameName;
        }
    }

    public class User : IComparable<User>, IEquatable<User>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int CompareTo(User other)
        {
            return this.Username.CompareTo(other.Username);
        }

        public bool Equals(User other)
        {
            return this.Username.Equals(other.Username);
        }

        public override int GetHashCode()
        {
            return this.Username.GetHashCode();
        }
    }
}