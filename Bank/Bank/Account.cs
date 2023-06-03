using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BalanceInsufficientException : ApplicationException { }

    public class Account
    {
        private double balance = 0;

        public void Credit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            } else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Debit(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
            } else if (balance < amount)
            {
                throw new BalanceInsufficientException();
            }
        }

        public double Balance
        {
            get { return balance; }
        }
    }
}
