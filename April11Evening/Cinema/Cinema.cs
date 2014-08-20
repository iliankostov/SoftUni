using System;

class Cinema
{
    static void Main()
    {
        string typeProjection = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        int persons = rows * columns;
        decimal income = 0m;

        if (typeProjection == "Premiere")
        {
            income = 12.00m * persons;
        }
        else if (typeProjection == "Normal")
        {
            income = 7.50m * persons;
        }
        else
        {
            income = 5.00m * persons;
        }
        Console.WriteLine("{0} leva", income);
    }
}