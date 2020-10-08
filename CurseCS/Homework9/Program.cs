using System;

namespace z_9_1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var arrVehicle = generateRandomArray();

            foreach (var vehicle in arrVehicle)
            {
                Console.WriteLine(vehicle);
            }

            

            var brand = Brands.Audi.ToString();
            
            Console.WriteLine($"Цена машин марки {brand}:"); ;

            Car carAudi = new Car() { Brand = brand };
            foreach (var vehicle in arrVehicle)
            {
                if (vehicle is Car)
                {
                    if (carAudi.Equals(vehicle)) Console.WriteLine($"{vehicle.Cost}$"); 
                }
            }

            var boing = new Plane() { Height = 11000 };

            Console.WriteLine($"\nСамолёты, летающие на высоте полёта боинга ({boing.Height}м):");

            foreach (var vehicle in arrVehicle)
            {
                if (vehicle is Plane)
                {
                    if (object.Equals(boing, vehicle)) Console.WriteLine(vehicle.ToString()); 
                }
            }

            var PirateShip = new Ship() { NamePort = "Port2"};

            Console.WriteLine($"\nКорабли, находящиеся с пиратским кораблём в том же порту ({PirateShip.NamePort}):");

            foreach (var vehicle in arrVehicle)
            {
                if (vehicle is Ship)
                {
                    if (PirateShip.Equals(vehicle)) Console.WriteLine(vehicle.ToString()); // == то же что и Equals ??? с брэйкпоинтом чекнуть
                }
            }
        }
        
        // Генерирует массив Vehicle со случайными значениями
        static Vehicle[] generateRandomArray ()
        {
            var rand = new Random();
            var lengthArray = rand.Next(15, 25);
            var arr = new Vehicle[lengthArray];

            for (int i = 0; i < arr.Length; i++)
            {
                var randomNumber13 = rand.Next(1, 4); // 1 2 3 - случайный транспорт
                switch (randomNumber13)
                {
                    case 1:
                        arr[i] = new Car() {Brand = ((Brands)rand.Next(0, 3)).ToString(), CountWheel = rand.Next(2, 5) * 2};
                        break;
                    case 2:
                        arr[i] = new Ship() { CountPassengers = rand.Next(1000, 5000), NamePort = "Port" + (i % 2 + 1) };
                        break;
                    case 3:
                        arr[i] = new Plane() { CountPassengers = rand.Next(320, 540), Height = rand.Next(10, 12) * 1000 };
                        break;
                }

                arr[i].Coordinate = new Coordinate(rand.Next(-100, 100), rand.Next(-100, 100));
                arr[i].Cost = rand.Next(500, 10000);
                arr[i].Speed = rand.NextDouble() * 100;
                arr[i].Year = rand.Next(1900, 2020);
            }

            return arr;
        }
    }
}


