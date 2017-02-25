using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        Console.Write("Please enter hexadecimal number: ");
        string hexNumber = Console.ReadLine();
        long decNumber = 0;

        for (int i = 0; i < hexNumber.Length; i++)
        {
            switch (hexNumber[i])
            {
                case 'A':
                    decNumber += 10 * (long)Math.Pow(16, hexNumber.Length - i - 1); 
                    break;
                case 'B':
                    decNumber += 11 * (long)Math.Pow(16, hexNumber.Length - i - 1);
                    break;
                case 'C':
                    decNumber += 12 * (long)Math.Pow(16, hexNumber.Length - i - 1);
                    break;
                case 'D':
                    decNumber += 13 * (long)Math.Pow(16, hexNumber.Length - i - 1);
                    break;
                case 'E':
                    decNumber += 14 * (long)Math.Pow(16, hexNumber.Length - i - 1);
                    break;
                case 'F':
                    decNumber += 15 * (long)Math.Pow(16, hexNumber.Length - i - 1);
                    break;
                default:
                    decNumber += (long)char.GetNumericValue(hexNumber[i]) * (long)Math.Pow(16, hexNumber.Length - i - 1);
                    break;
            }
        }
        Console.WriteLine(decNumber);

    }
}