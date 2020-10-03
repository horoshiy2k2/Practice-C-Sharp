using System;
using System.Collections.Generic;
using System.Text;

namespace Z8_1_coffee
{
    
    class CoffeeProgram 
    {
        private Queue<Student> _queneStudents = new Queue<Student>();
        private Stack<Student> _stackStudents = new Stack<Student>();

        public void ConfirmTask(Student student)
        {
            student.TaskDone = true;
            _queneStudents.Enqueue(student); // Добавили студента в очередь на получение кофе
            _stackStudents.Push(student);
        }


        public void GiveCoffee()
        {
            Console.WriteLine("Очередь: ");

            foreach (var student in _queneStudents)
            {

                Console.WriteLine($"{student.Name} получил кофе! Всего кофе получено: {++student.CountCoffee}");
                student.TaskDone = false; // получил кофе - иди работай дальше
            }

            Console.WriteLine("\nСтек: ");

            foreach (var student in _stackStudents)
            {
                Console.WriteLine($"{student.Name} получил кофе! Всего кофе получено: {student.CountCoffee}"); // счётчик кофе не увеличиваем - уже сделано в очереди
                student.TaskDone = false; 
            }


            _stackStudents.Clear(); // Всем выдали кофе - очередь пуста
            _queneStudents.Clear(); 
        }
    }
}