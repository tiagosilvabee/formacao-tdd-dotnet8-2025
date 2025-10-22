using System;

namespace BankingApp.Console.Notifications
{
    public class SmsNotificationService : INotificationService
    {
        public void Notify(string message)
        {
            System.Console.WriteLine($"SMS enviado: {message}");
        }
    }
}