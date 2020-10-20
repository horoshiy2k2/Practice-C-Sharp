using Life.Realisations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Interfaces
{
    interface IWorker : IPerson
    {
        double Skill { get; set; } // какое-то представление скилла в числовом виде, максимальный скилл чему-то равен должен быть. Скилл можно прокачивать, утрачивать
        double SoftSkill { get; set; }

        void Work(List<Task> tasks);
    }
}

//Добавить безработного. Или оставить просто работает, но в компании безработный :D