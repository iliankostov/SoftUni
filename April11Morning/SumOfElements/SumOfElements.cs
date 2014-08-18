using System;
using System.Linq;

class SumOfElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] numbers = SplitStringsToInts(input);
        long sum = 0;       

        for (int i = 0; i < numbers.Length; i++)
        {            
            sum += numbers[i];
        }

        int maxValue = numbers.Max();
        long diff = Math.Abs(maxValue - (sum - maxValue));

        if (diff == 0)
        {
            Console.WriteLine("Yes, sum={0}", maxValue);
        }
        else
        {
            Console.WriteLine("No, diff={0}",diff);
        }
    }

    private static int[] SplitStringsToInts(string s)
    {
        string[] strArray = s.Split(' ');
        int[] intArray = new int[strArray.Length];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = int.Parse(strArray[i]);
        }
        return intArray;
    }
}