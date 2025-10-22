using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Console.Notifications;

namespace BankingApp.Console.Accounts
{
    public class BankAccountManager
    {
        private readonly INotificationService _notificationService;

        public BankAccountManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Deposit(BankAccount account, decimal amount)
        {
            account.Deposit(amount);
            _notificationService.Notify($"Depósito de {amount:C} realizado na conta {account.AccountNumber}.");
        }

        public void Withdraw(BankAccount account, decimal amount)
        {
            account.Withdraw(amount);
            _notificationService.Notify($"Levantamento de {amount:C} realizado na conta {account.AccountNumber}.");
        }
    }
}