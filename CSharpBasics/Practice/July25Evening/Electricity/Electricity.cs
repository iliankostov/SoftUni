using System;

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        DateTime timeToCheck = DateTime.Parse(Console.ReadLine());

        int allFlats = floors * flats;
        int lamps = 0;
        int computers = 0;

        if (timeToCheck >= DateTime.Parse("14:00") && timeToCheck <= DateTime.Parse("18:59"))
        {
            lamps = 2;
            computers = 2;
        }
        else if (timeToCheck >= DateTime.Parse("19:00") && timeToCheck <= DateTime.Parse("23:59"))
        {
            lamps = 7;
            computers = 6;
        }
        else if (timeToCheck >= DateTime.Parse("00:00") && timeToCheck <= DateTime.Parse("08:59"))
        {
            lamps = 1;
            computers = 8;
        }
        else
        {
            lamps = 0;
            computers = 0;
        }

        lamps *= allFlats;
        computers *= allFlats;

        double lampConsumation = lamps * 100.53;
        double compConsumation = computers * 125.90;

        double result = Math.Floor(lampConsumation + compConsumation);

        Console.WriteLine("{0:0} Watts", result);

    }
}