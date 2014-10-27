using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        int c;
        Console.WriteLine("a = " + a + "\nb = " + b);
        c = b;
        b = a;
        a = c;
        Console.WriteLine("a = " + a + "\nb = " + b);
    }
}