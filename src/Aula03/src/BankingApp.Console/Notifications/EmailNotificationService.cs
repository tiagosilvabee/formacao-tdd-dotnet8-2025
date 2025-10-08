using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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