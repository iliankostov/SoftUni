namespace PermutationsWithRepetition
{
    using System;

    internal class PermutationsWithRepetition
    {
        private static void Main()
        {
            Console.Write("Select array 1 or 2: ");
            int arrayNumber = int.Parse(Console.ReadLine());

            var arrayOne = new[] { 1, 3, 5, 5 };
            var arrayTwo = new[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            int[] array = null;

            if (arrayNumber == 1)
            {
                array = arrayOne;
            }

            if (arrayNumber == 2)
            {
                array = arrayTwo;
            }

            Array.Sort(array);

            Permutate(array, 0, array.Length - 1);
        }

        private static void Permutate(int[] array, int start, int end)
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (array[left] != array[right])
                    {
                        Swap(ref array[left], ref array[right]);
                        Permutate(array, left + 1, end);
                    }
                }

                var firstElement = array[left];

                for (int i = left; i <= end - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[end] = firstElement;
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}