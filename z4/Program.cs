using System;

namespace z4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Рассчитать выплаты по кредиту
            // Рассчитать месячные выплаты(m) и суммарную выплату(s) по кредиту.
            // О кредите известно, что он составляет N рублей, берется на Y лет, под P процентов.
            // Процент на остаток суммы долга
            // Сумма кредита(руб.) : 1000000
            // Период(количество лет) : 20
            // Процент: 15
            // Ежемесячные выплаты: 13313 руб.
            // Всего будет выплачено: 3195230 руб.
            Console.WriteLine("Введите сумму кредита");
            double N = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество лет для выплаты кредита");
            var Y = int.Parse(Console.ReadLine());

            double P = 15.0 / 100;
            double m = N * P * Math.Pow((1 + P), Y) / (12 * (Math.Pow((1 + P), Y) - 1));

            Console.WriteLine($"Ежемесячные выплаты : {m:0}");
            Console.WriteLine($"Всего будет выплачено: {m * 12 * Y + 0.5:0}");
        }
    }
}