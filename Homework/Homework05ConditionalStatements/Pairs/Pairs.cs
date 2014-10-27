using System;
using System.Linq;

class Pairs
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] numbers = SplitStringsToInts(input);
        int[] sums = new int[numbers.Length / 2];
        double subSum = 0;

        for (int i = 0, j = 0; i < sums.Length; i++, j+=2)
        {
            sums[i] = numbers[j] + numbers[j + 1];           
            subSum += sums[i];
        }
        double pairValue = subSum / sums.Length*1.0;
        int maxDiff = sums.Max() - sums.Min();

        if (pairValue == sums[0])
        {
            Console.WriteLine("Yes, value={0}", (int)pairValue);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
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