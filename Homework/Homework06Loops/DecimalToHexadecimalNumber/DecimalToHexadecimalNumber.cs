using System;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        Console.Write("Please enter decimal number: ");
        long decNumber = long.Parse(Console.ReadLine());
        string hexNumber = "";

        do
        {
            switch (decNumber % 16)
            {
                case 10:
                    hexNumber = "A" + hexNumber;
                    break;
                case 11:
                    hexNumber = "B" + hexNumber;
                    break;
                case 12:
                    hexNumber = "C" + hexNumber;
                    break;
                case 13:
                    hexNumber = "D" + hexNumber;
                    break;
                case 14:
                    hexNumber = "E" + hexNumber;
                    break;
                case 15:
                    hexNumber = "F" + hexNumber;
                    break;
                default:
                    hexNumber = decNumber % 16 + hexNumber;
                    break;
            }
            decNumber = decNumber / 16;
        } while (decNumber > 0);

        Console.WriteLine(hexNumber);

    }
}