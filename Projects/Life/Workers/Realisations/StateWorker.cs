using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Realisations
{
    enum Positions
    {
        Junior,
        Middle,
        Senior
    }

    class StateWorker : BaseWorker
    {
        public string Company { get; set; }
        public Positions Position { get; set; }
        public double Salary { get; set; }
        // что-то особое для штатного

        public StateWorker(string name, int age, int cash, int skill, int softSkill) : base(name, age, cash, skill, softSkill)
        {
            Company = "Company" + r.Next(1, 4);
            //Company - отдельный класс, со списком из штатных сотрудников. Там можно нанимать и увольнять, в каждой компании разные ЗП и должности.
            Position = (Positions)r.Next(0, 3);
            Salary = (int)Position * 750 + 1000 + 10*(Skill + SoftSkill); // 1000$ + надбавка по 500 за ранг и по 10$ за софт и хардскиллы (среднее по нужным)
        }


        public override string ToString()
        {
            return base.ToString() + $"\t{Company}\t{Position}\t{Salary}$";
        }
    }
}
