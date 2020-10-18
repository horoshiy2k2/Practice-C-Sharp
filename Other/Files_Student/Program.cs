using System;
using System.Collections.Generic;
using System.IO;

namespace Files_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();

            // чтение из файла
            // отдельный метод сделать
            var path = @"D:\CS\Students Results\Results.txt";
            using (FileStream fstream = File.OpenRead(path)) // а если такого пути не существует?
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array); // из байтового представления сделали строковое

                var lines = textFromFile.Split('\n'); // по строкам разбил

                var studentsInfo = new List<string>();
                foreach (var line in lines)
                {
                    var data = line.Split('\t');
                    students.Add(new Student(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), data[5][0] == 'b'));
                }
                Console.WriteLine($"Файл \"{path}\" прочитан") ;
            }

            var text = "";
            foreach (var student in students)
            {
                text += student.ToString();
            }

            var pathResults = @"D:\CS\Students Results\Scholarship.txt";
            using (FileStream fstream = File.OpenWrite(pathResults))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine($"Результаты записаны в файл \"{pathResults}\"");
            }

            Console.ReadLine();


        }
    }
}
