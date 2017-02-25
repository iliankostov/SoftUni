namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestCommonSubsequence
    {
        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int firstLen = firstStr.Length + 1;
            int secondLen = secondStr.Length + 1;
            var lcs = new int[firstLen, secondLen];

            for (int i = 1; i < firstLen; i++)
            {
                for (int j = 1; j < secondLen; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            var sequence = new List<char>();

            var first = firstStr.Length;
            var second = secondStr.Length;

            while (first > 0 && second > 0)
            {
                if (firstStr[first - 1] == secondStr[second - 1])
                {
                    sequence.Add(firstStr[first - 1]);
                    first--;
                    second--;
                }
                else if (lcs[first, second] == lcs[first - 1, second])
                {
                    first--;
                }
                else
                {
                    second--;
                }
            }

            sequence.Reverse();
            return new string(sequence.ToArray());
        }

        public static void Main()
        {
            Console.Write("firstStr = ");
            var firstStr = Console.ReadLine();
            Console.Write("secondStr = ");
            var secondStr = Console.ReadLine();

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }
    }
}