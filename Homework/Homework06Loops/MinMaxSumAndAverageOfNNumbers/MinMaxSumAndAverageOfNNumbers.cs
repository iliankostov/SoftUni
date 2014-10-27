using System;
using System.Linq;

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        Console.Write("Plese enter length of the sequence: ");
        int lengthSequence = int.Parse(Console.ReadLine());
        int[] arrSequence = new int[lengthSequence];
        for (int i = 0; i < lengthSequence; i++)
        {
            Console.Write("Please enter number {0}: ", i + 1);
            arrSequence[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("min = {0}", arrSequence.Min());
        Console.WriteLine("max = {0}", arrSequence.Max());
        Console.WriteLine("sum = {0}", arrSequence.Sum());
        Console.WriteLine("avg = {0:0.00}", arrSequence.Average());
    }
}