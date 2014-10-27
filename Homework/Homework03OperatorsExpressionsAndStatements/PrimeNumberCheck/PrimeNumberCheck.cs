using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Please enter int n <= 100: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0 || n == 0 || n == 1)
        {
            Console.WriteLine(false);
        }
        else
        {
            Console.WriteLine(isPrime(n));
        }               
    }
    private static bool isPrime(int n)
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i ==0)
            {
                return false;
            }
        }
        return true;
    }
}