namespace UnitTests
{
    using System;
    using NUnit.Framework;
    using TestApplication;
    using Extensions;

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void InstantiateBankAccountWithNegativeMoneyShouldThrowArgumentException()
        {
            //// Arrange
            var negativeAmount = -1m;

            //// Assert
            Assert.Throws<ArgumentException>(() => new BankAcount(negativeAmount), "Amount can not be negative!");
        }

        [Test]
        public void DepositeZeroMoneyShouldNotThrowArgumentException()
        {
            //// Arrange
            var account = new BankAcount(0m);

            //// Assert
            Assert.DoesNotThrow(() => account.Deposit(0m));
        }

        [Test]
        public void BankAccountAmountMustBeInDecimalType()
        {
            //// Arrange
            var account = new BankAcount(100m);
            var expectedType = typeof(decimal);

            //// Act
            var amount = account.Amount;

            //// Assert
            Assert.IsInstanceOf(expectedType, amount);
        }

        [Test]
        public void WithdrawMustDecreaseAmountOfMoneyForBankTransfer()
        {
            //// Arrange
            var initialAmount = 1000m;
            var account = new BankAcount(initialAmount);

            //// Act
            account.Withdraw(100m);
            var isDecreased = account.Amount < initialAmount;

            //// Assert
            Assert.IsTrue(isDecreased);
        }

        [Test]
        public void DepositMustIncreaseAmountOfMoneyForBankTransfer()
        {
            //// Arrange
            var initialAmount = 0m;
            var account = new BankAcount(initialAmount);

            //// Act
            account.Deposit(100m);
            var isNotSame = account.Amount == initialAmount;

            //// Assert
            Assert.IsFalse(isNotSame);
        }

        [Test]
        public void DepositMustSetRightAmountOfMoneyForBankTransfer()
        {
            //// Arrange
            var account = new BankAcount(0m);
            var expectedAmount = 1000m;

            //// Act
            account.Deposit(expectedAmount);
            var actualAmount = account.Amount;
            var amountAreEqual = expectedAmount.Equals(actualAmount);

            //// Assert
            Assert.That(amountAreEqual);
        }

        [Test]
        public void WithdrawMustGetRightAmountOfMoneyForBankTransfer()
        {
            //// Arrange
            var account = new BankAcount(10000000m);

            for (int a = 1; a < 1000; a++)
            {
                //// Assert
                account.AssertWithdraw(a, 2m);
            }

            for (int b = 1000; b < 2000; b++)
            {
                //// Assert
                account.AssertWithdraw(b, 5m);
            }
        }
    }
}
