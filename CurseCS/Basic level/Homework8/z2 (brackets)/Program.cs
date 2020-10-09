using System;
using System.Collections.Generic;
using System.Linq;

namespace z8_2_brackets
{
    class Program
    {
        //Должна прийти открывающая последнего закрывающего
        
        static void Main(string[] args)
        {
            var str1 = "[({})]"; // Верно
            var str3 = "[(){}]"; // Верно 
            var str2 = "({[})]"; // Последовательность разная
            var str4 = "]{[}{}"; // Неверно последовательность
            var str5 = "([][])"; // Верно
       
            Console.WriteLine(CorrectOrderBrackets1(str1)); 
            Console.WriteLine(CorrectOrderBrackets1(str2)); 
            Console.WriteLine(CorrectOrderBrackets1(str3)); 
            Console.WriteLine(CorrectOrderBrackets1(str4)); 
            Console.WriteLine(CorrectOrderBrackets1(str5));

            // Генератор строк для проверки (на длину 4, чтобы были true, Т.к. очень много вариантов
            Console.WriteLine("\n\nRandom:");
            var rand = new Random();
            var count = rand.Next(50, 100);
            var arrBrackets = new char[]{ '(', '[', '{', ')', ']', '}' }; 
            var length = 4;
            string str;

            for (int i = 0; i < count; i++)
            {
                str = ""; 
                for (int j = 0; j < length; j++)
                {
                    str += arrBrackets[rand.Next(0, arrBrackets.Length)];
                }
                Console.WriteLine(CorrectOrderBrackets1(str));
            }
        }

        static bool CorrectOrderBrackets1(string str)
        {
            Console.Write($"\n{str}\t");
            Stack<char> openBrackets = new Stack<char>();
            var flag = true;
            var charArr = str.ToCharArray();
            var countOpenCircleBrackets = charArr.Where(c => c == '(').Count(); // количество открывающих круглых скобок
            var countOpenSquareBrackets = charArr.Where(c => c == '[').Count(); // количество открывающих квадратных скобок
            var countOpenFigureBrackets = charArr.Where(c => c == '{').Count(); // количество открывающих квадратных скобок
            var countCloseFigureBrackets = charArr.Where(c => c == '}').Count(); // количество закрывающих круглых скобок
            var countCloseCircleBrackets = charArr.Where(c => c == ')').Count(); // количество закрывающих круглых скобок
            var countCloseSquareBrackets = charArr.Where(c => c == ']').Count(); // количество закрывающих квадратных скобок

            // проверка на количество открытых и закрытых скобок
            if (str.Length % 2 != 0
                || countOpenCircleBrackets != countCloseCircleBrackets
                || countOpenSquareBrackets != countCloseSquareBrackets
                || countOpenFigureBrackets != countCloseFigureBrackets)
            {
                Console.Write("count mistake\t");
                return false;
            }


            var reflectedBrackets = new Dictionary<char, char>  // словарь ключ-значение 
            {
                ['('] = ')',
                ['['] = ']',
                ['{'] = '}',
            };

            // проверка правильной последовательности
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c == '(' || c == '[' || c == '{') //  всё через свич?
                {
                    openBrackets.Push(c);
                }
                else
                {
                    if (openBrackets.Count != 0) // (ПРОВЕРИТЬ НА ПУСТОЙ СТЭК(получил эксепшн на проверке рандомом на 100 значений О_о))
                    {
                        var openBracket = openBrackets.Pop(); // Достаём последнюю скобку открывающую 
                        if (reflectedBrackets[openBracket] != c) // Если закрывающаяя не подходит к открывающей
                        {
                            Console.Write($"{c} => {reflectedBrackets[openBracket]}\t");
                            return false;
                        }
                    } 
                    else
                    {
                        Console.Write($"Start with {c}\t"); // Последовательность скобок начинается с закрывающей 
                        return false;
                    }
                }
            }
            return flag;
        }

    }
}

// Создать метод, который проверяет правильную последовательность открывающихся и закрывающихся скобок.

// ({({[]})}) – правильная последовательность так как количество открытых скобок равна количеству закрытых 
// и все они находятся на правильных позициях

// ({(})) – не правильная последовательность хоть и количество открытых 
// равно количеству закрытых их последовательность не правильная.

// Последовательность может содержать следующие виды скобок ( { [