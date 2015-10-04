namespace GenerateCombinationsIteratively
{
    using System;

    internal class GenerateCombinationsIteratively
    {
        private static int combinationsCount;

        private static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            Console.Write("k = ");
            var k = int.Parse(Console.ReadLine());

            int[] array = new int[k];

            for (int i = 0; i < k; ++i)
            {
                array[i] = i + 1;
            }

            bool done = false;

            while (!done)
            {
                Console.WriteLine(string.Join(", ", array));
                combinationsCount++;

                int index = k - 1;

                int position = n;

                while (index >= 0 && array[index] == position)
                {
                    position--;
                    index--;
                }

                if (index < 0)
                {
                    done = true;
                }
                else
                {
                    array[index]++;

                    for (int i = index + 1; i < k; ++i)
                    {
                        array[i] = array[i - 1] + 1;
                    }
                }
            }

            Console.WriteLine("Total combinations: {0}", combinationsCount);
        }
    }
}