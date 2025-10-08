using BankingApp.Console.Accounts;

namespace BankingApp.Tests.Account;

public class UnitTest1
{
    [Fact]
    public void Should_CreateAccount_WithInitialBalance()
    {
        var account = new BankAccount("123", 100m);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Should_Not_CreateAccount_WithNegativeInitialBalance()
    {
        Assert.Throws<InvalidOperationException>(() => new BankAccount("123", -100m));
    }

    [Fact]
    public void Should_DepositMoney()
    {
        var account = new BankAccount("123", 100m);
        account.Deposit(50m);
        Assert.Equal(150m, account.Balance);
    }


    [Theory]
    [InlineData(200, 30, 230)]
    [InlineData(100, 30, 130)]
    [InlineData(50, 30, 80)]
    public void Should_DepositMoney_WithTheory(decimal initialAmount, decimal value, decimal finalAmount)
    {
        var account = new BankAccount("123", initialAmount);
        account.Deposit(value);
        Assert.Equal(finalAmount, account.Balance);
    }


    [Fact]
    public void Should_Not_DepositNegativeMoney()
    {
        var account = new BankAccount("123", 100m);
         Assert.Throws<InvalidOperationException>(() => account.Deposit(-50m));
    }



    [Fact]
    public void Should_WithdrawMoney()
    {
        var account = new BankAccount("123", 100m);
        account.Withdraw(40m);
        Assert.Equal(60m, account.Balance);
    }

    
    [Fact]
    public void Should_Not_WithdrawNegativeMoney()
    {
        var account = new BankAccount("123", 100m);
         Assert.Throws<InvalidOperationException>(() => account.Withdraw(-50m));
    }

    [Fact]
    public void Should_NotAllow_Overdraft()
    {
        var account = new BankAccount("123", 100m);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(200m));
    }
}
