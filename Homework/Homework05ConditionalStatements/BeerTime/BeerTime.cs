using System;

class BeerTime
{
    static void Main()
    {
        Console.Write("Please enter date in format mm:hh tt : ");
        string tryToParseDateTime = Console.ReadLine();
        DateTime timeAfter = DateTime.Parse("1:00 PM");
        DateTime timeBefore = DateTime.Parse("3:00 AM");
        DateTime timeToCheck;

        if (DateTime.TryParse(tryToParseDateTime, out timeToCheck))
        {
            if (timeToCheck >= timeAfter || timeToCheck < timeBefore)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
    }
}