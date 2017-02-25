using System;

class BonusScore
{
    static void Main()
    {
        Console.Write("Please enter number in range [1...9]: ");
        int num = int.Parse(Console.ReadLine());
        if (num >= 1 && num <= 3)
        {
            num *= 10;
            Console.WriteLine(num);
        }
        else if (num >= 4 && num <=6)
        {
            num *= 100;
            Console.WriteLine(num);
        }
        else if (num >= 7 && num <= 9)
        {
            num *= 1000;
            Console.WriteLine(num);
        }
        else if (num <= 0 || num > 9)
        {
            Console.WriteLine("invalid score");
        }
    }
}