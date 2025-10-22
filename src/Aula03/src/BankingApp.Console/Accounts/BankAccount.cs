using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Console.Accounts
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal balance)
        {
            if (balance <= 0)
            {
                throw new InvalidOperationException("Account can not be created with a negative or zero balance");
            }

            Balance = balance;
            AccountNumber = accountNumber;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Negative or zero amount can not be deposited in account");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("Negative or zero amount can not be withdrawed");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Value can not overdraft account balance");
            }

            Balance -= amount;
        }

    }
}