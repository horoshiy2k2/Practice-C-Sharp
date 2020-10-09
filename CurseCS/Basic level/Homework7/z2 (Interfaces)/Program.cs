using System;

namespace Z1
{
    interface IFigure
    {
        double Volume { get; set; }
        string Name { get; set; }
        void SetVolume();
    }


    //parallelepiped, pyramid, tetrahedron, ball
    class Parallelepiped : IFigure
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Volume { get; set; }
        public string Name { get; set; }

        private static int _count = 0; // Счётчик параллелепипедов - тест

        public Parallelepiped(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Name = "Parallelepiped" + ++_count; //счётчик параллелепипедов
            SetVolume();
        }

        public void SetVolume()
        {
            Volume = X * Y * Z;
        }
    }

    class Pyramid : IFigure
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        public double Volume { get; set; }
        public string Name { get; set; }
        private static int _count = 0; // Счётчик

        public Pyramid(double x, double y, double h)
        {
            X = x;
            Y = y;
            H = h;
            Name = "Pyramid" + ++_count;
            SetVolume();
        }

        public void SetVolume()
        {
            Volume = X * Y * H / 3;
        }
    }

    class Tetrahedron : IFigure
    {
        public double A { get; set; }
        public double Volume { get; set; }
        public string Name { get; set; }
        private static int _count = 0; // Счётчик

        public Tetrahedron(double a)
        {
            A = a;
            Name = "Tetrahedron" + ++_count;
            SetVolume();
        }

        public void SetVolume()
        {
            Volume = Math.Pow(A, 3) * Math.Sqrt(2) / 12;
        }
    }

    class Ball : IFigure
    {
        public double R { get; set; }
        public double Volume { get; set; }
        public string Name { get; set; }
        private static int _count = 0; // Счётчик

        public Ball(double r)
        {
            R = r;
            Name = "Ball" + ++_count;
            SetVolume();
        }

        public void SetVolume()
        {
            Volume = 4 * Math.PI * Math.Pow(R, 3) / 3;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var lengthArray = rand.Next(10, 21);
            var arrIFigures = new IFigure[lengthArray];

            //генерируем массив фигур со случайными значениями
            for (int i = 0; i < arrIFigures.Length; i++)
            {
                var randomNumber14 = rand.Next(1, 5); // 1 2 3 4 - случайную фигуру
                switch (randomNumber14)
                {
                    case 1:
                        arrIFigures[i] = new Parallelepiped(rand.NextDouble() * 10, rand.NextDouble() * 10, rand.NextDouble() * 10); // от 1 до 10
                        break;
                    case 2:
                        arrIFigures[i] = new Pyramid(rand.NextDouble() * 10, rand.NextDouble() * 10, rand.NextDouble() * 10);
                        break;
                    case 3:
                        arrIFigures[i] = new Tetrahedron(rand.NextDouble() * 10);
                        break;
                    case 4:
                        arrIFigures[i] = new Ball(rand.NextDouble() * 10);
                        break;
                    default:
                        throw new Exception(); // никогда сюда не должно прийти - заглушка, надо ли такое писать?
                }
            }
 
            //Проверяем тип текущей фигуры и считаем "вручную", выводим результаты ручных подсчётов и подсчётов функцией экземпляра
            for (int i = 0; i < arrIFigures.Length; i++)
            {
                var currentIFigure = arrIFigures[i];
                double checkVolume = -1;

                if (currentIFigure is Parallelepiped)
                {
                    var tempF = currentIFigure as Parallelepiped; // Downcasting
                    checkVolume = tempF.X * tempF.Y * tempF.Z;
                }
                else if (currentIFigure is Pyramid)
                {
                    var tempF = (Pyramid)currentIFigure; // вариант преобразования
                    checkVolume = tempF.X * tempF.Y * tempF.H / 3;
                }
                else if (currentIFigure is Tetrahedron)
                {
                    var tempF = currentIFigure as Tetrahedron;
                    checkVolume = Math.Pow(tempF.A, 3) * Math.Sqrt(2) / 12;
                }
                else if (currentIFigure is Ball)
                {
                    var tempF = currentIFigure as Ball;
                    checkVolume = 4 * Math.PI * Math.Pow(tempF.R, 3) / 3;
                }
                else
                {
                    Console.WriteLine("Error1");
                }

                Console.WriteLine($"V = {currentIFigure.Volume:f2}\tCHECK: {checkVolume:f2}\t: {currentIFigure.Name}");
            }
        }
    }
}
