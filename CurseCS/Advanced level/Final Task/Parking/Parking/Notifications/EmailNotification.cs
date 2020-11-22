using Parking.Models;
using Parking.Settings;
using System;

namespace Parking.Notifications
{
    public class EmailNotification : INotification
    {
        public void Notify(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.Email) || !AppSettings.SendEndFreePeriodEmailNotifications)
            {
                return;
            }

            Console.WriteLine($"\nОтправили email на адрес {client.Email} с текстом 'уважаемый {client.FirstName} {client.LastName} бесплатный период закончился'");
        }
    }
}
