using System;

class AgeAfter10Years
{
    static void Main()
    {       
        Console.WriteLine("Please input your birthday in format dd.mm.yyyy");
        DateTime birthday = DateTime.Parse(Console.ReadLine());
        int myAgeNow = DateTime.Now.Year - birthday.Year - 1;
        Console.WriteLine("{0} {1} {2}", "I am ", myAgeNow, "years old.");
        Console.WriteLine("{0} {1}", "After 10 years I will be on ", myAgeNow + 10);
    }
}