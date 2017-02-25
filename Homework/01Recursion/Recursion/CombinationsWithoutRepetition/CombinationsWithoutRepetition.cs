namespace CombinationsWithoutRepetition
{
    using System;

    internal class CombinationsWithoutRepetition
    {
        private static int[] arr;

        private static void GenerateCombinationsWithoutRepetitions(int index, int start, int n, int k)
        {
            if (index >= k)
            {
                PrintCombination();
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsWithoutRepetitions(index + 1, i + 1, n, k);
                }
            }
        }

        private static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            arr = new int[k];

            GenerateCombinationsWithoutRepetitions(0, 1, n, k);
        }

        private static void PrintCombination()
        {
            Console.WriteLine("{0}", string.Join(", ", arr));
        }
    }
}