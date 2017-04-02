namespace UnitTests.Extensions
{
    using NUnit.Framework;
    using TestApplication;

    public static class BankAccountExtensions
    {
        private const int percentageCoefficient = 100;

        public static void AssertWithdraw(this BankAcount account, decimal amount, decimal fee)
        {
            //// Arrange
            var amountBefore = account.Amount;
            var expectedFee = amount * fee / percentageCoefficient;
            var expectedAmount = amount + expectedFee;

            //// Act
            account.Withdraw(amount);
            var actualAmount = amountBefore - account.Amount;
            var actualFee = actualAmount - amount;

            //// Assert
            Assert.AreEqual(expectedAmount, actualAmount);
            Assert.AreEqual(expectedFee, actualFee);
        }
    }
}
