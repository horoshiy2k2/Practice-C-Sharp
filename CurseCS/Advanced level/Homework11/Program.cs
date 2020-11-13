using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = Helper.GetObjectsFromJson<Car>("cars.json");
            var clients = Helper.GetObjectsFromJson<Client>("clients.json");
            var r = new Random();

            var someClients = new List<Client>();

            var countOffers = 10;

            for (int i = 0; i < countOffers; i++)
            {
                var car = cars[r.Next(0, cars.Count)];
                var client = clients[r.Next(0, cars.Count)];

                var newClient = new Client() {CarModel = car.Model, Name = client.Name, Phone = client.Phone };
                someClients.Add(newClient);
            }
            
            var someClient = someClients[r.Next(0, someClients.Count)];
            Console.WriteLine($"Случайный клиент: {someClient}\n");

            var someClientCar = cars.First(x => x.Model == someClient.CarModel);
            Console.WriteLine($"Его машина: {someClientCar}\n\n");

            var myModel = cars[r.Next(0, cars.Count)].Model;

            Console.WriteLine($"Машины {myModel}:\n");

            var carsGroupModel = cars.GroupBy(x => x.Model);
            var counter = 0;

            foreach (var model in carsGroupModel)
            {
                if (model.Key == myModel)
                {
                    foreach (var car in model)
                    {
                        Console.WriteLine(car);
                        counter++;
                    }

                    break;
                }
            }

            Console.WriteLine($"Количество машин {myModel}: {counter}\n");

            var CostAllCars = cars.Sum(x => x.Cost);
            var oldestYear = cars.Min(x => x.ModelYear);
            var newestYear = cars.Max(x => x.ModelYear);

            var oldestСars = cars.Where(x => x.ModelYear == oldestYear).ToList();
            var newestСars = cars.Where(x => x.ModelYear == newestYear).ToList();

            Console.WriteLine($"Стоимость всех машин: {CostAllCars}$");

            Console.WriteLine("\nСамые старые машины:\n");
            Helper.ShowColletion(oldestСars);

            Console.WriteLine("\nСамые новые машины:\n");
            Helper.ShowColletion(newestСars);

            foreach (var client in someClients)
            {
                Console.WriteLine($"\nПокупатель: {client}\nЕго машины:\n\n");
                
                var clientCars = cars.Where(x => x.Model == client.CarModel).ToList();
                Helper.ShowColletion(clientCars);
            }
        }
    }
}
