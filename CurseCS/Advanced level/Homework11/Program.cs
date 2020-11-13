using System;
using System.Linq;

namespace Lesson20
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = Helper.GetObjects<Car>("cars.json");
            var cities = Helper.GetObjects<City>("cities.json");


            //var result1 = cars.Skip(10);
            //var result2 = cars.Take(10);


            //foreach (var item in result1)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("\nПервые 10 машин: \n");
            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}

            //var count = cars.Count();
            //var sum = cars.Sum(x => x.CarModelYear);
            //var average = cars.Average(x => x.CarModelYear);
            //var min = cars.Min(x => x.CarModelYear);
            //var max = cars.Max(x => x.CarModelYear);

            //Console.WriteLine(count);
            //Console.WriteLine(sum);
            //Console.WriteLine(average);
            //Console.WriteLine(min);
            //Console.WriteLine(max);

            //// через анонимные типы пробнуть можно new {} new {}
            //var result = cars.Select(x => x.CarModelYear).Intersect(cities.Select(x => x.CityYear));

            //foreach (var car in result)
            //{
            //    Console.WriteLine(car);
            //}

            //bool result = cars.All(x => x.CarModelYear > 1980);

            ////!!!ВМЕСТО COUNT!!! на IEnumerable, на коллекции можно count, где это свойство, а тут это Count() - метод, можно и эни там и там.
            //bool result2 = cars.Any(); // true если содержит хоть какой-то элемент. проверит только 1ый элемент и вернёт 

            //Console.WriteLine(result2);


            

            //var result = cars
            //    .OrderBy(x => x.CarModelYear)
            //    .Reverse()
            //    .GroupBy(x => x.CarModelYear)
            //    .ToList();

            //foreach (var year in result)
            //{
            //    Console.WriteLine("\n" + year.Key);

            //    foreach (var car in year)
            //    {
            //        Console.WriteLine(car);
            //    }
            //}


            //var query = from car in cars
            //            join city in cities
            //            on car.CarModelYear equals city.CityYear
            //            orderby car.CarModelYear
            //            select new
            //            {
            //                car.CarModelYear,
            //                car.CarMake,
            //                car.CarModel,
            //                city.CityName
            //            };

            //query.Distinct();

            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}
            //var anon = new { FirstName = "Vanya", Age = 23 };

            //var cars = Helper.GetObjects<Car>();

            //var cars1 = cars.Where(x => x.CarModel.StartsWith("T"));

            //foreach (var car in cars1)
            //{
            //    Console.WriteLine(car);
            //}

            //Console.WriteLine("\nМашины 1998+ года:\n");

            //var cars2 = cars.Where(x => x.CarModelYear > 1998 && x.CarModel.Length > 5)
            //    .OrderByDescending(x => x.CarMake)
            //    .ThenByDescending(x => x.CarModelYear);//.Select(x => new { x.CarModelYear }); // анонимный тип для селекции выборки

            //foreach (var car in cars2)
            //{
            //    Console.WriteLine(car); // toString у анонимного метода
            //}
        }
    }
}
