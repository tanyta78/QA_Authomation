using ConsoleApplication1;
using NUnit.Framework;
using System;

namespace NUnitFirstTry
{
    [TestFixture]
    public class BankAccountTestCases
    {
        [Test]
        public void BankAccountDepositWithPositiveValue()
        {
            
            BankAcount acc = new BankAcount(3333);
            Assert.AreEqual(3333, acc.Amount);
        }
        
        [Test]
        //Write a test that check that exception is thrown when you instantiate BankAccount with negative money
        public void AcountInitializeWithNegaiveValue()
        {
            Assert.Throws<ArgumentException>(() => new BankAcount(-1m));
        }

        [Test]
        //Write a test that check Withdraw() method get right amount of money for bank transfer
        //If withdraw amount is less than 1000 transfer fee is 2% of withdrawn amount

        public void CheckFeeAmountWithdrowlessThanThousand()
        {
            var acountAmount = 1500m;
            BankAcount acc = new BankAcount(acountAmount);
            var amount = 600m;
            var expectedResult = acountAmount - amount*0.02m;
            acc.Withdraw(amount);
            Assert.AreEqual(expectedResult,acc.Amount);

        }
        [Test]
        //Write a test that check Withdraw() method get right amount of money for bank transfer
        //If withdraw amount is greater than 1000 transfer fee is 5% of withdrawn amount
        public void CheckFeeAmountWithdrowMoreThanThousand()
        {
            var acountAmount = 1500m;
            BankAcount acc = new BankAcount(acountAmount);
            var amount = 1000m;
            var expectedResult = acountAmount - amount * 0.05m;
            acc.Withdraw(amount);
            Assert.AreEqual(expectedResult, acc.Amount);

        }


        // Write five more tests against BankAccount that test its functionality.Use five different type of asserts for these tests.
        [Test]
        //Write a test that check that exception is thrown when you deposit  negative money
        public void AcountDepositWithNegativeValue()
        {

            Assert.Throws<ArgumentException>(() => new BankAcount(1000).Deposit(-1006));
        }
        [Test]
        //Write a test that check that exeption is thrown when you withdraw more money that you have
        public void AcountWithdrawWithMoreMoney()
        {
            BankAcount acc = new BankAcount(1000m);
            Assert.Throws<ArgumentException>(() => acc.Withdraw(1300m));
        }

        [Test]
        //Write a test that check exeption text that is thrown when you withdraw more money that you have
        public void CheckCorrectExceptionText()
        {
            BankAcount acc = new BankAcount(500m);
            var exception = Assert.Throws<ArgumentException>(() => acc.Withdraw(600m));
            Assert.AreEqual("Amount can not be negative!", exception.Message);
            
        }
        [Test]
        //Write a test that check  exception  text that is thrown when you deposit negative money
        public void AcountDepositWithNegativeValueExceptionText()
        {

           var exception = Assert.Throws<ArgumentException>(() => new BankAcount(1000).Deposit(-100));
           StringAssert.Contains("Deposit can not be negative!", exception.Message);
        }


    }
}
