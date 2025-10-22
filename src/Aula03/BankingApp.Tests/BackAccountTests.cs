using BankingApp.Console.Accounts;
using Xunit;

namespace BankingApp.Tests;

public class BackAccountTests
{
    [Fact]
    public void Should_NotCreateAccount_WithNegativeInitialBalance()
    {
        Assert.Throws<InvalidOperationException>(() => new BankAccount("123", -100m));
    }

    [Fact]
    public void Should_CreateAccount_WithInitialBalance()
    {
        var account = new BankAccount("123", 100m);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Should_DepositMoney()
    {
        // Given
        var account = new BankAccount("123", 100m);

        // When
        account.Deposit(50m);

        // Then
        Assert.Equal(150m, account.Balance);
    }

    [Theory]
    [InlineData(200, 30, 230)]
    [InlineData(100, 30, 130)]
    [InlineData(50, 30, 80)]
    public void Should_DepositMoney_WithTheory(decimal initialAmount, decimal balance, decimal finalAmount)
    {
        // Given
        var account = new BankAccount("123", initialAmount);

        // When
        account.Deposit(balance);

        // Then
        Assert.Equal(finalAmount, account.Balance);

    }

    [Fact]
    public void Should_WithdrawMoney()
    {
        // Given
        var account = new BankAccount("123", 100m);

        // When
        account.Withdraw(40m);

        // Then
        Assert.Equal(60m, account.Balance);

    }

    [Fact]
    public void Should_NotAllow_Overdraft()
    {
        // Given
        var account = new BankAccount("123", 100m);
        // When

        // Then
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(200m));
        Assert.Throws<InvalidOperationException>(() => account.Deposit(-200m));
    }
}
