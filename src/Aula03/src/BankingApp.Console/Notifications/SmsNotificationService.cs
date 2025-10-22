using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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