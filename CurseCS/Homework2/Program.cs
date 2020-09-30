using System;

namespace zad2_KharuzhyAnton
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;

            int n1 = 'a'; // чар  в инт
            long n2 = a + 1; // инт в лонг
            double n3 = a; // инт в дабл (наоборот нельзя, т.к. потеряем дробную часть)

            char m1 = (char)a; // инт в чар
            byte m2 = (byte)(a + n1); // инт в байт
            decimal m3 = (decimal)n3; // дабл в децимал

            object ob = a; // упаковка
            int num = (int)ob; // распаковка
        }
    }
}
