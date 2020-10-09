using System;

namespace Z1
{
    abstract class Figure
    {
        public double Volume { get; set; } // эти свойства будут во всех наследуемых классах
        public string Name { get; set; } = "BaseName";

        // виртуальный метод - в наследниках override, чтобы изменить его
        public virtual void SetVolume()
        {
            Console.WriteLine("Базовая функция SetVoume");
        }


    }

    //parallelepiped, pyramid, tetrahedron, ball
    class Parallelepiped : Figure
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        private static int _count = 0; // Счётчик параллелепипедов - тест

        public Parallelepiped(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Name = "Parallelepiped" + ++_count; //счётчик параллелепипедов
            SetVolume();
        }

        public override void SetVolume()
        {
            Volume = X * Y * Z;
        }
    }

    class Pyramid : Figure
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double H { get; set; }
        private static int _count = 0; // Счётчик

        public Pyramid(double x, double y, double h)
        {
            X = x;
            Y = y;
            H = h;
            Name = "Pyramid" + ++_count;
            SetVolume();
        }

        public override void SetVolume()
        {
            Volume = X * Y * H / 3;
        }
    }

    class Tetrahedron : Figure
    {
        public double A { get; set; }
        private static int _count = 0; // Счётчик

        public Tetrahedron(double a)
        {
            A = a;
            Name = "Tetrahedron" + ++_count;
            SetVolume();
        }

        public override void SetVolume()
        {
            Volume = Math.Pow(A, 3) * Math.Sqrt(2) / 12;
        }
    }

    class Ball : Figure
    {
        public double R { get; set; }
        private static int _count = 0; // Счётчик

        public Ball(double r)
        {
            R = r;
            Name = "Ball" + ++_count;
            SetVolume();
        }

        public override void SetVolume()
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
            var arrFigures = new Figure[lengthArray];

            //генерируем массив фигур со случайными значениями
            for (int i = 0; i < arrFigures.Length; i++)
            {
                var randomNumber14 = rand.Next(1, 5); // 1 2 3 4 - случайную фигуру
                switch (randomNumber14)
                {
                    case 1: // Upcasting преобразование наследуемого класса к базовому Figure. Базовому классу не доступны поля, свойства, методы наследуемого
                        arrFigures[i] = new Parallelepiped(rand.NextDouble() * 10, rand.NextDouble() * 10, rand.NextDouble() * 10); // от 1 до 10
                        //почему-то тут не так. Экземпляру arrFigures[i] доступны свойства Name Volume и метод SetVolume
                        //Console.WriteLine(arrFigures[i].X); //- ошибка
                        //arrFigures[i].Name != "BaseName" . Потому что Name, Volume есть и в базовом классе,  с SetName() аналогично
                        // А вот X Y Z будет недоступно - эти свойства принадлежат Parallelepiped и не видны базовому классу при upкасте
                        break;
                    case 2:
                        arrFigures[i] = new Pyramid(rand.NextDouble() * 10, rand.NextDouble() * 10, rand.NextDouble() * 10);
                        break;
                    case 3:
                        arrFigures[i] = new Tetrahedron(rand.NextDouble() * 10);
                        break;
                    case 4:
                        arrFigures[i] = new Ball(rand.NextDouble() * 10);
                        break;
                    default:
                        throw new Exception(); // никогда сюда не должно прийти - заглушка, надо ли такое писать?
                }
            }

            //проверка правильности. Проверяем тип текущей фигуры и считаем "вручную", выводим результаты ручных подсчётов и подсчётов функцией экземпляра
            for (int i = 0; i < arrFigures.Length; i++)
            {
                var currentFigure = arrFigures[i];
                double checkVolume = -1;

                if (currentFigure is Parallelepiped)
                {
                    var tempF = currentFigure as Parallelepiped; // Downcasting
                    checkVolume = tempF.X * tempF.Y * tempF.Z;
                } 
                else if (currentFigure is Pyramid)
                {
                    var tempF = (Pyramid)currentFigure; // вариант преобразования
                    checkVolume = tempF.X * tempF.Y * tempF.H / 3;
                }
                else if (currentFigure is Tetrahedron)
                {
                    var tempF = currentFigure as Tetrahedron;
                    checkVolume = Math.Pow(tempF.A, 3) * Math.Sqrt(2) / 12 ;
                } 
                else if (currentFigure is Ball)
                {
                    var tempF = currentFigure as Ball;
                    checkVolume = 4 * Math.PI * Math.Pow(tempF.R, 3) / 3;
                }
                else
                {
                    Console.WriteLine("Error1");
                }

                Console.WriteLine($"V = {currentFigure.Volume:f2}\tCHECK: {checkVolume:f2}\t: {currentFigure.Name}");
            }
        }
    }
}
