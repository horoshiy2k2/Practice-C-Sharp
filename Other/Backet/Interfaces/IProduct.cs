using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson11
{
    public interface IProduct
    {
        string Name { get; set; }

        decimal Cost { get; set; }
    }
}
