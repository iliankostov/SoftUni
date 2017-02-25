namespace RopeEfficientStringEditing
{
    using System;
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class RopeEfficientStringEditing
    {
        private static void Main()
        {
            var rope = new BigList<char>();
            string command = string.Empty;
            while (command != "PRINT")
            {
                var input = Console.ReadLine().Split(' ');
                command = input[0].ToUpper();

                switch (command)
                {
                    case "INSERT":
                        var frontChars = input[1].Select(ch => ch);
                        rope.AddRangeToFront(frontChars);
                        Console.WriteLine("OK");
                        break;
                    case "APPEND":
                        var endChars = input[1].Select(ch => ch);
                        rope.AddRange(endChars);
                        Console.WriteLine("OK");
                        break;
                    case "DELETE":
                        int startIndex = int.Parse(input[1]);
                        int count = int.Parse(input[2]);
                        try
                        {
                            rope.RemoveRange(startIndex, count);
                            Console.WriteLine("OK");
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("ERROR");
                        }

                        break;
                    case "PRINT":
                        Console.WriteLine(string.Join(string.Empty, rope));
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}