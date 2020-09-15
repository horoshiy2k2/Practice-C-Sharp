using System;

namespace Последовательность_единиц
{
    class Program
    {
        static void Main(string[] args)
        {
            //Для заданного двоичного массива найдите максимальное количество последовательных единиц в
            //этом массиве.
            //Input:[1,1,0,1,1,1]
            //Output: 3
            
            Random rand = new Random();

            var arr = new int[rand.Next(5, 25)];
            var kol = 0;
            var maxKol = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, 2); // генерация массива
                Console.Write(arr[i] + " ");

                if (arr[i] == 1) kol++;
                else 
                {
                    if (kol > maxKol) maxKol = kol;
                    kol = 0;
                }                
            }

            Console.WriteLine($"\nМаксимальное количество последовательных единиц в массиве: {maxKol}");
        }
    }
}
