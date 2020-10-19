using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Realisations
{
    class FreelanceWorker : BaseWorker
    {
        public int Reputation { get; set; } // репутация фрилансера. Невыполнил таск в срок - в минус, выполнил - в плюс. Шанс и время выполнения от скилла зависит

        public FreelanceWorker(string name, int age, int cash, int skill, int softSkill) : base(name, age, cash, skill, softSkill)
        {
            Reputation = 0; // по-другому сделать
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{Reputation}rep";
        }
        // что-то особое для фрилансера
    }
}
