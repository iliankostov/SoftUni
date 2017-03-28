namespace TestApplication
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAcount(0m);

            Console.WriteLine(account.Amount);
        }
    }
}
