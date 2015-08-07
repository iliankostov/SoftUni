namespace DictionariesHashTablesSets
{
    using System;
    using System.Linq;

    internal class Phonebook
    {
        public static void Main()
        {
            string input = string.Empty;
            var customDictionary = new CustomDictionary<string, string>();

            while (input != "search")
            {
                input = Console.ReadLine();

                if (input != "search")
                {
                    if (input.Contains("-"))
                    {
                        string[] keyValue = input.Split('-');
                        string name = keyValue[0].Trim();
                        string phone = keyValue[1].Trim();

                        bool isExist = customDictionary.AddOrReplace(name, phone);
                        Console.WriteLine(!isExist ? "Successfully add " + name : "Successfully update " + name);
                    }
                    else
                    {
                        Console.WriteLine("Wrong input format!");
                    }
                }
            }

            Console.WriteLine();
            while (input != string.Empty)
            {
                input = Console.ReadLine().Trim();

                if (input != string.Empty)
                {
                    var result = customDictionary.FirstOrDefault(cd => cd.Key == input);
                    if (result != null)
                    {
                        Console.WriteLine("{0} -> {1}", result.Key, result.Value);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exist.", input);
                    }
                }
            }
        }
    }
}