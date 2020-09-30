using System;

namespace z3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов прогрессии");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите начало прогрессиии");
            int a1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите шаг прогрессиии");
            int d = int.Parse(Console.ReadLine());

            int an = a1 + d * (n - 1);

            var sum = n * (a1 + an) / 2;

            Console.WriteLine($"Сумма арифметической прогрессии: {sum}");
        }
    }

    
}
