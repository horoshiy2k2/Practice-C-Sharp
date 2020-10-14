using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    class Gum : ProductBase, IGum
    {
        public int CountInPack { get; set; }
    }
}
