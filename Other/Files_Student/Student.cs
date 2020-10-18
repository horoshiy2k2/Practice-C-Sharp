using System;
using System.Collections.Generic;
using System.Text;

namespace Files_Students
{
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public int Math { get; set; }
        public int Phys { get; set; }
        public int Prog { get; set; }
        public bool IsScholarship { get; set; }

        private double _average;

        public double Average
        {
            get { return _average; }
            private set { _average = value; }
        }

        static double baseScholarship = 77.08;

        private double _scholarship;

        public double Scholarship
        {
            get { return _scholarship; }
            private set { _scholarship = value; }
        }

        public Student(string name, string group, int math, int phys, int prog, bool isScholarship)
        {
            Name = name;
            Group = group;
            Math = math; // можно словарь предмет - оценка
            Phys = phys;
            Prog = prog;
            IsScholarship = isScholarship;
            CalculateAverage();
            CalculateScholarship();
        }

        public void CalculateAverage()
        {
            Average = (Math + Phys + Prog) / 3.0; // если словарём, тогда тут нужно делить на количество предметов
        }

        public void CalculateScholarship()
        {
            switch ((int)Average)
            {
                case 5:
                    Scholarship = baseScholarship * 1;
                    break;
                case 6:
                    Scholarship = baseScholarship * 1.1;
                    break;
                case 7:
                    Scholarship = baseScholarship * 1.2;
                    break;
                case 8:
                    Scholarship = baseScholarship * 1.4;
                    break;
                case 9:
                case 10:
                    Scholarship = baseScholarship * 1.6;
                    break;
                default:
                    Scholarship = 0;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name}\t{Average:f2}\t{Scholarship:f2}р\n";
        }
    }
}
