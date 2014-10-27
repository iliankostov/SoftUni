using System;

class JoroTheFootballPlayer
{
    static void Main()
    {
        string isYearLeap = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometowm = int.Parse(Console.ReadLine());
        double plays = 0;

        plays = hometowm + (52 - hometowm) * 2.0 / 3 + holidays * 1.0 / 2;
        if (isYearLeap == "t")
        {
            plays += 3;
        }

        Console.WriteLine((int)plays);
    }
}