using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        int Cash { get; set; }
        // уровень грамотности, репутиации, количество друзей, здоровье
    }
}
