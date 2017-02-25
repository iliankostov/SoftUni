namespace AlgorithmsAndComplexityEx
{
    using System;
    using System.Collections.Generic;

    public class AlgorithmsAndComplexityEx
    {
        public static bool IsPrime(long num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrimeFast(long num)
        {
            int maxDivisor = (int)Math.Sqrt(num);
            for (int i = 2; i <= maxDivisor; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static IList<int> FindFirstNPrimes(int n)
        {
            var primes = new List<int>(n);
            int p = 2;
            while (primes.Count < n)
            {
                if (IsPrimeFast(p))
                {
                    primes.Add(p);
                }

                p++;
            }

            return primes;
        }

        public static IList<int> FindPrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int p = start; p <= end; p++)
            {
                if (IsPrimeFast(p))
                {
                    primes.Add(p);
                }
            }

            return primes;
        }



        public static void Main()
        {
            int p = 10000;

            Console.WriteLine("IsPrime() results:");
            var startTime = DateTime.Now;
            for (int i = 0; i < p; i++)
            {
                IsPrime(i);
            }

            var executionTime = DateTime.Now - startTime;
            Console.WriteLine("Execution time: {0}", executionTime);

            Console.WriteLine("IsPrimeFast() results:");
            var startTimeFast = DateTime.Now;
            for (int i = 0; i < p; i++)
            {
                IsPrimeFast(i);
            }

            var executionTimeFast =
                DateTime.Now - startTimeFast;
            Console.WriteLine("Execution time: {0}", executionTimeFast);
        }
    }
}
