using System;

class HalfSum
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int sumOne = 0;
        int sumTwo = 0;
        for (int i = 1; i <= number; i++)
        {
            sumOne += int.Parse(Console.ReadLine());
        }
        for (int i = 1; i <= number; i++)
        {
            sumTwo += int.Parse(Console.ReadLine());
        }
        if (sumOne == sumTwo)
        {
            Console.WriteLine("Yes, sum={0}", sumOne);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sumOne - sumTwo));
        }
    }
}