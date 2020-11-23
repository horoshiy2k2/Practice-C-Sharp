using Parking.Models;
using Parking.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Payment
{
    class CardPayment : IPayment
    {
        public void Pay(Client client, double amount)
        {
            if (client.PaymentInfo != null)
            {
                if (client.PaymentInfo.MoneyAmount < amount)
                {
                    Console.WriteLine("У вас недостаточно денег на карте, оплатите наличными");

                    AppSettings.Payments["cash"].Pay(client, amount);
                    return;
                }
                else
                {
                    Console.WriteLine($"Вы успешно оплатили {amount:f2}$ картой {client.PaymentInfo.CreditCardType} {client.PaymentInfo.CreditCardNumber}\nХорошего дня, {client.FirstName}!");
                
                    ReportDay.PaidClents.Add(new DailyReport.PaidClent() 
                    {
                        PaymentMethod = "card", 
                        Amount = amount, 
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        Email = client.Email,
                        Phone = client.Phone
                    });
                }
            }
            else
            {
                Console.WriteLine("Нет данных о вашей карте, оплатите наличными");
                AppSettings.Payments["cash"].Pay(client, amount);
            }

            
        }
    }
}
