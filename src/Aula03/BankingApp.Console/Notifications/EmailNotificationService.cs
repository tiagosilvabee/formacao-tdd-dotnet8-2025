using System;

namespace BankingApp.Console.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            System.Console.WriteLine($"Email enviado: {message}");
        }
    }
}