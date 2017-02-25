namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ArrayManipulator
    {
        private static List<long> collection;

        private static void ExecuteCommand(string[] commandArgs)
        {
            string operation = commandArgs[0].Trim();

            switch (operation)
            {
                case "exchange":
                    ExecuteExchangeCommand(commandArgs);
                    break;
                case "max":
                    ExecuteMaxCommand(commandArgs);

                    break;
                case "min":
                    ExecuteMinCommand(commandArgs);

                    break;
                case "first":
                    ExecuteFirstCommand(commandArgs);

                    break;
                case "last":
                    ExecuteLastCommand(commandArgs);

                    break;
            }
        }

        private static void ExecuteExchangeCommand(string[] commandArgs)
        {
            long index = int.Parse(commandArgs[1].Trim());

            if (index < collection.Count)
            {
                var queue = new Queue<long>(collection);
                for (int i = 0; i <= index; i++)
                {
                    long element = queue.Dequeue();
                    queue.Enqueue(element);
                }

                collection = new List<long>(queue);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        private static void ExecuteFirstCommand(string[] commandArgs)
        {
            long count = long.Parse(commandArgs[1].Trim());
            if (count <= collection.Count)
            {
                string eo = commandArgs[2].Trim();
                var result = new List<long>();
                if (eo == "even")
                {
                    foreach (var element in collection)
                    {
                        if (result.Count < 2 && element % 2 == 0)
                        {
                            result.Add(element);
                        }
                    }
                }

                if (eo == "odd")
                {
                    foreach (var element in collection)
                    {
                        if (result.Count < 2 && element % 2 == 1)
                        {
                            result.Add(element);
                        }
                    }
                }

                Console.WriteLine("[{0}]", string.Join(", ", result));
            }
            else
            {
                Console.WriteLine("Invalid count");
            }
        }

        private static void ExecuteLastCommand(string[] commandArgs)
        {
            long count = long.Parse(commandArgs[1].Trim());
            if (count <= collection.Count)
            {
                var result = new List<long>();
                string eo = commandArgs[2].Trim();
                if (eo == "even")
                {
                    result.AddRange(collection.Where(element => element % 2 == 0));
                }

                if (eo == "odd")
                {
                    result.AddRange(collection.Where(element => element % 2 == 1));
                }

                int skip = (int)(result.Count - count);

                Console.WriteLine("[{0}]", string.Join(", ", result.Skip(skip)));
            }
            else
            {
                Console.WriteLine("Invalid count");
            }
        }

        private static void ExecuteMaxCommand(string[] commandArgs)
        {
            var list = new List<long>(collection);
            long maxElement = long.MinValue;
            long? index = null;

            if (commandArgs[1].Trim() == "even")
            {
                foreach (var element in list)
                {
                    if (element % 2 == 0 && element > maxElement)
                    {
                        maxElement = element;
                        index = list.IndexOf(maxElement);
                    }
                }
            }

            if (commandArgs[1].Trim() == "odd")
            {
                foreach (var element in list)
                {
                    if (element % 2 == 1 && element > maxElement)
                    {
                        maxElement = element;
                        index = list.IndexOf(maxElement);
                    }
                }
            }

            if (index != null)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void ExecuteMinCommand(string[] commandArgs)
        {
            var list = new List<long>(collection);
            long minElement = long.MaxValue;
            long? index = null;

            if (commandArgs[1].Trim() == "even")
            {
                foreach (var element in list)
                {
                    if (element % 2 == 0 && element < minElement)
                    {
                        minElement = element;
                        index = list.IndexOf(minElement);
                    }
                }
            }

            if (commandArgs[1].Trim() == "odd")
            {
                foreach (var element in list)
                {
                    if (element % 2 == 1 && element < minElement)
                    {
                        minElement = element;
                        index = list.IndexOf(minElement);
                    }
                }
            }

            if (index != null)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void Main()
        {
            collection =
                Console.ReadLine()
                    .Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                ExecuteCommand(command.Split(new char[] {}, StringSplitOptions.RemoveEmptyEntries));

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", collection));
        }
    }
}