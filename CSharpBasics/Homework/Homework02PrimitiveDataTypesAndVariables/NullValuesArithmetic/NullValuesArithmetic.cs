using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? a =  null;
        double? b = null;
        a += 5;
        b += null;
        Console.WriteLine("null + 5 = " + a);
        Console.WriteLine("null + null = " + b);
    }
}