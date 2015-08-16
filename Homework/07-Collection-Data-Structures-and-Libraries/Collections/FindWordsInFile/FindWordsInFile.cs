namespace FindWordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class FindWordsInFile
    {
        private static void Main()
        {
            Dictionary<string, int> wordsCountDictionary = new Dictionary<string, int>();
            StringBuilder output = new StringBuilder();

            Console.WriteLine("Input:");
            int textLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < textLines; i++)
            {
                string line = Console.ReadLine();
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    if (!wordsCountDictionary.ContainsKey(word))
                    {
                        wordsCountDictionary[word] = 0;
                    }

                    wordsCountDictionary[word]++;
                }
            }

            int searchWordsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < searchWordsCount; i++)
            {
                string searchWord = Console.ReadLine();
                if (wordsCountDictionary.ContainsKey(searchWord))
                {
                    output.AppendFormat("{0} -> {1}", searchWord, wordsCountDictionary[searchWord]).AppendLine();
                }
            }

            Console.WriteLine("\nOutput:\n{0}", output);
        }
    }
}