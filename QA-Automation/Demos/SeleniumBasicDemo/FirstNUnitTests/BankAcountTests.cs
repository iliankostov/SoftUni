using NUnit.Framework;
using SeleniumBasicDemo;
using System;

namespace FirstNUnitTests
{
    [TestFixture]
    public class BankAcountTests
    {
        [Test]
        public void AcountInitializeWithPositiveValue()
        {
            BankAcount acount = new BankAcount(2000m);
            Assert.AreEqual(2000m, acount.Amount);
        }

        [Test]
        public void AcountInitializeWithNegaiveValue()
        {
            BankAcount acount = new BankAcount(-1m);
            Assert.Throws<ArgumentException>(() => acount.Withdraw(300m));
        }

        [Test]
        public void AcountWithdrawWithMoreMoney()
        {
            BankAcount acount = new BankAcount(200m);
            Assert.Throws<ArgumentException>(() => acount.Withdraw(300m));
        }

        [Test]
        public void AcountDepositNegativevalue()
        {
            BankAcount acount = new BankAcount(200m);
            Assert.Throws<ArgumentException>(() => acount.Deposit(-300m));
        }
    }
}
