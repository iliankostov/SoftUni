using System;

class FibonacciNumbers
{
    static void Main()
    {
        Start:
        Console.Write("Enter your number n = ");
        int n = int.Parse(Console.ReadLine());
        if (n > 1)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            Console.Write("{0}, {1}, ", firstNumber, secondNumber);
            for (int i = 2; i < n; i++)
            {
                int sum = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = sum;
                Console.Write("{0}, ", sum);
            }
        }
        else if (n == 1)
        {
            Console.Write("{0}, ", 0);
        }
        else
        {
            Console.WriteLine("Wrong input n must be > 0");
            goto Start;
        }            
    }
}