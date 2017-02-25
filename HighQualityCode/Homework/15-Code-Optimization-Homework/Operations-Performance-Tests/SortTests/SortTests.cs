namespace SortTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    internal class SortTests
    {
        private static void Main()
        {
            Console.WriteLine("Generating collections ... Please wait!");
            int i;
            string letter;
            var sortedInts = new List<int>();
            for (i = 0; i <= 9999999; i++)
            {
                sortedInts.Add(i);
            }

            var reversedInts = new List<int>();
            for (i = 9999999; i >= 0; i--)
            {
                reversedInts.Add(i);
            }

            var randomInts = new List<int>();
            Random randInts = new Random();
            for (i = 0; i <= 9999999; i++)
            {
                randomInts.Add(randInts.Next(1, 10000000));
            }

            var sortedDoubles = new List<double>();
            for (i = 0; i <= 9999999; i++)
            {
                sortedDoubles.Add(i);
            }

            var reversedDoubles = new List<double>();
            for (i = 9999999; i >= 0; i--)
            {
                reversedDoubles.Add(i);
            }

            var randomDoubles = new List<double>();
            Random randDoubles = new Random();
            for (i = 0; i <= 9999999; i++)
            {
                randomDoubles.Add(randDoubles.Next(1, 10000000));
            }

            var sortedStrings = new List<string>();
            for (i = 0; i <= 9999999; i += 26)
            {
                for (int j = 97; j < 123; j++)
                {
                    letter = (char)j + "";
                    sortedStrings.Add(letter);
                }
            }

            var reversedStrings = new List<string>();
            for (i = 0; i <= 9999999; i += 26)
            {
                for (int j = 122; j >= 97; j--)
                {
                    letter = (char)j + "";
                    reversedStrings.Add(letter);
                }
            }

            var randomStrings = new List<string>();
            Random randStrings = new Random();
            for (i = 0; i <= 9999999; i++)
            {
                letter = (char)randStrings.Next(97, 123) + "";
                randomStrings.Add(letter);
            }

            Console.WriteLine("\nTest sort for ints:");

            Stopwatch sortedIntStopwatchIs = new Stopwatch();
            sortedIntStopwatchIs.Start();
            sortedInts.Sort();
            sortedIntStopwatchIs.Stop();
            Console.WriteLine("Sort sorted ints:          {0}", sortedIntStopwatchIs.Elapsed);

            Stopwatch reversedIntStopwatchIs = new Stopwatch();
            reversedIntStopwatchIs.Start();
            reversedInts.Sort();
            reversedIntStopwatchIs.Stop();
            Console.WriteLine("Sort reversed ints:        {0}", reversedIntStopwatchIs.Elapsed);

            Stopwatch randomIntStopwatchIs = new Stopwatch();
            randomIntStopwatchIs.Start();
            randomInts.Sort();
            randomIntStopwatchIs.Stop();
            Console.WriteLine("Sort random ints:          {0}", randomIntStopwatchIs.Elapsed);

            Console.WriteLine("\nTest sort for doubles:");

            Stopwatch sortedDoubleStopwatchIs = new Stopwatch();
            sortedDoubleStopwatchIs.Start();
            sortedDoubles.Sort();
            sortedDoubleStopwatchIs.Stop();
            Console.WriteLine("Sort sorted doubles:       {0}", sortedDoubleStopwatchIs.Elapsed);

            Stopwatch reversedDoubleStopwatchIs = new Stopwatch();
            reversedDoubleStopwatchIs.Start();
            reversedDoubles.Sort();
            reversedDoubleStopwatchIs.Stop();
            Console.WriteLine("Sort reversed doubles:     {0}", reversedDoubleStopwatchIs.Elapsed);

            Stopwatch randomDoubleStopwatchIs = new Stopwatch();
            randomDoubleStopwatchIs.Start();
            randomDoubles.Sort();
            randomDoubleStopwatchIs.Stop();
            Console.WriteLine("Sort random doubles:       {0}", randomDoubleStopwatchIs.Elapsed);

            Console.WriteLine("\nTest sort for strings ... Please wait!");

            Stopwatch sortedStringStopwatchIs = new Stopwatch();
            sortedStringStopwatchIs.Start();
            sortedStrings.Sort();
            sortedStringStopwatchIs.Stop();
            Console.WriteLine("Sort sorted strings:       {0}", sortedStringStopwatchIs.Elapsed);

            Stopwatch reversedStringStopwatchIs = new Stopwatch();
            reversedStringStopwatchIs.Start();
            reversedStrings.Sort();
            reversedStringStopwatchIs.Stop();
            Console.WriteLine("Sort reversed strings:     {0}", reversedStringStopwatchIs.Elapsed);

            Stopwatch randomStringStopwatchIs = new Stopwatch();
            randomStringStopwatchIs.Start();
            randomStrings.Sort();
            randomStringStopwatchIs.Stop();
            Console.WriteLine("Sort random strings:       {0}", randomStringStopwatchIs.Elapsed);

            // TODO: test another sort algoritms
        }
    }
}