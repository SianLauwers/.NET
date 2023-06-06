using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;

namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {
            //ARRANGE
            Account account = new Account();
            //ACT
            double balance = account.Balance;
            //ASSERT
            Assert.AreEqual(0, balance);
        }
        [TestMethod]
        public void Credit_999OnBalance0_Returns999()
        {
            //ARRANGE
            Account account = new Account();
            //ACT
            account.Credit(999);
            //ASSERT
            Assert.AreEqual(999, account.Balance);
        }
        [TestMethod]
        public void Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            //ARRANGE
            Account account = new Account();
            //ASSERT                                                  //ACT          
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(-200));
        }
        [TestMethod]
        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            //ARRANGE
            Account account = new Account();
            account.Credit(200);
            //ASSERT                                                  //ACT          
            Assert.ThrowsException<BalanceInsufficientException>(() => account.Dedit(500));
        }

    }
}
