using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; } //День рождения :D ору)))) ГОДЫ ЖИВУТ365
        double Cash { get; set; }
        // уровень грамотности, репутиации, количество друзей, здоровье
    }
}
