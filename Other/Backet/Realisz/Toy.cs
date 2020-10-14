using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    class Toy : ProductBase, IToy
    {
        public int AgeCategory { get; set; }
        public Material MaterialToy { get; set; }
    }
}
