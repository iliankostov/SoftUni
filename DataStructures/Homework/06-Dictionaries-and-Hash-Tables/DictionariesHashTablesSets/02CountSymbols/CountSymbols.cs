namespace DictionariesHashTablesSets
{
    using System;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            CustomDictionary<char, int> customDictionary = new CustomDictionary<char, int>();
            string text = Console.ReadLine();

            foreach (char character in text)
            {
                if (!customDictionary.ContainsKey(character))
                {
                    customDictionary[character] = 0;
                }

                customDictionary[character]++;
            }

            var sortedCustomDictionary = customDictionary.OrderBy(cd => (int)cd.Key);

            foreach (var pair in sortedCustomDictionary)
            {
                Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
            }
        }
    }
}