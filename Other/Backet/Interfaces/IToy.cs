using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    enum Material
    {
        Plastic,
        Metal,
        Wood
    }

    interface IToy
    {
        int AgeCategory { get; set; }
        Material MaterialToy { get; set; }
    }
}
