using System;

namespace Parking.Models
{
    public class ParkedCar
    {
        public int Id { get; set; } 

        public DateTime? InitialParkingTime { get; set; }

        public Client Client { get; set; }

        public Car Car { get; set; }

        public override string ToString()
        {
            return $"{Car.Make}\tвладелец: {Client.FirstName}\tid:{Id}";
        }
    }
}
