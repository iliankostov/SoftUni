using System;

class VariableInHexadecimalFormat
{
    static void Main()
    {
        int decValue = 254;
        string hexValue = decValue.ToString("X");
        int decAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        Console.WriteLine("0x{0} = {1}", hexValue, decAgain);       
    }
}