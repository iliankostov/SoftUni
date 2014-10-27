using System;

class FormattingNumbers
{
    static void Main()
    {
        Start:
        Console.Write("Please enter int number a in range [0 <= a <= 500]: ");
        string tempString = Console.ReadLine();
        int a;
        if (int.TryParse(tempString, out a))
        {
            if (a < 0 || a > 500)
            {
                Console.WriteLine("Out of range");
                goto Start;
            }
        }
        else
        {
            Console.WriteLine("Invalid int number: {0}", tempString);
            goto Start;
        }    
  
        Console.Write("Please enter float number b = ");
        float b = float.Parse(Console.ReadLine());
        Console.Write("Please enter float number c = ");
        float c = float.Parse(Console.ReadLine());

        string hexA = a.ToString("X");
        string binA = Convert.ToString(a, 2).PadLeft(10, '0');
        Console.WriteLine("|{0, -10}|{1, -10}|{2, 10 :0.00}|{3, -10:0.000}|", hexA, binA, b, c);

    }
}