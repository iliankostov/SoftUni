using System;

class Volleyball
{
    static void Main()
    {
        string isYearLeap = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());
        double plays = hometown + (48 - hometown) * 3.0 / 4 + holidays * 2.0 / 3;
        if (isYearLeap == "leap")
        {
            plays = plays + plays * 0.15;
        }
        Console.WriteLine((int)plays);
    }
}