using System;
using System.Collections.Generic;
using System.Linq;

class RandomizeTheNumbersOneToN
{
    static void Main()
    {
        Console.Write("Please enter integer n: ");
        int n = int.Parse(Console.ReadLine());
        int[] intArray = new int[n];
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i + 1;
        }
        var list = new List<int>(intArray);
        var shuffled = list.OrderBy(a => Guid.NewGuid());
        foreach (var item in shuffled)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }   
}