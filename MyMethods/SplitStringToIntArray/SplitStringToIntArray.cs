using System;

class SplitStringToIntArray
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] intArray = SplitStringsToInts(input);
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.WriteLine(intArray[i]);
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