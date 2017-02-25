using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.Write("Please enter number a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter number b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please enter number c = ");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("The sum of {0} and {1} and {2} is {3}", a, b, c, (a + b + c) );
    }
}