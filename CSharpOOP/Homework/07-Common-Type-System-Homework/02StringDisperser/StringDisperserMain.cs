namespace StringDisperser
{
    using System;

    internal class StringDisperserMain
    {
        internal static void Main()
        {
            var stringDispersers = new StringDisperser[]
            {
                new StringDisperser("tommy", "lee", "jones"),
                new StringDisperser("sarah", "jessica", "parker")
            };

            Array.Sort(stringDispersers);

            foreach (var stringDisperser in stringDispersers)
            {
                Console.WriteLine(stringDisperser);
            }

            Console.WriteLine();

            Console.WriteLine(stringDispersers[0].Equals(stringDispersers[1]));
            Console.WriteLine();

            foreach (var stringDisperser in stringDispersers)
            {
                foreach (var ch in stringDisperser)
                {
                    Console.Write(ch + " ");
                }

                Console.WriteLine();
            }
        }
    }
}