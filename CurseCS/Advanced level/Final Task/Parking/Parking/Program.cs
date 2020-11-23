using Newtonsoft.Json;
using Parking.Models;
using Parking.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Parking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppSettings.Initialize();

            var random = new Random();
            var parking = GetParkingPlace();
            var parkingManager = new ParkingManager(parking);

            var parkedCarsDB = new List<ParkedCar>();
            using (StreamReader sr = new StreamReader(AppSettings.ParkedCarsPath))
            {
                parkedCarsDB = JsonConvert.DeserializeObject<List<ParkedCar>>(sr.ReadToEnd());
            }

            var periodTimeSpanDailyReport = DateTime.Now.AddSeconds(AppSettings.DailyReportPeriodInSeconds) - DateTime.Now;
            var printDailyReportTimerCallback = new TimerCallback(ReportDay.PrintDailyReport);
            var timerDailyReport = new Timer(printDailyReportTimerCallback, parking.CarsInParking, periodTimeSpanDailyReport, Timeout.InfiniteTimeSpan);

            bool notLeaveProgram = true;
            do
            {
                Console.WriteLine($"\n{DateTime.Now:T}");
                Console.WriteLine("Введите одну из 4-х команд");
                Console.WriteLine("1. add - добавить машину на парковку");
                Console.WriteLine("2. remove - убрать машину с парковки");
                Console.WriteLine("3. getall - получить все машины на парковке на текущий момент");
                Console.WriteLine("4. q - выйти из программы");

                var command = SanitizeString(Console.ReadLine());

                switch (command)
                {
                    case "add":
                        var parkedCar = parkedCarsDB[random.Next(0, parkedCarsDB.Count)];

                        AddCarToParking(parkedCar, parkingManager);
                        break;

                    case "remove":
                        Console.Clear();
                        Console.WriteLine("Введите id машины, которую хотите удалить: ");

                        getAll(parking.CarsInParking);

                        var removedCar = parkingManager.GetCarByID(Console.ReadLine());

                        parkingManager.Remove(removedCar);
                        break;

                    case "getall":
                        Console.Clear();

                        getAll(parking.CarsInParking);
                        break;

                    case "q":
                        parkingManager.SerializeCarsInParking();

                        notLeaveProgram = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Ну ты даёшь, введи нормально!");
                        break;
                }
            } while (notLeaveProgram);
        }

        public static string SanitizeString(string str)
        {
            return str?.Trim().ToLower();
        }

        private static void AddCarToParking(ParkedCar parkedCar, ParkingManager parkingManager)
        {
            if(parkingManager.GetCountFreeCarPlaces() <= 0)
            {
                Console.Clear();
                Console.WriteLine($"К сожалению, все места на парковке заняты, {parkedCar.Client.FirstName} уезжает на своей {parkedCar.Car.Make} на другую парковку");
                return;
            }

            var timerStartTimeSpan = DateTime.Now.AddSeconds(AppSettings.FreePeriodInSeconds) - DateTime.Now;
            var notify = new TimerCallback(Notify);
            var timer = new Timer(notify, parkedCar.Client, timerStartTimeSpan, Timeout.InfiniteTimeSpan);

            parkingManager.Add(parkedCar);

            Console.Clear();

            Console.WriteLine($"На парковку заехала машина: {parkedCar}");

        }

        public static void Notify(object obj)
        {
            Client client = obj as Client;
            if (client == null)
            {
                return;
            }

            foreach (var notification in AppSettings.Notifications)
            {
                notification.Notify(client);
            }
        }

        public static ParkingPlace GetParkingPlace()
        {
            if (!File.Exists(AppSettings.CarsInParkingPath))
            {
                return new ParkingPlace();
            }
            else
            {
                using (StreamReader sr = new StreamReader(AppSettings.CarsInParkingPath))
                {
                    var carsInParking = JsonConvert.DeserializeObject<List<ParkedCar>>(sr.ReadToEnd());;

                    if (carsInParking == null)
                    {
                        return new ParkingPlace();
                    }
                    else
                    {
                        return new ParkingPlace(carsInParking);
                    }
                }               
            }
        }

        public static void getAll(List<ParkedCar> parkedCars)
        {
            if (parkedCars.Count == 0)
            {
                Console.WriteLine("Парковка пуста");
                return;
            }
            foreach (var car in parkedCars)
            {
                Console.WriteLine($"id: {car.Id}\tсекунд на парковке: {(DateTime.Now - car.InitialParkingTime).Value.TotalSeconds:f0}\t{car.Car.Make}\tвладелец: {car.Client.FirstName}");
            }
        }
    }
}
