using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.Write("Please enter 5 numbers separated by space: ");
        string[] numbers = Console.ReadLine().Split();
        double a = double.Parse(numbers[0]);
        double b = double.Parse(numbers[1]);
        double c = double.Parse(numbers[2]);
        double d = double.Parse(numbers[3]);
        double e = double.Parse(numbers[4]);
        double sum = a + b + c + d + e;
        Console.WriteLine("Sum = {0}", sum);         
    }
}