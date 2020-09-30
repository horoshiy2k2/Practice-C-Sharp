using System;

namespace z5__2
{
    class Program
    {
        static void Main(string[] args)
        {
            // В двумерном массиве в каждой строке все элементы, расположенные после максимального, заменить на 0.
            var rand = new Random();
            int[,] arr = new int[rand.Next(5, 10), rand.Next(5, 10)];

            Console.WriteLine("Двумерный массив: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(1, 10);
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }


            ReplacingElements(arr);

            // вывод
            Console.WriteLine();
            Console.WriteLine("Элементы после максимального в строке равны 0: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                { 
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        public static void ReplacingElements(int[,] array)
        {
            int maxNum;
            int ind;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                ind = 0;
                maxNum = int.MinValue;

                for (int j = 0; j < array.GetLength(1); j++) // ищем макс элемент
                {
                    if (array[i, j] > maxNum) {
                        maxNum = array[i, j];
                        ind = j;
                    }
                }

                for (int j = ind + 1; j < array.GetLength(1); j++) // заменяем все элементы после максимального + вывод
                {
                    array[i, j] = 0;
                }
                
            }

        }
    }
}
