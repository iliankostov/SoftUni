using System;

public class LongestWordInAText
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string line = input.Trim('.');
        string[] list = line.Split(' ');
        string maxWord = list[0];
        foreach (string word in list)
        {
            if (word.Length > maxWord.Length)
            {
                maxWord = word;
            }
        }
        Console.WriteLine(maxWord);
    }
}