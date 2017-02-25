namespace Diablo
{
    using System;
    using System.Linq;

    public class DiabloCharacters
    {
        public static void Main()
        {
            var context = new DiabloEntities();

            var characterNames = context.Characters.Select(ch => ch.Name);

            foreach (var characterName in characterNames)
            {
                Console.WriteLine(characterName);
            }
        }
    }
}
