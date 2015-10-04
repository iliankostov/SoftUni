namespace Permutations
{
    using System;
    using System.Linq;

    internal class Permutations
    {
        private static int countOfPermutations;

        private static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, n).ToArray();

            Permutate(array);

            Console.WriteLine("Total permutations: {0}", countOfPermutations);
        }

        private static void Permutate(int[] array, int startIndex = 0)
        {
            if (startIndex >= array.Length - 1)
            {
                Console.WriteLine(string.Join(", ", array));
                countOfPermutations++;
            }
            else
            {
                Permutate(array, startIndex + 1);
                for (int i = startIndex + 1; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    Permutate(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
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