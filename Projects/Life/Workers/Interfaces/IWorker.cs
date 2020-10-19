using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Interfaces
{
    interface IWorker : IPerson
    {
        int Skill { get; set; } // какое-то представление скилла в числовом виде, максимальный скилл чему-то равен должен быть. Скилл можно прокачивать, утрачивать
    }
}

//Добавить безработного. Или оставить просто работает, но в компании безработный :D