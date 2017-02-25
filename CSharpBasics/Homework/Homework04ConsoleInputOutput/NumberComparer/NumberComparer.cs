using System;

class NumberComparer
{
    static void Main()
    {
        Console.Write("Please enter number a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter number b = ");
        double b = double.Parse(Console.ReadLine());
        double max = Math.Max(a, b);
        Console.WriteLine("Greater = {0}", max);              
    }
}