using System;

class HalfSum
{
    static void Main()
    {
        int numberOfNumbers = int.Parse(Console.ReadLine());
        int sumOne = 0;
        int sumTwo = 0;
        for (int i = 0; i < numberOfNumbers; i++)
        {
            int numbers = int.Parse(Console.ReadLine());           
            sumOne += numbers;
        }
        for (int i = 0; i < numberOfNumbers; i++)
        {
            int numbers = int.Parse(Console.ReadLine());
            sumTwo += numbers;
        }
        int diff = Math.Abs(sumOne - sumTwo);
        if (diff == 0)
        {
            Console.WriteLine("Yes, sum={0}", sumOne);
        }
        else
        {
            Console.WriteLine("No, diff={0}", diff);
        }
    }
}