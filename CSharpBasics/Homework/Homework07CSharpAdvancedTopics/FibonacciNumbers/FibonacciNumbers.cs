using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long result = Fib(n);

        Console.WriteLine(result);
    }

    private static long Fib(int n)
    {
        long firstNum = 0;
        long secondNum = 1;
        long nextNum;

        if (n == 0) return firstNum + 1;
        if (n == 1) return firstNum + 1;
        if (n == 2) return secondNum + 1;
        else
        {

            for (int i = 1; i <= n; i++)
            {
                nextNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = nextNum;

                if (i == n)
                {
                    return nextNum;
                }
            }
        }

        return 0;
    }
}