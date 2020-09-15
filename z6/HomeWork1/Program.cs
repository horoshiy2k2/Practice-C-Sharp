using System;
using System.Reflection.Metadata.Ecma335;

namespace z6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать класс с именем Rectangle.
            // В теле класса создать два поля, описывающие длины сторон double side1, side2.   
            // Создать пользовательский конструктор Rectangle(double side1, double side2), в теле которого поля side1 и side2 инициализируются значениями аргументов.
            // Создать два метода, вычисляющие площадь прямоугольника - double AreaCalculator() и периметр прямоугольника - double PerimeterCalculator().  
            // Создать два свойства double Area и double Perimeter с одним методом доступа get.
            // Написать программу, которая принимает от пользователя длины двух сторон прямоугольника и выводит на экран периметр и площадь.
            Console.WriteLine("Введите сторону 1 прямоугольника: ");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите сторону 2 прямоугольника: ");
            var b = double.Parse(Console.ReadLine());

            var rect1 = new Rectangle(a, b);

            Console.WriteLine($"Площадь: {rect1.Area} Периметр: {rect1.Perimeter}");
        }
    }
    
    class Rectangle
    {
        private double _side1, _side2;

        public Rectangle(double side1, double side2)
        {
            _side1 = side1;
            _side2 = side2;
            Area = AreaCalculator();
            Perimeter = PerimeterCalculator();
        }

        public double Area { get; private set; }
        public double Perimeter { get; private set; }

        private double AreaCalculator()
        {
            return _side1 * _side2;
        }

        private double PerimeterCalculator()
        {
            return (_side1 + _side2) * 2;
        }
    }

    

}
