using System;
using System.Collections.Generic;
using System.Text;

namespace z_9_1
{
    class Plane : Vehicle
    {
        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _countPassengers;
        
        public int CountPassengers
        {
            get { return _countPassengers; }
            set { _countPassengers = value; }
        }

        public override string ToString()
        {
            return $"{GetType().Name}:\n" + base.ToString() + $"Height: {Height}\tPassengers: {CountPassengers}\n";
        }

        public override bool Equals(object obj)
        {
            var plane = obj as Plane;
            if (plane != null) return Height == plane.Height;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
//Для класса Plane должна быть определена высота и количество пассажиров. (это доп поля в классе Plane)