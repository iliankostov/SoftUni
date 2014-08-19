using System;

class SumOfDigit
{
    static void Main()
    {
        int digit = int.Parse(Console.ReadLine());
        Console.WriteLine(SumOfDigits(digit));
    }

    private static int SumOfDigits(int num)
    {
        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num = num / 10;
        }
        return sum;
    }
}