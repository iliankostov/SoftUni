namespace SquareRootNaturalLogarithmSinus
{
    using System;
    using System.Diagnostics;

    class SquareRootNaturalLogarithmSinus
    {
        static void Main()
        {
            int i;
            float floatNumber = 2.0f;
            double doubleNumber = 2.0d;
            decimal decimalNumber = 2.0m;
            double doubleResult = 0.0d;
            decimal decimalResult = 0.0m;

            Console.WriteLine("Operations with float:");

            Stopwatch floatStopwatchSqrt = new Stopwatch();
            floatStopwatchSqrt.Start();
            for (i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sqrt(floatNumber);
            }
            floatStopwatchSqrt.Stop();
            Console.WriteLine("Sqrt float:      {0}", floatStopwatchSqrt.Elapsed);

            Stopwatch floatStopwatchIncrement = new Stopwatch();
            floatStopwatchIncrement.Start();
            for (i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Log(floatNumber);
            }
            floatStopwatchIncrement.Stop();
            Console.WriteLine("Logarithm float: {0}", floatStopwatchIncrement.Elapsed);

            Stopwatch floatStopwatchSubstract = new Stopwatch();
            floatStopwatchSubstract.Start();
            for (i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sin(floatNumber);
            }
            floatStopwatchSubstract.Stop();
            Console.WriteLine("Sinus float:     {0}", floatStopwatchSubstract.Elapsed);

            Console.WriteLine("\nOperations with double:");

            Stopwatch doubleStopwatchSqrt = new Stopwatch();
            doubleStopwatchSqrt.Start();
            for (i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sqrt(doubleNumber);
            }
            doubleStopwatchSqrt.Stop();
            Console.WriteLine("Sqrt double:      {0}", doubleStopwatchSqrt.Elapsed);

            Stopwatch doubleStopwatchIncrement = new Stopwatch();
            doubleStopwatchIncrement.Start();
            for (i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Log(doubleNumber);
            }
            doubleStopwatchIncrement.Stop();
            Console.WriteLine("Logarithm double: {0}", doubleStopwatchIncrement.Elapsed);

            Stopwatch doubleStopwatchSubstract = new Stopwatch();
            doubleStopwatchSubstract.Start();
            for (i = 0; i < 10000000; i++)
            {
                doubleResult = Math.Sin(doubleNumber);
            }
            doubleStopwatchSubstract.Stop();
            Console.WriteLine("Sinus double:     {0}", doubleStopwatchSubstract.Elapsed);

            Console.WriteLine("\nOperations with decimal:");

            Stopwatch decimalStopwatchSqrt = new Stopwatch();
            decimalStopwatchSqrt.Start();
            for (i = 0; i < 10000000; i++)
            {
                decimalResult = (decimal)Math.Sqrt((double)decimalNumber);
            }
            decimalStopwatchSqrt.Stop();
            Console.WriteLine("Sqrt decimal:      {0}", decimalStopwatchSqrt.Elapsed);

            Stopwatch decimalStopwatchIncrement = new Stopwatch();
            decimalStopwatchIncrement.Start();
            for (i = 0; i < 10000000; i++)
            {
                decimalResult = (decimal)Math.Log((double)decimalNumber);
            }
            decimalStopwatchIncrement.Stop();
            Console.WriteLine("Logarithm decimal: {0}", decimalStopwatchIncrement.Elapsed);

            Stopwatch decimalStopwatchSubstract = new Stopwatch();
            decimalStopwatchSubstract.Start();
            for (i = 0; i < 10000000; i++)
            {
                decimalResult = (decimal)Math.Sin((double)decimalNumber);
            }
            decimalStopwatchSubstract.Stop();
            Console.WriteLine("Sinus decimal:     {0}", decimalStopwatchSubstract.Elapsed);
        }
    }
}