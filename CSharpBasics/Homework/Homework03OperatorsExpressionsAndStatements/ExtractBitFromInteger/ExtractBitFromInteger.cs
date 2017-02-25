using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("n= ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("p= ");
        int position = int.Parse(Console.ReadLine());
        int mask = 1 << position;
        int result = number & mask;
        if (result == mask)
        {
            Console.WriteLine("1");
        }
        else
        {
            Console.WriteLine("0");
        }
    }
}