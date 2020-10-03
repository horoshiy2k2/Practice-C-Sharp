using System;
using System.Collections.Generic;
using System.Linq;

namespace Z8_1_coffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var countStudents = rand.Next(3, 6); // 3-5 студентов
            var listStudents = new List<Student>();
            var coffeeProgram1 = new CoffeeProgram(); 

            // Создаём список студентов
            Console.WriteLine("Список всех студентов: ");

            for (int i = 0; i < countStudents; i++)
            {
                listStudents.Add(new Student());
                Console.WriteLine(listStudents[i].Name);
            }


            // Рабочий день
            var countTask = rand.Next(2, 5); // Количество задач на рабочий день

            for (int i = 0; i < countTask; i++)
            {
                Console.WriteLine($"\nЗадача {i + 1}:");

                // Студенты выполняют работу
                foreach (var student in listStudents)
                {
                    bool done = rand.Next(0, 3) != 0; // 66% на успешное выполнение
                    if (done)
                    {
                        coffeeProgram1.ConfirmTask(student);
                    }
                }

                // Выдать кофе работягам!
                coffeeProgram1.GiveCoffee();
            }

            // Самых продуктивных студентов можно определить по количеству выпитого кофе!
            Console.WriteLine("\nРейтинг студентов: ");
            var sortedStudents = listStudents.OrderByDescending(student => student.CountCoffee); //Linq
            foreach (Student student in sortedStudents) Console.WriteLine($"{student.Name} получил {student.CountCoffee} кофе!");
        }
    }
}


// Создать класс студентов (обычные свойства Имя, Фамилия, Возраст и т.д.)
// Создать программу выдачи кофе студентам, приславшим задание на почту.
// Создать класс, который будет иметь два метода. 1-й отмечает, что студент отправил задание и добавляет
// его в коллекцию на выдачу кофе. 2-й метод выдает кофе на основании коллекции (тут просто вывести на экран
// какой студен получил кофе.
// Для организации списка использовать классы Stack и Queue.
// Обратить внимание в каком порядке студенты получат кофе при использовании этих классов.