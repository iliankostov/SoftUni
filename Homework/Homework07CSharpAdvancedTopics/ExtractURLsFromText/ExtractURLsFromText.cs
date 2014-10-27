using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string line = Console.ReadLine();
        string[] list = line.Split(' ');
        List<string> newList = new List<string> { };
        foreach (string word in list)
        {
            if (!newList.Contains(word) && word.Length > 6)
            {
                if (word.Substring(0, 7) == "http://" || word.Substring(0, 4) == "www.")
                {
                    newList.Add(word);
                }
            }
        }
        foreach (string word in newList)
        {
            Console.WriteLine(word);
        }
    }
}