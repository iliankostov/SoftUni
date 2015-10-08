namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CommandInterpreter
    {
        private static void Main()
        {
            var line = Console.ReadLine();
            var stringArray = line.Split(' ');
            var array = stringArray.Select(e => int.Parse(e.Trim()));

            while (line != "end")
            {
                line = Console.ReadLine();
                var command = line.Split(' ');
                switch (command[0])
                {
                    case "reverse":
                        var start = int.Parse(command[2].Trim());
                        var count = int.Parse(command[4].Trim());
                        ReverseArray(array, start, count);
                        break;
                    case "sort":
                        break;
                    case "rollLeft":
                        break;
                    case "rollRight":
                        break;
                    default:
                        Console.WriteLine("Invalid input parameters.");
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static void ReverseArray(IEnumerable<int> array, int start, int count)
        {
            
        }
    }
}