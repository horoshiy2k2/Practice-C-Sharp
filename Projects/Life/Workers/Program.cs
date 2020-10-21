using Life.Interfaces;
using Life.Implementations;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Life
{
    delegate IWorker CreateWorker();

    enum Names
    {
        Vasya, Petya, Grisha, Igor, Masha, Dasha, Anton, Zhenya, Dima, Egor, Olya, Nastya
    }

    class Program
    {
        // В ЦВЕТА РАЗУКРАСИТЬ
        public static readonly Random r = new Random();
        public static int day = 0;

        static void Main(string[] args)
        {
           

            // генерация рабочих
            int countStateWorker = r.Next(1, 5);
            int countFreelanceWorker = r.Next(1, 5);
            CreateWorker createFW = CreateFreelanceWorker;
            CreateWorker createSW = CreateStateWorker;

            var freelanceWorkers = GenerateWorkers(countFreelanceWorker, createFW);
            var stateWorkers = GenerateWorkers(countStateWorker, createSW);

            ShowWorkers(freelanceWorkers);
            ShowWorkers(stateWorkers); 

            //Работа
            Console.WriteLine("\n\nОСТОРОЖНО, РАБОТА ФРИЛАНСЕРОВ");
            

             //Просто 1 цикл = 1 день
            var flru = new FreelancePlatform();
            Action newDay = NewDay;
            //генератор случайный задач? У них должно быть имя?

            while (true)
            {
                newDay();
                
                //СОбытие нового дня - пипец. Рассылка для всех тасков. Они обрабатывают, какой день сейчас и делают что-либо. Переговоры с наймитами

                var countTasks = r.Next(0, 2);
                flru.AddRandomTasks(countTasks);

                //работа фрилансеров
                //Какие-то фрилансеры оказываются проворнее и лучше, забирают все таски. Это из-за того, что количество дней на решение не приписано ещё.
                foreach (var worker in freelanceWorkers)
                {
                    
                    worker.Work(flru.tasks); // запись о том, хватило ли ему тасков или сидит без дела
                }

                Console.WriteLine();
                //Работа КОМПАНИИ В ЦЕЛОМ, а не штатных по отдельности

                Thread.Sleep(500);
            }

        }


        static void ShowWorkers(List<IWorker> workers)
        {
            Console.WriteLine(workers[0].GetType().Name);
            foreach (var worker in workers)
            {
                Console.WriteLine(worker);
            }
        }

        static void NewDay()
        {
            day++;
            Console.ForegroundColor = (ConsoleColor)r.Next(1, 15);
            

            Console.WriteLine($"Day {day}");
        }

        static List<IWorker> GenerateWorkers(int count, CreateWorker createWorker)
        {
            var workers = new List<IWorker>();
            for (int i = 0; i < count; i++)
            {
                workers.Add(createWorker()); // делегирует создание работника делегату createWorker
            }

            return workers;

        }

        static IWorker CreateFreelanceWorker()
        {
            return new FreelanceWorker(((Names)r.Next(0, 12)).ToString(), r.Next(18, 50), r.Next(0, 15) * 1000, r.Next(0, 101), r.Next(0, 101));
        }

        static IWorker CreateStateWorker()
        {
            return new StateWorker(((Names)r.Next(0, 12)).ToString(), r.Next(18, 50), r.Next(0, 15) * 1000, r.Next(0, 101), r.Next(0, 101));
        }

    }
}

//Насоздавать людей, которые ходят на работу. И фрилансеров, которые сидят дома.

//Фрилансеры получают случайный кэш (но зависящий от времени потраченного и скилла программера), когда выполнят таск. 

//А в штате челы получают стабильно зп только в зависимости от скилла (но нужно ещё и повышение, должность, тимлид, мидл, джуниор)
//Возможно, методы, чтобы устроиться на работу фрилансером и в штат (фрилансером получится в любом случае, а в штат нужно пройти несколько собеседований)
//Есть несколько компаний, которые принимают работников в свой штат, в них есть иерархия работников
//Есть клиенты, которые хотят, чтобы их таски выполнили, могут обратиться как на фриланс (смотрят, кто там свободен, можно по языку проги, стеку технологий "запрос")
//Каждый фрилансер и вообще прогер будет владеть своим стеком технологий, компании подбирают по стеку технологий лучшего
//Компании могут увольнять сотрудника, или сотрудники могут сами уволиться. Тогда компания начинает поиски нового, а уволившийся тоже ищет работу, но в другой компании
//Компания - отдельный класс со списком работников

//Очень много всего, пока что лучше просто первые 3 пункта сделать

//Делать мини-задачки на одну и ту же тему, потом собрать их воедино
//В этих задачках использовать технологии и темы, которые прошёл. События и дженерики интересуют