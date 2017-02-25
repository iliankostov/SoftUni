using System;

class JoroTheFootballPlayer
{
    static void Main()
    {
        string isYearLeap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        int normalWeekends = 52 - h;
        double plays = 0;
        if (isYearLeap == "t")
        {
            plays = 3 + h + normalWeekends * 2 / 3 + p * 0.5;
        }
        else if (isYearLeap == "f")
        {
            plays = h + normalWeekends * 2 / 3 + p * 0.5;
        }
        Console.WriteLine(Math.Round(plays));
    }
}