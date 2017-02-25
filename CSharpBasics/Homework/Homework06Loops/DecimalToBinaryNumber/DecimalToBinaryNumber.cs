using System;

class DecimalToBinaryNumber
{
    static void Main()
    {
        Console.Write("Please enter decimal number: ");
        long decNumber = long.Parse(Console.ReadLine());
        string binNumber = "";

        do
        {
            binNumber = decNumber % 2 + binNumber;
            decNumber = decNumber / 2;

        } while (decNumber > 0);

        Console.WriteLine(binNumber);

    }
}