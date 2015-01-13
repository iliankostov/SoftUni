using System;
class TravellerBob
{
    static void Main()
    {
        string leapYear = Console.ReadLine();
        int contractMonth = int.Parse(Console.ReadLine());
        int familyMonth = int.Parse(Console.ReadLine());

        int contractMonthsTravels = contractMonth * 12;
        int familyMonthsTravels = familyMonth * 4;
        double normalMonthsTravels = ((12 - contractMonth - familyMonth) * 12 * 1.0) * 3 / 5;

        double totalTravels = (contractMonthsTravels) + (familyMonthsTravels) + (normalMonthsTravels);

        if (leapYear == "leap")
        {
            totalTravels += totalTravels * 0.05;
            Console.WriteLine((int)totalTravels);
        }
        else
        {
            Console.WriteLine((int)totalTravels);

        }
    }
}