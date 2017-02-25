namespace GenerateSubsetsOfStringArray
{
    using System;
    using System.Linq;

    internal class GenerateSubsetsOfStringArray
    {
        private const int K = 2;

        private static readonly string[] Objects = { "test", "rock", "fun" };

        private static readonly int N = Objects.Length;

        private static readonly int[] Array = new int[K];

        private static void GenerateSubsets(int index, int start)
        {
            if (index >= K)
            {
                Console.WriteLine("({0})", string.Join(", ", Array.Select(i => Objects[i])));
            }
            else
            {
                for (int i = start; i < N; i++)
                {
                    Array[index] = i;
                    GenerateSubsets(index + 1, i + 1);
                }
            }
        }

        private static void Main()
        {
            GenerateSubsets(0, 0);
        }
    }
}