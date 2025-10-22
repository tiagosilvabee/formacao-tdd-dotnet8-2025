using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingApp.Console.Notifications;

namespace BankingApp.Tests.Notifications
{
    public class TestNotificationService : INotificationService
    {
        public List<string> Messages { get; } = [];
        public void Notify(string message) => Messages.Add(message);
    }
}