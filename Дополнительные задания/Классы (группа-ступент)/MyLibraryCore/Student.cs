using System;
using System.Linq;

namespace MyLibraryCore
{
    public class Student
    {
        // Обычный конструктор
        public Student(string name, int[] scores)
        {
            _name = name;
            _scores = scores;
            CalculateAverageScore();
        }

        // Случайные оценки студента с именем name
        public Student(string name) 
        {
            var rand = new Random();
            _name = name;
            _scores = new int[rand.Next(1, 11)]; // 1-10 оценок

            for (int i = 0; i < _scores.Length; i++)
            {
                _scores[i] = rand.Next(0, 11);
            }

            CalculateAverageScore();
        }

        private string _name; // в данном случае можно было обойтись автосвойством {get; private set}

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        private int[] _scores;

        public double MiddleScore { get; private set; }

        public void CalculateAverageScore()
        {
            MiddleScore = (double)_scores.Sum() / _scores.Length;// проверить, как считает
        }

        public void PrintScores()
        {
            foreach (var score in _scores)
            {
                Console.Write(score + " ");
            }
            Console.WriteLine();
        }

    }
}
//Реализовать в отдельной сборке
//1.класс Студент
//Поля: имя, фамилия, оценки(массив int)
//Методы: почитать средний балл, вывести оценки студента
