using Life.Realisations;
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
            var task = new Task();
            tasks.Add(task);
            Console.WriteLine($"New Task: {task}");
        }
    }
}
