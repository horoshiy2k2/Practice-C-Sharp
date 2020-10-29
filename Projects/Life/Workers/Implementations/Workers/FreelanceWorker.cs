using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Implementations
{
    [Serializable]
    class FreelanceWorker : BaseWorker
    {
        public int Reputation { get; set; }
        // количество выполненных тасков разной сложности
        public FreelanceWorker()
        {

        }

        public FreelanceWorker(string name, int age, int cash, int skill, int softSkill) : base(name, age, cash, skill, softSkill)
        {
            Reputation = 0; // по-другому сделать? // от репы зависит, захочет ли заказчик работать с ним
        }

        

        public override string ToString()
        {
            return base.ToString() + $"\t{Reputation} rep";
        }

        Task CurrentTask { get; set; }
        public int DaysWorked { get; set; }

        public override void Work(List<Task> tasks)
        {
            if (CurrentTask == null)
            {
                CurrentTask = FindPassedTask(tasks);

                //Нашёл подходящую задачу
                if (CurrentTask != null)
                {
                    CurrentTask.DayStarted = Program.day; // !!Можно сделать так, чтобы задача удалялась после 7 дней, если её никто не брал.
                }


            }
            
            // Уже работает над задачей
            if (CurrentTask != null)
            {
                // проверка на скилл
                var completed = 100.0 / CurrentTask.DaysToComplete; // базовая скорость (1.0 чтобы выполнить 100% в срок)

                switch (CurrentTask.Complexity)
                {
                    case ComplexityLevels.easy:
                        completed += completed * (Skill / 100) * (Skill >= 20 ? 1: -1 ); // (100 / Skill) = 1 при скилле 100. То есть х2 скорость
                        break;
                    case ComplexityLevels.medium:
                        completed += completed * (Skill / 100) * (Skill >= 50 ? 1 : -1);
                        break;
                    case ComplexityLevels.hard:
                        completed += completed * (Skill / 100) * (Skill >= 80 ? 1 : -1);
                        break;
                    default:
                        throw new Exception("Switch Exception Enum ComplexityLevels");
                }


                CurrentTask.Completed += Math.Abs(completed); // костыль, но не может работа быть отрицательной...
                //Console.WriteLine($"{Name} выполнил {CurrentTask.Completed:f2}% {CurrentTask.Name}, осталось {CurrentTask.DaysLeft}"); // отладка

                // Если софт скиллы развиты, то можно уговорить работодателя о большем сроке опоздания, без срыва его. 
                if (CurrentTask.DaysLeft < r.Next(-14 - (int)SoftSkill / 10, 0))
                {
                    Reputation -= r.Next(1, 4); // 0 - не отразилось на репутации, например, ответил на его коммент круто
                    Skill += r.Next(0, 2); // минимум скилла добавляется
                    Console.WriteLine($"{Name} просрочил заказ \"{CurrentTask.Name}\" на {-1*CurrentTask.DaysLeft} дней, заказчик забрал работу и смылся с деньгами, оставив плохой отзыв " +
                        $"Репутация: {Reputation} rep {Skill} skillPoint");
                    CurrentTask = null;
                    return;
                }

                // Выполнил задачу
                if (CurrentTask.IsDone)
                {
                    var sallary = CurrentTask.Cost;
                    var lateForDays = CurrentTask.LateFor;
                    Reputation += r.Next(0, 3); // где-то нужны проверки на репу. Плюс можно в зависимости от сложности задачи репу увеличивать по-разному
                    Skill += r.Next(0, 4); // аналогично. От сложности задачи зависит увеличение скилла. Максимум 100
                    var endSallry = sallary * (1 - lateForDays / 100.0); // уменьшение зарплаты на столько процентов, на сколько просрочил заказ. На > 100 дней = 0

                    //Свич? Отдельный метод?, если успел, то бонус за скорость от заказчика.
                    if (lateForDays < 0)
                    {
                        Console.WriteLine($"Заказ \"{CurrentTask.Name}\" выполнен!, {Name} получил {endSallry:f2}$" +
                        $"\tУспел раньше на {-1 * CurrentTask.LateFor} дней\tБонус за скорость: {endSallry - sallary:f2}$ " +
                        $" {Reputation} rep {Skill} skillPoint");
                    }
                    else if (lateForDays > 0)
                    {
                        Console.WriteLine($"Заказ \"{CurrentTask.Name}\" выполнен!, {Name} получил {endSallry:f2}$" +
                        $"\tОпоздал на {CurrentTask.LateFor} дней\tШтраф за скорость: {sallary - endSallry:f2}$" +
                        $" {Reputation} rep {Skill} skillPoint");
                    }
                    else
                    {
                        Console.WriteLine($"Заказ \"{CurrentTask.Name}\" выполнен!, {Name}\tполучил {endSallry:f2}$" +
                        $"\t Задача выполнена в срок!" +
                        $" {Reputation} rep {Skill} skillPoint");
                    }


                    Cash += endSallry;
                    CurrentTask = null;
                }

                    
            }
            
        }

        //Они берут самый старый таск на бирже - стоит ли. Лучше сделать по скиллу поиск, по приоритетам. Список приоритетных или ищет первый приоритетный
        //Со слабым скиллом ищут более лёгкие задачи, не лезут на сеньёров
        //Берут только свою технологию
        //Проверка на репутацию - заказчик не захочет доверять сложный проект челику с плохой или нулёвой репой
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
                tasks.RemoveAt(0); //  пока что они не выбирают, а просто берут первый попавшийся.
                Console.WriteLine($"{Name} взял Task \"{passedTask.Name}\"");
                return passedTask;
            }
            //логика подбора таска из списка (не просто брать первый попвшийся, а сверять с технологиями и скиллом) можно остортировать по приоритетности
            Console.WriteLine($"Подходящий таск не найден, {Name} сидит без дела");
            return null;
        }
    }
}

//ВЫХОДНОЙ ДОБАВИТЬ :) штатным тоже