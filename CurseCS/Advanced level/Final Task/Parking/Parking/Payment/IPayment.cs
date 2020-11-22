using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Payment
{
    public interface IPayment
    {
        void Pay(Client client, double amount);
    }
}
