using System;

namespace TestLegibilidade
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if(initialBalance < 0) throw new ArgumentException("Saldo inicial não pode ser negativo.");
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Depósito deve ser positivo.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Saque deve ser positivo.");
            if (Balance - amount < 0) throw new InvalidOperationException("Saldo insuficiente.");
            Balance -= amount;
        }
    }
}