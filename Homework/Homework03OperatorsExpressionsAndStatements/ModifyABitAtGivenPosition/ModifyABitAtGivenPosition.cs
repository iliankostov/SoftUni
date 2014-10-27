using System;

class ModifyABitAtGivenPosition
{
    static void Main()
    {
        Console.Write("n= ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("p= ");
        int position = int.Parse(Console.ReadLine());
        Console.Write("v= ");
        int value = int.Parse(Console.ReadLine());
        int mask = 1 << position;       
        if (value == 1)
        {
            number = number | mask;
            Console.WriteLine(number);
        }
        else if (value == 0)
        {
            number = number & ~mask;
            Console.WriteLine(number);
        }
        else
        {
            Console.WriteLine("Incorect value");
        }
    }
}