using Bank;

namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {
            // ARRANGE / Initialize data
            Account account = new Account();

            // ACT / Method calls

            double balance = account.Balance;
            // ASSERT / Test the result is as expected
            // check the state after the method call and make the test pass if the actual value is as expected

            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void Credit_999OnBalance0_Returns999()
        {
            // ARRANGE
            Account account = new Account();

            // ACT
            account.Credit(999);
            double balance = account.Balance;

            // ASSERT
            Assert.AreEqual(999, balance);
        }

        [TestMethod]
        public void Debit_500FromBalance500_Returns0()
        {
            // ARRANGE
            Account account = new Account();

            // ACT
            account.Credit(500);
            account.Debit(500);
            double balance = account.Balance;

            // ASSERT
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void Credit_NegativeAmount_ReturnsOutOfRangeException()
        {
            // ARRANGE
            Account account = new Account();

            // ASSERT
            Assert.ThrowsException<ArgumentOutOfRangeException>(
            () => account.Credit(-200) // ACT

            );
        }

        [TestMethod]
        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            // ARRANGE
            Account account = new Account();

            // ACT

            // ASSERT
            Assert.ThrowsException<BalanceInsufficientException>(
            () => account.Debit(300)

            );
        }
    }
}