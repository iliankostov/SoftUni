namespace BankOfKurtovoKonare
{
    using System;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customers customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void WithdrawMoney(decimal money)
        {
            throw new ArgumentException("You cannot withdraw from mortgage account");
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Customer == Customers.Company)
            {
                if (months <= 12)
                {
                    return base.CalcInterest(months) / 2;
                }
                else
                {
                    return (base.CalcInterest(12) / 2) + base.CalcInterest(months - 12);
                }
            }

            if (this.Customer == Customers.Individual)
            {
                if (months >= 6)
                {
                    return base.CalcInterest(months - 6);                  
                }
                else
                {
                    return this.Balance;
                }
            }

            return base.CalcInterest(months);
        }
    }
}