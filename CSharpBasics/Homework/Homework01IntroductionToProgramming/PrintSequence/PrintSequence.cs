using System;

class PrintSequence
{
    static void Main()
    {
        int[] array1 = { 2, -3, 4, -5, 6, -7, 8, -9, 10, -11 };

        foreach (int n in array1)
        {
            Console.WriteLine(n);
        }
    }
}