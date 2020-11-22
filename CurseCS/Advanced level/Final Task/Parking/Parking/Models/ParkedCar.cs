using System;

namespace Parking.Models
{
    public class ParkedCar // обёртка над машиной. Машины на стоянке
    {
        public int Id { get; set; } // С ID разобраться (ADD)

        public DateTime? InitialParkingTime { get; set; }

        public Client Client { get; set; }

        public Car Car { get; set; } // марка машины

        public override string ToString()
        {
            return $"{Car.Make}\tвладелец: {Client.FirstName}\tid:{Id}";
        }
    }
}
