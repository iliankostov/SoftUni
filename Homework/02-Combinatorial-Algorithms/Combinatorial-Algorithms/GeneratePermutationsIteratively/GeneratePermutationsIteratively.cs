namespace GeneratePermutationsIteratively
{
    using System;

    internal class GeneratePermutationsIteratively
    {
        private static int permutationsCount;

        private static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < n; ++i)
            {
                array[i] = i + 1;
            }

            while (true)
            {
                Console.WriteLine(string.Join(", ", array));
                permutationsCount++;

                var a = array.Length - 1;
                var b = array.Length - 2;

                while (b >= 0 && array[b] >= array[b + 1])
                {
                    b--;
                }

                if (b < 0)
                {
                    break;
                }

                while (array[b] >= array[a])
                {
                    a--;
                }

                Swap(ref array[a], ref array[b]);

                var c = b + 1;

                a = array.Length - 1;

                while (c < a)
                {
                    Swap(ref array[c], ref array[a]);
                    c++;
                    a--;
                }
            }

            Console.WriteLine("Total permutations {0}", permutationsCount);
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