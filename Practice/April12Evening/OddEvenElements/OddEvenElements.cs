using System;
using System.Linq;
using System.Collections.Generic;

class OddEvenElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] strArray = input.Split(' ');
        if (input == "")
        {
            strArray = new string[0];
        }
        double[] dArray = new double[strArray.Length];

        for (int i = 0; i < dArray.Length; i++)
        {
            dArray[i] = double.Parse(strArray[i]);
        }

        List<double> odd = new List<double>();
        List<double> even = new List<double>();
        for (int i = 0; i < dArray.Length; i++)
        {
            if (i % 2 == 0)
            {
                odd.Add(dArray[i]);
            }
        }
        for (int i = 0; i < dArray.Length; i++)
        {
            if (i % 2 != 0)
            {
                even.Add(dArray[i]);
            }            
        }
        if (odd.Any() && even.Any())
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                            odd.Sum(), odd.Min(), odd.Max(), even.Sum(), even.Min(), even.Max());
        }        
        else if (odd.Any() && !even.Any())
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                            odd.Sum(), odd.Min(), odd.Max(), "No", "No", "No");
        }
        else
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                            "No", "No", "No", "No", "No", "No");
        }        
    }
}