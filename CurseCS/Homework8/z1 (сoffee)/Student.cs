using System;
using System.Collections.Generic;
using System.Text;

namespace Z8_1_coffee
{
    class Student
    {
        private static int _idStudent = 0;
        public string Name { get; set; }
        public int Age { get; set; }
        public bool TaskDone { get; set; } 
        public int CountCoffee { get; set; }

        public Student()
        {
            Name = "Student" + ++_idStudent;
            Age = 18;
            TaskDone = false;
            CountCoffee = 0;
        }
    }
}
