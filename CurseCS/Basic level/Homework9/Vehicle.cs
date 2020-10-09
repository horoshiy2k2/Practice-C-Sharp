using System;
using System.Collections.Generic;
using System.Text;

namespace z_9_1
{
    class Vehicle // abstract? // конструктор
    {
        private Coordinate _coordinate;

        public Coordinate Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }

        private int _cost;
        
        public int Cost {
            get { return _cost; }
            set { _cost = value; }
        }

        private double _speed;
        
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private int _year;
        
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public override string ToString()
        {
            return $"Coordinate: ({Coordinate.X}, {Coordinate.Y})\tSpeed: {Speed:f2}\tCost: {Cost}$\tYear: {Year}\t";
        }
    }

 

    struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
//Создать класс Vehicle.
//В теле класса создайте поля: координаты(это будет структура) и параметры средств передвижения (цена,
//скорость, год выпуска).
//Создайте 3 производных класса Plane, Саг и Ship.


//Написать программу, которая выводит на экран информацию о каждом средстве передвижения.
//Используйте переопределение ToString(). Переопределить метод Equals который будет своим для каждого
//класса.
//PS. Когда мы пишем obj1 == obj2 – вызывается Equals. Поставьте брекпоинт и посмотрите это.

//!!! Перед сдачей пройтись и коменты постирать