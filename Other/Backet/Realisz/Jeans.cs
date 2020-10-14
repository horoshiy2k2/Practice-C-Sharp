using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    class Jeans : ProductBase, IJeans
    {
        public Colors Color { get; set; }
        public string Made { get; set; }
    }
}
