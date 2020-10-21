using Life.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Implementations
{
    abstract class BaseWorker : BasePerson, IWorker
    {
        
        public BaseWorker(string name, int age, int cash, int skill, int softSkill) : base(name, age, cash)
        {
            Skill = skill;
            SoftSkill = softSkill;
        }

        private double _skill;

        public double Skill
        {
            get { return _skill; }
            set { 
                if (value > 100)
                {
                    _skill = 100;
                }
                else
                {
                    _skill = value;
                }

            }
        }

        public double SoftSkill { get; set; } // просто харизма от 0 до 100
        
        public override string ToString()
        {
            return $"{Name}\t{Age} years\t{Cash}$\t{Skill}\t{SoftSkill}";
        }

        //заглушка. Нужно переопределять во всех наследниках
        public virtual void Work(List<Task> tasks) // Завязка на таски Выбирает сам таск из предложенных (список тасков- где его хранить?)
        {
            throw new Exception();
        }
    }
}
