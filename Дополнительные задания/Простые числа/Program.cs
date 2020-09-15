using System;

namespace Prime_number
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Ввести с клавиатуры число n большее 0.Вывести на экран все числа из диапазона от 0 до n,
            //которые являются простыми. Продемонстрировать использование операторов for, break, continue.
            //Изменить программу -вместо цикла for использовать цикл while.

            var n = int.Parse(Console.ReadLine());
            int kolDel;

            for (int i = 2; i <= n; i++)
            {
                kolDel = 2;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0) kolDel++;
                    if (kolDel > 2) break;
                }

                if (kolDel == 2) Console.Write($"{i} ");
            }


            var num = 1;
            int k;
            Console.WriteLine();
            while (++num < n)
            {

                kolDel = 2;
                k = 2;

                while (k <= Math.Sqrt(num))
                {
                    if (num % k++ == 0)
                    {
                        kolDel++;
                        break;
                    }                    
                }

                if (kolDel == 2) Console.Write("{0} ", num);
            }
        }
    }
}
