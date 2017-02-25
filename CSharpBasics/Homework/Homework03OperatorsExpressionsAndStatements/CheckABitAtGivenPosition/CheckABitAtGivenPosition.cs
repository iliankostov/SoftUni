using System;

class CheckABitAtGivenPosition
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
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}