using System;

namespace z3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var sum = 0;
            var mult = 1;
            foreach (var c in str)
            {
                if (Char.IsNumber(c) != true)
                {
                    Console.WriteLine("Вы ввели не число");
                    return;
                }
            }

            foreach (var c in str)
            {
                sum += c - 48; // 48 == '0' ASCI
                mult *= c - 48;
            }

            Console.WriteLine($"Сумма цифр числа: {sum}\nПроизведение цифр числа: {mult}");

            
        }
    }
}
