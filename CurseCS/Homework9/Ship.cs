using System;
using System.Collections.Generic;
using System.Text;

namespace z_9_1
{
    class Ship : Vehicle
    {
        private int _countPassengers;
        
        public int CountPassengers
        {
            get { return _countPassengers; }
            set { _countPassengers = value; }
        }

        private string _namePort;

        public string NamePort
        {
            get { return _namePort; }
            set { _namePort = value; }
        }

        public override string ToString()
        {
            return $"{GetType().Name}:\n" + base.ToString() + $"Port: {NamePort}\tPassengers: {CountPassengers}\n";
        }

        public override bool Equals(object obj)
        {
            var ship = obj as Ship;
            if (ship != null) return NamePort == ship.NamePort;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
//Для класса Ship — количество пассажиров и порт приписки. (доп поля в классе Ship)