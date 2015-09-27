using System;
using System.Linq;

internal class CombinationsGeneratorWithReps
{
    private const int k = 3;

    private const int n = 5;

    private static string[] objects = new string[n] { "banana", "apple", "orange", "strawberry", "raspberry" };

    private static int[] arr = new int[k];

    private static void GenerateCombinationsNoRepetitions(int index, int start)
    {
        if (index >= k)
        {
            PrintCombinations();
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = i;
                GenerateCombinationsNoRepetitions(index + 1, i);
            }
        }
    }

    private static void Main()
    {
        GenerateCombinationsNoRepetitions(0, 0);
    }

    private static void PrintCombinations()
    {
        Console.WriteLine("({0}) --> ({1})", string.Join(", ", arr), string.Join(", ", arr.Select(i => objects[i])));
    }
}