using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class LeavedCar
    {
        public double TotalSecondsInParking { get; set; }

        public Client Client { get; set; }

        public string PaymentMethod { get; set; }
    }
}
