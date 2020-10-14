using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    enum Colors
    {
        Red,
        Blue,
        Yellow,
        Pink,
        Gray
    }

    interface IJeans
    {
        Colors Color { get; set; }

        string Made { get; set; }
    }
}
