using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Please enter number to check if it is odd: ");
        int numberCheck = int.Parse(Console.ReadLine());
        bool checkOdd = numberCheck % 2 == 1;
        string statementTrue = " is ";
        string statementFalse = " is not ";
        if (checkOdd == true)
	    {
		    Console.WriteLine("Your number" + statementTrue + "odd.");
	    }
        else
        {
            Console.WriteLine("Your number" + statementFalse + "odd.");
        }      
    }
}