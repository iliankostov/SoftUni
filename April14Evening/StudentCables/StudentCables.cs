using System;

class StudentCables
{
    static void Main()
    {
        int numberCables = int.Parse(Console.ReadLine());
        int wholeCable = 0;
        int discardedCables = 0;
        int studentCable = 504;

        for (int i = 1; i <= numberCables; i++)
        {
            int lenght = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure == "centimeters" && lenght < 20)
            {
                lenght = 0;
                discardedCables++;
            }
            if (measure == "meters")
            {
                lenght *= 100;
            }
            wholeCable += lenght;
        }
        wholeCable -= (numberCables - discardedCables - 1) * 3;
        int number = (int)(wholeCable / studentCable);
        int reminder = wholeCable % studentCable;       
        Console.WriteLine("{0}\n{1}", number, reminder);

    }
}