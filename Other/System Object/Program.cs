using System;

namespace SystemObject
{
    class Program // : System.Object -  неявно
    {
        static void Main(string[] args)
        {
            //дз: переопределить ToString, Equals, GetHashCode
            // Поработать с остальными методами на практике
            // Создать клон объекта. В своей предметной области.
            object obj = new object();
            int i = 5;
            int j = 5;
            Console.WriteLine(i.Equals(j)); // по значению

            object oi = i;
            var oj = (object)j;
            Console.WriteLine(oi.Equals(oj)); // по ссылкам, но - приведение тру тру
            Console.WriteLine();

            var p1 = new Point() { X = 5 };
            var p2 = new Point() { X = 5 };
            Console.WriteLine(p1.Equals(p2)); // по ссылкам // переопределили - по значениям
            Console.WriteLine();

            Console.WriteLine(i.GetHashCode());
            Console.WriteLine(oj.GetHashCode());
            Console.WriteLine(new MyClass().GetHashCode());
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine();

            //Console.WriteLine(null == null); // true
            //Console.WriteLine();

            Console.WriteLine(i.ToString()); // значимый к строке
            Console.WriteLine(p1.ToString()); // ссылочный к строке
            Console.WriteLine();

            //GetType(instance) - невозможно переопределить
            Console.WriteLine(i.GetType());
            Console.WriteLine(oi.GetType()); // Int32 понимает, хотя запакованно в object
            Console.WriteLine(p1.GetType()); //  переопределили с помощью new (небезопасно)
            Console.WriteLine();

            //typeof(ClassName)
            Console.WriteLine(typeof(Point));
            Console.WriteLine(typeof(Point) == p1.GetType());
            Console.WriteLine();

            Console.WriteLine(Object.Equals(5, 5));
            Console.WriteLine(Object.ReferenceEquals(5, 5)); // происходит упаковка, разные участки памяти (ячейки стека) -> false
            Console.WriteLine(Object.ReferenceEquals(p2, p2)); // true
            Console.WriteLine();

            var pp = new Point() { X = 7, Y = new Point() };
            var pp2 = pp; // объект один, а псевдонима 2. 1 участок памяти, с клонированием будет 2 объекта
            pp2.X = 77;
            pp2.Y = new Point() { X = 99 };
            
            var pp3 = pp.Clone();
            pp3.X = 88;
            pp3.Y.X = 100;
            Console.WriteLine("pp: {0} {1}", pp.Y, pp.X);
            Console.WriteLine("pp2: {0} {1}", pp2.Y, pp2.X);
            Console.WriteLine("pp3: {0} {1}", pp3.Y, pp3.X);
        }
    }
}
