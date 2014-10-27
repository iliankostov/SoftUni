using System;

class CalculateFormula
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("x = ");
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        double factorial = 1;
        double underLine = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            underLine *= x;
            sum += (factorial / underLine);
        }       
        Console.WriteLine("sum = {0:0.00000}", sum);
    }
}