using System;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        Console.Write("start = ");
        int startNumber = int.Parse(Console.ReadLine());
        Console.Write("end = ");
        int endNumber = int.Parse(Console.ReadLine());
        int p = 0;
        for (int i = startNumber; i <= endNumber; i++)
        {
            if (i % 5 == 0)
            {
                p += 1;
            }
        }
        Console.WriteLine("p = {0}", p);
    }
}