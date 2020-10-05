using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            var products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                var product = new Product()
                {
                    Name = "Продукт" + i,
                    Energy = rand.Next(10, 12)
                };
                products.Add(product);
            }


            var result1 = from item in products
                          where item.Energy < 250 // where возвращает коллекцию (даже пустую)
                          select item; 


            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            var result2 = products.Where(item => item.Energy < 250 || item.Energy > 400).OrderByDescending(item => item.Energy);
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Select
            var selectColletion = products.Select(product => product.Energy);
            foreach (var item in selectColletion)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // OrderBy
            var orderbyCollection = products.OrderBy(product => product.Energy).ThenByDescending(product => product.Name);
            foreach (var item in orderbyCollection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // GroupBy группирует в пары ключ - список элементов
            var groupbyCollection = products.GroupBy(product => product.Energy);
            foreach (var group in groupbyCollection) // словарь ключ-значение(значение = список)
            {
                //Dictionary<int, List<Product>>
                Console.WriteLine($"Ключ: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Reverse
            products.Reverse();
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // All (если все тру, то тру)  Any (если хотя бы 1 возвращает тру, то тру) - bool
            Console.WriteLine(products.All(item => item.Energy == 10));
            Console.WriteLine(products.Any(item => item.Energy == 10));
            Console.WriteLine();

            // Contains (входит ли элемент в коллекцию)
            var prod = new Product();
            Console.WriteLine(products.Contains(products[5]));
            Console.WriteLine(products.Contains(prod));

            // Операции со множествами
            // Union объединение 2ух множеств (по умолчанию с уникальными элементами)
            var arr = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 3, 4, 5, 6 };
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var union = arr.Union(arr2); // по умолчанию без дубликатов объединяет
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Intersect - пересечение. То, что есть в первом и во втором
            var intersect = arr.Intersect(arr2);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Except - вычитание (есть в первом, но нет во втором)
            var except = arr2.Except(arr); // вычли общие элементы
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Агрегатные функции сум мин макс
            var sum = arr.Sum();
            var min = products.Min(p => p.Energy); 
            var max = products.Max(p => p.Energy);
            var aggregate = arr.Aggregate((x, y) => x * y); // результирующее и следующее
            Console.WriteLine("aggregate mult arr = {0}", aggregate);

            var sum2 = arr.Skip(1).Take(2).Sum(); // пропустить n элементов коллекции, взять k элементов с начала
            Console.WriteLine("Сумма 2го- и 3го arr2: {0}", sum2);


            // Операции выбора
            // Взять 1 элемент из коллекции
            var first = products.First(product => product.Energy == 10); // первый продукт с енергией == 10. первый элемент или эксепшн, если пустая коллекция
            var last = products.LastOrDefault(); // последний элемент или эквивалентный, если пустая
            var single = products.Single(product => product.Energy == 10); // берём ЕДИНСТВЕННЫЙ элемент с энергией 10. Иначе эксепшн
            var elementAt = products.ElementAt(5); // получить элемент по ОЧЕРЕДИ, т.е. с 1 начало, не с 0

            // Distinct позволяет создать коллекцию УНИКАЛЬНЫХ элементов (хэшсет?) вызывает метод Equaile проверка по ссылке

        }
    }
}
