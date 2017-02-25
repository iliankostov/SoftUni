namespace BankOfKurtovoKonare
{
    using System;

    public abstract class Account : IDeposit, IWithdraw
    {
        public Account(Customers customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customers Customer { get; private set; }

        public decimal Balance { get; set; }

        public decimal InterestRate { get; private set; }

        public void DepositMoney(decimal money)
        {
            this.Balance += money;
        }

        public abstract void WithdrawMoney(decimal money);

        public virtual decimal CalcInterest(int months)
        {
            decimal interest = this.Balance * (1 + (this.InterestRate * months));
            return interest;
        }
    }
}
