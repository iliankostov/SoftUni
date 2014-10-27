using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        Console.Write("Please enter binary number: ");
        string binNumber = Console.ReadLine();
        long decNumber = 0;

        for (int i = 0; i < binNumber.Length; i++)
        {
            if (binNumber[i] == '1')
            {
                long power = binNumber.Length - 1 - i;
                decNumber = decNumber + (long)Math.Pow(2, power);
            }
        }
        Console.WriteLine(decNumber);        
    }
}