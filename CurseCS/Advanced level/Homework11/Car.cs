using System;
using System.Collections.Generic;
using System.Text;

namespace Homework11
{
    [Serializable]
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string Color { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{Make}\tModel: {Model}\t{ModelYear}\t{Cost}$";
        }
    }
}
