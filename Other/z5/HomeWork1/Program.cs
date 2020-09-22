using System;

namespace z5__1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, разделённую пробелами");
            var str = Console.ReadLine();


            LongestWordInString1(str);

            LongestWordInString2(str);

        }

        public static void LongestWordInString2(string str)
        {
            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var maxWord = "";
            foreach (var word in words)
            {
                if (word.Length > maxWord.Length)
                {
                    maxWord = word;
                }
            }

            Console.WriteLine(maxWord);

        }
    
        public static void LongestWordInString1(string str)
        {
            str += " ";
            int len = 0;
            int maxLen = -1;
            string slovo = "";
            string maxSlovo = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    if (maxLen < len)
                    {

                        maxLen = len;
                        len = 0;
                        maxSlovo = slovo;
                        slovo = "";
                    }
                } else
                {
                    slovo += str[i];
                    len++;
                }
            }

            Console.WriteLine(maxSlovo);
        }
    }


        // Самое длинное слово в строке и количество слов в строке
        // Вводится строка слов, разделенных пробелами.
        // Найти самое длинное слово и вывести его на экран.
        // Случай, когда самых длинных слов может быть несколько, не обрабатывать.

    
}
