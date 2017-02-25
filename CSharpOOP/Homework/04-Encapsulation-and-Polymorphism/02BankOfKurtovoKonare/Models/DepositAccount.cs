namespace BankOfKurtovoKonare
{
    using System;

    public class DepositAccount : Account
    {
        public DepositAccount(Customers customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void WithdrawMoney(decimal money)
        {
            this.Balance -= money;
        }

        public override decimal CalcInterest(int months)
        {
            if (this.Balance >= 0 && this.Balance < 1000M)
            {
                return this.Balance;
            }

            return base.CalcInterest(months);
        }
    }
}