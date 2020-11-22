using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Payment
{
    class CashPayment : IPayment
    {
        public void Pay(Client client, double amount)
        {
            Console.WriteLine($"Вы успешно оплатили {amount:f2}$ наличными\nХорошего дня, {client.FirstName}!");
        }
    }
}
