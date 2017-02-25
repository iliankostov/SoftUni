using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.Write("Enter your number n = ");
        int n = int.Parse(Console.ReadLine());
        double sum = 0;       
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter your number = ");
            double number = double.Parse(Console.ReadLine());
            sum += number;                       
        }
        Console.WriteLine("Sum = {0}", sum);       
    }
}