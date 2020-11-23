using Newtonsoft.Json;
using Parking.Models;
using Parking.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parking
{
    public class ParkingPlace : IDisposable
    {
        private  List<ParkedCar> _carsInParking;
        public ParkingPlace()
        {
            _carsInParking = new List<ParkedCar>();
            TotalCarPlaces = AppSettings.TotalCarPlaces;
        }

        public ParkingPlace(List<ParkedCar> carsInParking)
        {
            _carsInParking = carsInParking;
            TotalCarPlaces = AppSettings.TotalCarPlaces;
        }

        public int TotalCarPlaces { get; }

        public List<ParkedCar> CarsInParking => _carsInParking;

        public int FreeCarPlaces => AppSettings.TotalCarPlaces - OccupiedCarPlaces;

        public int OccupiedCarPlaces => _carsInParking.Count;

        public void Add(ParkedCar parkedCar)
        {
            _carsInParking.Add(parkedCar);
            parkedCar.Id = GetFreeID();
            parkedCar.InitialParkingTime = DateTime.Now;

            ReportDay.CarsPerDay.Add(parkedCar);
        }

        public void Remove(ParkedCar removedCar)
        {
            if (removedCar == null)
            {
                return;
            }

            _carsInParking.Remove(removedCar);

            var totalSecondsInParking = (DateTime.Now - removedCar.InitialParkingTime).Value.TotalSeconds;

            var paidCar = new LeavedCar()
            {
                Client = removedCar.Client,
                TotalSecondsInParking = totalSecondsInParking
            };

            if (totalSecondsInParking > AppSettings.FreePeriodInSeconds)
            {
                var amount = AppSettings.PricePerSeconds * (totalSecondsInParking - AppSettings.FreePeriodInSeconds);
 
                Console.WriteLine($"{removedCar.Client.FirstName}, Вы пробыли на парковке {totalSecondsInParking:f0} секунд. Ваш счёт: {amount:f2}$");
                
                ParkingManager.Pay(removedCar.Client, amount);
            }
            else
            {
                Console.WriteLine($"Вы успели уехать в бесплатный период. Хорошего дня, {removedCar.Client.FirstName}!");
            }

            ReportDay.LeavedCars.Add(paidCar);

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private int GetFreeID()
        {
            return _carsInParking.Select(x => x.Id).Max() + 1;
        }
    }
}
