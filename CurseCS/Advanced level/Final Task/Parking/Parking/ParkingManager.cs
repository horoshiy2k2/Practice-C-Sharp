using Parking.Models;
using Parking.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking
{
    public class ParkingManager
    {
        private readonly ParkingPlace _parking;

        public ParkingManager(ParkingPlace parking)
        {
            _parking = parking;
        }

        public void Add(ParkedCar addedCar)
        {
            _parking.Add(addedCar);
        }

        public void Remove(ParkedCar removedCar)
        {
            _parking.Remove(removedCar);
        }

        // remove??
        public void SerializeCarsInParking()
        {
            Helper.SerializeJson<ParkedCar>(AppSettings.CarsInParkingPath, _parking.CarsInParking);
        }

        public ParkedCar GetCarByID(string id)
        {
            var passedCars = _parking.CarsInParking.Where(x => x.Id.ToString() == id).Select(x => x).ToList(); 

            if (passedCars.Count == 0)
            {
                Console.WriteLine($"На парковке нет машины с таким ID: {id}");
                return null;
            }

            return passedCars[0];
        }

        public static void Pay(Client client, double amount)
        {
            while (true)
            {
                Console.WriteLine($"Введите способ оплаты:\n1. cash\n2. card");

                var paymentMethod = Program.SanitizeString(Console.ReadLine());

                Console.Clear();

                if (paymentMethod == "cash" || paymentMethod == "card") // можно добавлять новые методы
                {
                    AppSettings.Payments[paymentMethod].Pay(client, amount);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Не удалось считать строку, попробуйте ещё раз");
                }
            }
        }
    }
}
