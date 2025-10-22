using BankingApp.Console.Accounts;
using BankingApp.Tests.Notifications;

namespace BankingApp.Tests.Account;

public class BankAccountManagerTests
{
    [Fact]
    public void Should_SendNotification_OnDeposit()
    {
        var account = new BankAccount("123", 100m);
        var notificationService = new TestNotificationService();
        var manager = new BankAccountManager(notificationService);

        manager.Deposit(account, 50m);
        Assert.Contains($"Depósito de {50:c}", notificationService.Messages[0]);
    }


    [Fact]
    public void Should_SendNotification_OnWithdraw()
    {
        var account = new BankAccount("123", 100m);
        var notificationService = new TestNotificationService();
        var manager = new BankAccountManager(notificationService);

        manager.Withdraw(account, 50m);
        Assert.Contains($"Levantamento de {50:c}", notificationService.Messages[0]);
    }
}