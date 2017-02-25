namespace NestedLoopsToRecursion
{
    using System;

    internal class NestedLoopsToRecursion
    {
        private static int[] arr;

        private static void GenerateVariationsWithRepetitions(int index, int n)
        {
            if (index >= n)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1, n);
                }
            }
        }

        private static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            arr = new int[n];
            GenerateVariationsWithRepetitions(0, n);
        }

        private static void PrintVariations()
        {
            Console.WriteLine("{0}", string.Join(" ", arr));
        }
    }
}