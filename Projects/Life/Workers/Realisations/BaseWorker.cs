using Life.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Realisations
{
    abstract class BaseWorker : BasePerson, IWorker
    {

        public BaseWorker(string name, int age, int cash, int skill, int softSkill) : base(name, age, cash)
        {
            Skill = skill;
            SoftSkill = softSkill;
        }

        public int Skill { get; set; } // можно словарь с разными технологиями и интом
        public int SoftSkill { get; set; } // просто харизма от 0 до 100
        public override string ToString()
        {
            return $"{Name}\t{Age} years\t{Cash}$\t{Skill}\t{SoftSkill}";
        }
    }
}
