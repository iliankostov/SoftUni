using System;

internal class FastRecursiveFibonacci
{
    private const int MAX_FIBОNACCI_SEQUENCE_MEMBER = 1000;

    private static decimal[] fib = new decimal[MAX_FIBОNACCI_SEQUENCE_MEMBER];

    private static decimal recursiveCallsCounter;

    private static decimal Fibonacci(int n)
    {
        recursiveCallsCounter++;
        if (fib[n] == 0)
        {
            // The value of fib[n] is still not calculated -> calculate it now
            if ((n == 1) || (n == 2))
            {
                fib[n] = 1;
            }
            else
            {
                fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        return fib[n];
    }

    private static void Main()
    {
        int num = 100;
        decimal fib = Fibonacci(num);
        Console.WriteLine("Fib({0}) = {1}", num, fib);
        Console.WriteLine("Recursive calls = {0}", recursiveCallsCounter);
    }
}