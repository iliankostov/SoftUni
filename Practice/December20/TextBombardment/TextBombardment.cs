using System;
class TextBombardment
{
    static void Main()
    {
        int tankPrice = int.Parse(Console.ReadLine());
        int numberParties = int.Parse(Console.ReadLine());

        int monthBalance = ((30 - numberParties) * 2) - (numberParties * 5);
        if (monthBalance > 0)
        {
            decimal monthsNeeded = Math.Ceiling((decimal)tankPrice / (decimal)monthBalance);
            int years = (int)(monthsNeeded / 12);
            int months = (int)(monthsNeeded % 12);
            Console.WriteLine("{0} years, {1} months", years, months);
        }
        else
        {
            Console.WriteLine("never");
        }
    }
}