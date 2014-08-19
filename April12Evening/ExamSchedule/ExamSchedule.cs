using System;

class ExamSchedule
{
    static void Main()
    {
        string beginHour = Console.ReadLine();
        string beginMinute = Console.ReadLine();
        string partOfDay = Console.ReadLine();
        int examHour = int.Parse(Console.ReadLine());
        int examMinute = int.Parse(Console.ReadLine());

        DateTime begin = DateTime.Parse(beginHour + ":" + beginMinute + " " + partOfDay);
        TimeSpan exam = TimeSpan.Parse(examHour + ":" + examMinute);
        DateTime end = begin + exam;

        Console.WriteLine("{0:hh:mm:tt}", end);    
    }
}