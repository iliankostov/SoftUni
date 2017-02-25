using System;
using System.Linq;

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Please enter your 4 digits number: ");
        int num = int.Parse(Console.ReadLine());
        int[] numArray = Array.ConvertAll(num.ToString().ToArray(), x => (int)x - 48); // I can't find simple way. Sorry!
        int sumOfDigits = numArray[0] + numArray[1] + numArray[2] + numArray[3];
        Console.WriteLine("Sum of digits: " + sumOfDigits);
        Console.WriteLine("Reversed: {3}{2}{1}{0} \nLast digit in front: {3}{0}{1}{2} \nSecond and third digits exchanged: {0}{2}{1}{3}", numArray[0], numArray[1], numArray[2], numArray[3]);      
    }
}