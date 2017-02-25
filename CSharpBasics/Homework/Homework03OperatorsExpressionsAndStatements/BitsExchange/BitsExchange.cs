using System;

class BitsExchange
{
    static void Main()
    {
        Console.Write("n = ");
        uint number = uint.Parse(Console.ReadLine());
        uint maskFirstEight = 7 << 3;
        uint maskLastEight = 7 << 24;
        
        maskFirstEight &= number;
        number &= ~maskFirstEight;   
        maskFirstEight <<= 21;

        maskLastEight &= number;
        number &= ~maskLastEight;
        maskLastEight >>= 21;

        number += maskFirstEight;
        number += maskLastEight;

        Console.WriteLine("result = {0}", number);       
    }
}