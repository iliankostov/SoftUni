using System;

class WorkHours
{
    static void Main()
    {
        int projectHours = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        double productivity = double.Parse(Console.ReadLine()) / 100;

        double workHours = days * 0.9 * 12 * productivity;
        workHours = (int)workHours;
        double diff = workHours - projectHours;
        if (diff < 0)
        {
            Console.WriteLine("No\n{0}", diff);
        }
        else
        {
            Console.WriteLine("Yes\n{0}", diff);
        }
    }
}