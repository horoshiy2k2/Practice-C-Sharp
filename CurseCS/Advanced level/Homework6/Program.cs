using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
            var cars = new List<Car>();

            DeserializeJson(path, ref cars); 

            Console.WriteLine("Введите количество лет: ");
            var n = Convert.ToInt32(Console.ReadLine());


            foreach (var car in cars)
            {
                var costAfter = car.Cost * (1 - 0.1 * n);
                var milleage = int.Parse(car.Mileage) + 20000 * n;

                if (costAfter >= 0)
                {
                    car.CostAfterNYears = costAfter.ToString(); // 10% стоимости за год теряет
                    car.MileageAfterNYears = milleage.ToString();
                }
                else
                {
                    car.CostAfterNYears = "Ваша машина утилизирована";
                    car.MileageAfterNYears = $"Ваша машина пробежала БЫ {milleage} в {car.Year.Year + n} году";
                }

                car.AfterNYears = car.Year.AddYears(n);
            }

            var newPath = Path.Combine(Directory.GetCurrentDirectory(), "Cars after n years.json");
            SerializeJson(newPath, cars);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Cars after n years.txt");
            SaveCarsInFile(filePath, cars);

        }

        public static void SerializeJson(string path, List<Car> cars)
        {
            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, cars);

                Console.WriteLine("Объект cереализован");
            }
        }


        public static void DeserializeJson(string path, ref List<Car> cars)
        {
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                cars = serializer.Deserialize<List<Car>>(reader);
            }
        }

        public static void SaveCarsInFile(string path, List<Car> cars)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var car in cars)
                {
                    sw.WriteLine(car.Brand);
                    sw.WriteLine(car.Model);
                    sw.WriteLine($"Год выпуска: {car.Year:yyyy}");

                    double costAfter = -1;
                    var success = double.TryParse(car.CostAfterNYears, out costAfter);

                    if (success && costAfter >= 0)
                    {
                        sw.WriteLine($"Подешевела на {car.Cost - costAfter}$");
                        sw.WriteLine($"Пробег: {car.MileageAfterNYears} км");
                    }
                    else
                    {
                        sw.WriteLine("Ваша машина утилизирована");
                        sw.WriteLine(car.MileageAfterNYears);
                    }

                    sw.WriteLine();
                }
                Console.WriteLine($"Объект записан в файл {path}");
            }
        }
    }
}
