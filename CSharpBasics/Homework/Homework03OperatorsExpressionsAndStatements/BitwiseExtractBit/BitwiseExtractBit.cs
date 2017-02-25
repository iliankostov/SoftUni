using System;

class BitwiseExtractBit
{
    static void Main()
    {
        Console.Write("n= ");
        int number = int.Parse(Console.ReadLine());                
        int mask = 1 << 3;       
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