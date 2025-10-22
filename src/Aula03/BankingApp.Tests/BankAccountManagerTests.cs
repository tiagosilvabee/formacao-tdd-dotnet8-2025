using BankingApp.Console.Accounts;
using BankingApp.Console.Notifications;
using Xunit;

public class BankAccountManagerTests
{
    [Fact]
    public void Should_SendNotification_OnDeposit()
    {
        // Given
        var account = new BankAccount("123", 100m);
        var notificationService = new TestNotificationService();
        var manager = new BankAccountManager(notificationService);

        // When
        manager.Deposit(account, 50m);

        // Then
        Assert.Contains("Depósito de 50", notificationService.Messages[0]);
    }

    [Fact]
    public void Should_SendNotification_OnWithdraw()
    {
        // Given
        var account = new BankAccount("123", 100m);
        var notificationService = new TestNotificationService();
        var manager = new BankAccountManager(notificationService);

        // When
        manager.Withdraw(account, 50m);

        // Then
        Assert.Contains("Saque de 50", notificationService.Messages[0]);
    }
}

public class TestNotificationService : INotificationService
{
    public List<string> Messages { get; } = new List<string>();
    public void Notify(string message) => Messages.Add(message);
}