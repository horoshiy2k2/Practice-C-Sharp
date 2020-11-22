using Parking.Models;
using Parking.Settings;
using System;

namespace Parking.Notifications
{
    public class SmsNotification : INotification
    {
        public void Notify(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.Phone) || !AppSettings.SendEndFreePeriodSmsNotifications)
            {
                return;
            }

            Console.WriteLine($"\nОтправили SMS на телефон {client.Phone} с текстом 'уважаемый {client.FirstName} {client.LastName} бесплатный период закончился'");
        }
    }
}