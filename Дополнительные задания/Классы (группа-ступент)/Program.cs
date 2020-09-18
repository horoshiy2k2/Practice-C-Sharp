using System;
using System.Collections.Generic;
using MyLibraryCore; // после добавления зависимости - ссылки на сборку (библиотека классов)

namespace DopClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList1 = new List<Student> { };

            //Создаём студентов (до 30) и добавляем в список
            var rand = new Random(); 
            for (int i = 0; i < rand.Next(5, 31); i++) 
            {
                var tempStudent = new Student("Name" + i); // рандомные оценки у всех
                studentList1.Add(tempStudent);
            }

            Group group1 = new Group(studentList1);

            group1.PrintScoresGroup();
            group1.PrintMiddleScoreGroup();
        }
    }
}

//Создать n студентов рандомно имя присвоить
//Добавить им оценки случайные
//Вызавать методы показать оценки и показать средний балл

//Реализовать в отдельной сборке
//1.класс Студент
//Поля: имя, фамилия, оценки(массив int)
//Методы: почитать средний балл, вывести оценки студента
//2. класс Группа
//Поля: список студентов
//Методы: вывести средний балл каждого студента, вывести оценки каждого студента