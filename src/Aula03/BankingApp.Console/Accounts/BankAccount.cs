namespace BankingApp.Console.Accounts;

public class BankAccount
{
    public string AccountNumber { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, decimal balance)
    {
        if (balance < 0)
        {
            throw new InvalidOperationException();
        }
        this.AccountNumber = accountNumber;
        this.Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new InvalidOperationException();
        }
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > this.Balance || amount < 0) {
            throw new InvalidOperationException();
        }
        this.Balance -= amount;
    }
}