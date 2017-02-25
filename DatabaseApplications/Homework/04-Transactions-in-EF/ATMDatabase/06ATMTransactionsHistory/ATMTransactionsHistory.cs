namespace ATMDatabase
{
    using System;
    using System.Linq;

    public class ATMTransactionsHistory
    {
        public static void Main()
        {
            var context = new ATMEntities();
            var requiredAmount = 200M;

            WithdrawMoneyExtended(context, requiredAmount);
        }

        private static void WithdrawMoneyExtended(ATMEntities context, decimal amount)
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

                    var transactionHistory = new TransactionHistory
                                                 {
                                                     CardNumber = account.CardNumber,
                                                     TransactionDate = DateTime.Now,
                                                     Amount = amount
                                                 };

                    context.TransactionHistories.Add(transactionHistory);

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
