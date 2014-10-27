using System;

class Volleyball
{
    static void Main()
    {
        string typeYear = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        double plays = h + ((48-h) * 3 / 4.0) + (p * 2 / 3.0); // when I have to calculate double - one of the elements must be double !!!
        if (typeYear == "leap")
        {
            plays *= 1.15;  
        }
        Console.WriteLine((int)plays);

    }
}