using System;
using System.Collections.Generic;
using System.Text;

namespace z_9_1
{
    enum Brands {
        Porsche,
        Nissan,
        Audi
    }

    class Car : Vehicle
    {
        private int _countWheel;

        public int CountWheel
        {
            get { return _countWheel; }
            set { _countWheel = value; }
        }

        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public override string ToString()
        {
            return $"{GetType().Name}:\n" + base.ToString() + $"Wheel: {CountWheel}\tBrand: {Brand}\n";
        }

        public override bool Equals(object obj)
        {
            var car = obj as Car;
            if (car != null) return Brand == car.Brand;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
