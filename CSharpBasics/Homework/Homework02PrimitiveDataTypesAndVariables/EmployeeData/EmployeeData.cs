using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Ivan";
        string lastName = "Georgiev";
        byte age = 30;
        char gender = 'm';
        long personalIDNumber = 8306112507;       
        int uniqueEmployeeNumber = 27560000; 
        Console.WriteLine("First name: " + firstName);
        Console.WriteLine("Last name: " + lastName);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Gender: " + gender);
        Console.WriteLine("Personal ID number: " + personalIDNumber);
        Console.WriteLine("Unique employee number: " + uniqueEmployeeNumber);
        uniqueEmployeeNumber++;             
    }
}