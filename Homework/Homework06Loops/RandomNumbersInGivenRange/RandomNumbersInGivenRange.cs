using System;

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("min = ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("max = ");
        int max = int.Parse(Console.ReadLine());
        Random rnd = new Random();
        Console.Write("Random numbers: ");
        for (int i = 0; i < n; i++)
        {           
            int result = rnd.Next(min, max + 1);
            Console.Write(result + " ");
        }
        Console.WriteLine();        
    }
}