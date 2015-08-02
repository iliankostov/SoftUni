namespace Diablo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    public class ExportJSON
    {
        public static void Main()
        {
            var context = new DiabloEntities();

            var characters = context.Characters
                .OrderBy(ch => ch.Name)
                .Select(ch => new
                              {
                                  name = ch.Name,
                                  playedBy = ch.UsersGames.Select(u => u.User.Username)
                              });

            JavaScriptSerializer js = new JavaScriptSerializer();

            var charactersJson = js.Serialize(characters);

            File.AppendAllText(@"..\..\characters.json", charactersJson);
            Console.WriteLine("Export characters.json complited!");
        }
    }
}
