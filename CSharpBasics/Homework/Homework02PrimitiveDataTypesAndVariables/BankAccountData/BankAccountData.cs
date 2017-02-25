using System;

class BankAccountData
{
    static void Main()
    {
        string firstName = "Ivan";
        string middleName = "Georgiev";
        string lastName = "Ivanov";       
        decimal balance = 11000M;
        string bankName = "IGI Bank";
        string accountIBAN = "BE45898287271283";
        string creditCard1 = "4589828727128301";
        string creditCard2 = "4589828727128302";
        string creditCard3 = "4589828727128303";
        Console.WriteLine("Holder name: {0} {1} {2}", firstName, middleName, lastName);
        Console.WriteLine("Balance: {0} lv.", balance);
        Console.WriteLine("Bank name: " + bankName);
        Console.WriteLine("IBAN: " + accountIBAN);
        Console.WriteLine("Credit card 1: " + creditCard1);
        Console.WriteLine("Credit cart 2: " + creditCard2);
        Console.WriteLine("Credit cart 3: " + creditCard3);
    }
}