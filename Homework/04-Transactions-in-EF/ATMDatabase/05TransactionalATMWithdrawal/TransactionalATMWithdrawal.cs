namespace ATMDatabase
{
    using System;
    using System.Linq;

    public class TransactionalATMWithdrawal
    {
        public static void Main()
        {
            var context = new ATMEntities();
            var requiredAmount = 200M;

            WithdrawMoney(context, requiredAmount);
        }

        private static void WithdrawMoney(ATMEntities context, decimal amount)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var account = context.CardAccounts.First();

                    if (account.CardNumber.Length != 10)
                    {
                        throw new InvalidOperationException("Card Number is invalid");
                    }

                    if (account.CardPIN.Length != 4)
                    {
                        throw new InvalidOperationException("Card PIN is invalid");
                    }

                    if (account.CardCash < amount)
                    {
                        throw new InvalidOperationException("Not enough money in the account.");
                    }

                    account.CardCash = account.CardCash - amount;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    Console.WriteLine("Withdraw was successful.");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }   
            }
        }
    }
}
