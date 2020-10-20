using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    abstract class BasePerson : IPerson
    {
        public static Random r = new Random();

        public string Name { get; set; }
        public int Age { get; set; }
        public int Cash { get; set; }

        protected BasePerson(string name, int age, int cash)
        {
            Name = name;
            Age = age;
            Cash = cash;
        }
    }
}
