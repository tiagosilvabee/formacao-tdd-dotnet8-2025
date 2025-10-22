using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Console.Notifications
{
    public interface INotificationService
    {
        void Notify(string message);        
    }
}