using Life.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    class FreelancePlatform
    {
        public List<Task> tasks = new List<Task>();

        public void AddRandomTasks(int count)
        {
            if (count == 0)
            {
                Console.WriteLine("No added tasks today\n");
                return;
            }

            Console.WriteLine("New tasks: ");

            for (int i = 0; i < count; i++)
            {
                var task = new Task();
                tasks.Add(task);
                Console.WriteLine(task);
            }
            
            Console.WriteLine();
            
        }
    }
}
