﻿using System;

class PrimeChecker
{
    static void Main()
    {
        long inputNumber = long.Parse(Console.ReadLine());

        bool prime = IsPrime(inputNumber);

        Console.WriteLine(prime);
    }

    public static bool IsPrime(long candidate)
    {
        if ((candidate & 1) == 0)
        {
            if (candidate == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        for (long i = 3; (i * i) <= candidate; i += 2)
        {
            if ((candidate % i) == 0)
            {
                return false;
            }
        }
        return candidate != 1;
    }
}