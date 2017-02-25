namespace GenerateVariationsWithRepetition
{
    using System;

    internal class VariationsWithRepetition
    {
        private static void GenerateVarWithRepetition(int[] arr, int sizeOfSet, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    arr[index] = i;
                    GenerateVarWithRepetition(arr, sizeOfSet, index + 1);
                }
            }
        }

        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];

            GenerateVarWithRepetition(arr, n);
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}