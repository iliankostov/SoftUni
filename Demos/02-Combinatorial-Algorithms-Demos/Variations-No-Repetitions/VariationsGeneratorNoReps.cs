using System;
using System.Linq;

internal class VariationsGeneratorNoReps
{
    private const int k = 2;

    private const int n = 10;

    private static string[] objects = new string[n]
                                          {
                                              "banana", "apple", "orange", "strawberry", "raspberry", "apricot", "cherry",
                                              "lemon", "grapes", "melon"
                                          };

    private static int[] arr = new int[k];

    private static bool[] used = new bool[n];

    private static void GenerateVariationsNoRepetitions(int index)
    {
        if (index >= k)
        {
            PrintVariations();
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[index] = i;
                    GenerateVariationsNoRepetitions(index + 1);
                    used[i] = false;
                }
            }
        }
    }

    private static void Main()
    {
        GenerateVariationsNoRepetitions(0);
    }

    private static void PrintVariations()
    {
        Console.WriteLine("({0}) --> ({1})", string.Join(", ", arr), string.Join(", ", arr.Select(i => objects[i])));
    }
}