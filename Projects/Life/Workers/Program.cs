using Life.Interfaces;
using Life.Realisations;
using System;
using System.Collections.Generic;

namespace Life
{
    delegate IWorker CreateWorker();

    enum Names
    {
        Vasya, Petya, Grisha, Igor, Masha, Dasha, Anton, Zhenya, Dima, Egor, Olya, Nastya
    }

    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            int countStateWorker = r.Next(1, 5);
            int countFreelanceWorker = r.Next(1, 5);
            CreateWorker createFW = CreateFreelanceWorker;
            CreateWorker createSW = CreateStateWorker;

            var freelanceWorkers = GenerateWorkers(countFreelanceWorker, createFW);
            var stateWorkers = GenerateWorkers(countStateWorker, createSW);

            Console.WriteLine("Фрилансеры");
            foreach (var worker in freelanceWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine("\nШтатные сотрудники");
            foreach (var worker in stateWorkers)
            {
                Console.WriteLine(worker);
            }

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

//Очень много всего, пока что лучше просто первые 3 пункта сделать

//Делать мини-задачки на одну и ту же тему, потом собрать их воедино
//В этих задачках использовать технологии и темы, которые прошёл. События и дженерики интересуют