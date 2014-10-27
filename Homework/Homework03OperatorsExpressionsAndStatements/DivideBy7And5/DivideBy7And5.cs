using System;

class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Please enter your number to check if divided by 7 and 5: ");
        int numberCheck = int.Parse(Console.ReadLine());
        string statementTrue = " is ";
        string statementFalse = " is not ";
        if (numberCheck != 0)
        {           
            bool checkDivide = (numberCheck % 7 == 0) && (numberCheck % 5 == 0) ? true : false;
            if (checkDivide == true)
            {
                Console.WriteLine("Your number" + statementTrue + "divided by 7 and 5");
            }
            else
            {
                Console.WriteLine("Your number" + statementFalse + "divided by 7 and 5");
            }
        }
        else
        {
            Console.WriteLine("Your number" + statementFalse + "divided by 7 and 5");
        }       
    }
}