using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    abstract class ProductBase : IProduct
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Cost}$";
        }
    }
}
