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

        Task CurrentTask { get; set; }
        public int DaysWorked { get; set; }
        public override void Work(List<Task> tasks) // Завязка на таски Выбирает сам таск из предложенных (список тасков- где его хранить?)
        {
            if (CurrentTask == null)
            {
                CurrentTask = FindPassedTask(tasks);
            }

            //если уже работает над задачей
            //Можно прикрутить % отображатель того, насколько таск выполнен
            //Можно добавить случай, что заказчик кинул, 1%
            //
            if (CurrentTask != null)
            {
                //Работа измеряется во времени. Очень странно. хотя логично

                //Skill - (int)CurrentTask.Complexity
                //Прокидывать проверку, сколько сегодня выполнит работы
                // Снизу - выполниться за Столько дней, сколько написал.
                CurrentTask.Completed +=  100 / CurrentTask.DaysToComplete; // проверка на скилл. Если не успел, то проверку на софт скилл, типа попросить ???
                if (CurrentTask.IsDone) // 1 2 - выполнил таск; каждый день пытается
                {
                    var sallary = CurrentTask.Cost; // зависимость от скилла челика
                    Console.WriteLine($"Task \"{CurrentTask.Name}\" done!, {Name}\tget {sallary}$");
                    Cash += sallary;
                    CurrentTask = null;
                }
            }
            
        }

        private Task FindPassedTask(List<Task> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine($"На платформе не нашлось задач, {Name} сидит без дела");
                return null;
            }

            var passedTask = tasks[0];

            if (passedTask != null)
            {
                tasks.RemoveAt(0);
                return passedTask;
            }
            //логика подбора таска из списка (не просто брать первый попвшийся, а сверять с технологиями и скиллом) можно остортировать по приоритетности
            Console.WriteLine($"Подходящий таск не найден, {Name} сидит без дела");
            return null;
        }
    }
}

//ВЫХОДНОЙ ДОБАВИТЬ :) штатным тоже