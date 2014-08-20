using System;

class BiggestTriple
{
    static void Main()
    {
        string input = Console.ReadLine();       
        string[] numbers = input.Split(' ');
        int maxSum = Int32.MinValue;
        int index = 0;

        for (int i = 0; i < numbers.Length; i+=3)
        {
            int numberOne = int.Parse(numbers[i]);
            int numberTwo = 0;
            int numberThree = 0;
            if (i + 1 < numbers.Length)
            {
                numberTwo = int.Parse(numbers[i + 1]);
            }
            if (i + 2 < numbers.Length)
	        {
                numberThree = int.Parse(numbers[i + 2]);
	        }
            int sum = numberOne + numberTwo + numberThree;
            if (sum > maxSum)
            {
                maxSum = sum;
                index = i;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (maxSum != 0)
            {
                Console.Write(numbers[index]);
                maxSum = maxSum - int.Parse(numbers[index]);
                index++;
                if (maxSum != 0)
                {
                    Console.Write(" ");
                }               
            }         
        }
    }
}