namespace BankOfKurtovoKonare
{
    using System;
    using System.Collections.Generic;

    internal class BankOfKurtovoKonareMain
    {
        internal static void Main()
        {
            LoanAccount georgiIvanov = new LoanAccount(Customers.Individual, 9000M, 0.01M);
            LoanAccount bulSoft = new LoanAccount(Customers.Company, 50000M, 0.01M);
            Console.Write("Individual Deposit: " + georgiIvanov.Balance + " -> ");
            georgiIvanov.DepositMoney(1000M);
            Console.WriteLine("{0:0.00} has interest: {1:0.00}", georgiIvanov.Balance, georgiIvanov.CalcInterest(24));
            Console.Write("Company Deposit: " + bulSoft.Balance + " -> ");
            bulSoft.DepositMoney(10000M);
            Console.WriteLine("{0:0.00} has interest: {1:0.00}", bulSoft.Balance, bulSoft.CalcInterest(24));

            DepositAccount ivanIvanov = new DepositAccount(Customers.Individual, 2500M, 0.01M);
            DepositAccount ivanGeorgiev = new DepositAccount(Customers.Individual, 1500M, 0.01M);
            Console.Write("Individual Deposit: " + ivanIvanov.Balance + " -> ");
            ivanIvanov.DepositMoney(1000M);
            Console.WriteLine("{0:0.00} has interest: {1:0.00}", ivanIvanov.Balance, ivanIvanov.CalcInterest(12));
            Console.Write("Individual Withdraw: " + ivanGeorgiev.Balance + " -> ");
            ivanGeorgiev.WithdrawMoney(250M);
            Console.WriteLine("{0:0.00} has interest: {1:0.00}", ivanGeorgiev.Balance, ivanGeorgiev.CalcInterest(12));

            MortgageAccount maria = new MortgageAccount(Customers.Individual, 12500M, 0.01M);
            MortgageAccount georgievi = new MortgageAccount(Customers.Company, 31500M, 0.01M);
            Console.Write("Individual Deposit: " + maria.Balance + " -> ");
            maria.DepositMoney(1000M);
            Console.WriteLine("{0:0.00} has interest: {1:0.00}", maria.Balance, maria.CalcInterest(12));
            Console.Write("Company Deposit: " + georgievi.Balance + " -> ");
            georgievi.DepositMoney(250M);
            Console.WriteLine("{0:0.00} has interest: {1:0.00}", georgievi.Balance, georgievi.CalcInterest(12));
        }
    }
}
