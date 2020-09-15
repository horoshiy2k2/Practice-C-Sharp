using System;

namespace Substring
{
    class Program
    {
        private static int SubstringDefault(string str, string substr)
        {
            return str.IndexOf(substr);
        }

        private static int SubstringMy(string str, string substr)
        {
            var ind = -1;
            var strLen = str.Length;
            var substrLen = substr.Length;
            var kolIterations = strLen - substrLen + 1; // +1 чтобы последний символ в строке дочитывало
            string tempstr;

            for (int i = 0; i < kolIterations; i++)
            {
                tempstr = str.Substring(i, substrLen);
                if (tempstr == substr)
                {
                    ind = i;
                    break;
                }
            }

            return ind;
        }

        static void Main(string[] args)
        {
            //Найти строку в подстроке. Вводится строка и искомая подстрока.Вернуть индекс начала
            //подстроки.

            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            Console.WriteLine("Введите искомую подстроку");
            string substr = Console.ReadLine();

            var ind1 = SubstringDefault(str, substr);
            Console.WriteLine(ind1 != -1 ? $"Индекс начала подстроки: {ind1}" : "Такой подстроки нет");
            var ind2 = SubstringMy(str, substr);
            Console.WriteLine(ind2 != -1 ? $"Индекс начала подстроки: {ind2}" : "Такой подстроки нет");
        }
    }
}
