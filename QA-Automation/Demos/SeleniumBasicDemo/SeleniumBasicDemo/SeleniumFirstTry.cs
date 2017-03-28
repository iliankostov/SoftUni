
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumBasicDemo
{
    class SeleniumFirstTry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey");
            BankAcount acount = new BankAcount(1m);
            acount.Deposit(100m);
            acount.Withdraw(500m);
        }
    }
}
