namespace BankOfKurtovoKonare
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Customers customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void WithdrawMoney(decimal money)
        {
            throw new ArgumentException("You cannot withdraw from mortgage account");
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Customer == Customers.Individual)
            {
                if (months >= 3)
                {
                    return base.CalcInterest(months - 3);
                }
                else
                {
                    return this.Balance;
                }
            }
            else
            {
                if (months >= 2)
                {
                    return base.CalcInterest(months - 2);
                }
                else
                {
                    return this.Balance;
                }
            }
        }
    }
}