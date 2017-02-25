using System;
using System.Collections.Generic;

internal class LongestIncreasingSubsequenceRecursive
{
    private const int NO_PREVIOUS = -1;

    private static int[] seq = { 3, 4, 8, 1, 2, 4, 32, 6, 2, 5, 33, 4, 38, 22 };

    private static int[] len = new int[seq.Length];

    private static int[] prev = new int[seq.Length];

    private static void CalcLongestIncreasingSubsequence(int x)
    {
        if (len[x] > 0)
        {
            // Memoization: if aLready calculated --> exit
            return;
        }

        len[x] = 1;
        for (int i = 0; i <= x - 1; i++)
        {
            if (seq[i] < seq[x])
            {
                CalcLongestIncreasingSubsequence(i);
                if (len[i] + 1 > len[x])
                {
                    len[x] = len[i] + 1;
                    prev[x] = i;
                }
            }
        }
    }

    private static int FindMaxElementIndex(int[] seq)
    {
        int maxElement = seq[0];
        int maxElementIndex = 0;
        for (int i = 0; i < seq.Length; i++)
        {
            if (seq[i] > maxElement)
            {
                maxElement = seq[i];
                maxElementIndex = i;
            }
        }
        return maxElementIndex;
    }

    private static void Main()
    {
        for (int i = 0; i < seq.Length; i++)
        {
            prev[i] = NO_PREVIOUS;
        }

        for (int i = 0; i < seq.Length; i++)
        {
            CalcLongestIncreasingSubsequence(i);
        }

        Console.WriteLine("seq = " + String.Join(", ", seq));
        Console.WriteLine("len = " + String.Join(", ", len));
        Console.WriteLine("prev = " + String.Join(", ", prev));

        int maxElementIndex = FindMaxElementIndex(seq);

        PrintLongestIncreasingSubsequence(seq, prev, maxElementIndex);
    }

    private static void PrintLongestIncreasingSubsequence(int[] seq, int[] prev, int index)
    {
        List<int> lis = new List<int>();
        while (index != NO_PREVIOUS)
        {
            lis.Add(seq[index]);
            index = prev[index];
        }
        lis.Reverse();
        Console.WriteLine("subsequence = [{0}]", string.Join(", ", lis));
    }
}