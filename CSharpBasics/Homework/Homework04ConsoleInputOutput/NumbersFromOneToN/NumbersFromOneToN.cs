using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Start:
        Console.Write("Please enter integer number n >= 1: ");
        string tempString = Console.ReadLine();
        int n;
        if (int.TryParse(tempString, out n))
        {
            if (n >= 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("n must be >= 1");
                goto Start;
            }
        }
        else
        {
            Console.WriteLine("Invalid input: {0}", tempString);
            goto Start;
        }
    }
}