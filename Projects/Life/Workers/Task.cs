using System;
using System.Collections.Generic;
using System.Text;

namespace Life.Realisations
{
    enum Technologies
    {
        Web,
        SoftwarePC,
        SofwareMobile,
        GameDevPC,
        GameDevMobile
    }

    enum ComplexityLevels
    {
        easy, // Могут осилить со скиллом 100 / 1
        medium,
        hard
    }

    class Task
    {
        public static Random r = new Random();
        public static int CountTasks { get; set; } = 0;
        
        private int _id;

        public Technologies Technology { get; set; }
        public int Cost { get; set; }
        public int DaysToComplete { get; set; }
        public int DayStarted { get; set; } // &&
        public int DayEnded{ get; set; } // &&
        public string Name { get; set; }
        public ComplexityLevels Complexity { get; set; }
        public bool IsDone { get; private set; }


        private double _completed;

        public double Completed
        {
            get { return _completed; }
            set { 
                
                _completed = value; 
                if (_completed >= 100 && IsDone == false)
                {
                    IsDone = true;
                }
            }
        }




        
        //сложность
        //количество дней на выполнение (стандартная величина, которую модифицируют рабочие)
        //время старта таска (можно у рабочего, лучше у рабочего)
        //Более сложные задания оплачиваются дороже, их забирают опытные (СКИЛЛОВЫЕ)
        public Task()
        {
            CountTasks++;
            _id = CountTasks;
            Name = ((Technologies)r.Next(0, 5)).ToString() + CountTasks;
            IsDone = false;
            Complexity = (ComplexityLevels)r.Next(0, 3);
            DaysToComplete = (int)Complexity * 5 + r.Next(1, 5);
            Cost = (int)Complexity * 250 + DaysToComplete * 50; // можно надбавку за скорость замутить фрилансеру)) А если просрочит, тогда резать ЗП
        }
        //0.05 % что заказчику надоест ждать
        //DateTime/TimeSpan DeadLine 
        // isDone  
        // Type (freelance/state) 
        // Фрилансеры с самым большим рейтингом возьмут заказ (но тоже есть %, что возьмут. Им может он не понравится)

        // какая-то фриланс биржа, содержащая список тасков и метод, по обновлению их. Или просто статический какой-то метод, который дополняет список в мэйне.
        // Лучше первый вариант, там можно много чего наворотить

        public override string ToString()
        {
            return $"{CountTasks}) {Name}:\tCost:{Cost}\t{Complexity}\t{DaysToComplete} days\t";
        }

    }
}
