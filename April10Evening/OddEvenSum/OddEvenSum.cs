using System;

class OddEvenSum
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] arrNumbers = new int[number*2];
        int oddSum = 0;
        int evenSum = 0;
        for (int i = 0; i < arrNumbers.Length; i++)
        {
            arrNumbers[i] = int.Parse(Console.ReadLine());
            if (i % 2 != 0)
            {
                oddSum += arrNumbers[i];
            }
            else
            {
                evenSum += arrNumbers[i];
            }
        }
        if (oddSum == evenSum)
        {
            Console.WriteLine("Yes, sum={0}", oddSum);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(oddSum - evenSum));
        }
    }
}