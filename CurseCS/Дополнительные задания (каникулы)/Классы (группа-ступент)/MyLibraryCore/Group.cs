using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibraryCore
{
    public class Group
    {
        List<Student> _studentsList = new List<Student> { };

        // Конструктор. Принимает список объектов
        public Group(List<Student> students)
        {
            _studentsList.AddRange(students);
        }

        public void PrintMiddleScoreGroup()
        {
            Console.WriteLine("\nMiddleScores:\n");

            for (int i = 0; i < _studentsList.Count; i++)
            {
                var tempStudent = _studentsList[i];

                Console.WriteLine("Student {0}: {1:f2}", tempStudent.Name, tempStudent.MiddleScore);
            }
            
        }

        public void PrintScoresGroup()
        {
            Console.WriteLine("\nScores:\n");

            for (int i = 0; i < _studentsList.Count; i++)
            {
                var tempStudent = _studentsList[i];

                Console.Write("Student {0}: ", tempStudent.Name);
                tempStudent.PrintScores();
            }
        }
    }
}

//2. класс Группа
//Поля: список студентов
//Методы: вывести средний балл каждого студента, вывести оценки каждого студента
//можно метод, добавляющий студента - та ну