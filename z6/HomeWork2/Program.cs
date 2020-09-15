using System;
using System.Collections.Generic;

namespace z6__2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать класс Book.Создать классы  Title, Author и Content, каждый из которых должен содержать одно строковое поле и метод void Show().  
            // Реализуйте возможность добавления в книгу названия книги, имени автора и содержания.
            // Выведите на экран разными цветами при помощи метода Show() название книги, имя автора и содержание.
            // Как вывести разными цветами на консоль - загуглите!

            var book1 = new Book();
            book1.SetTitle("Старик и море");
            book1.SetAuthor("Эрнест Хемингуэй");
            book1.SetContent("контент1");

            book1.Show();

            var book2 = new Book();
            book2.SetTitle("Мёртвые души");
            book2.SetAuthor("Николай Гоголь");
            book2.SetContent("контент2");

            book2.Show();


            //возможность добавлять новые книги
            bool flag;
            List<Book> listBooks = new List<Book>() { book1, book2 }; // библиотека

            do
            {
                Book tempBook = new Book();
                Console.WriteLine("\nВведите название книги: ");
                tempBook.SetTitle(Console.ReadLine());

                Console.WriteLine("\nВведите автора книги: ");
                tempBook.SetAuthor(Console.ReadLine());

                Console.WriteLine("\nВведите содержание книги: ");
                tempBook.SetContent(Console.ReadLine());


                listBooks.Add(tempBook);
                Console.WriteLine("Добавить новую книгу? 1 - да, 0 - нет");
                flag = Console.ReadLine() == "1";
            } while (flag);


            Console.WriteLine("Все книги в библиотеке: \n");
            int k = 0;
            foreach (var book in listBooks)
            {
                Console.WriteLine($"Книга №{k++}");
                book.Show();
            }
        }
    }

    class Book
    {
        private Title _titleOfThisBook = new Title();
        private Author _authorOfThisBook = new Author();
        private Content _contentOfThisBook = new Content();

        public void SetTitle(string str)
        {
            _titleOfThisBook.TitleOfBook = str;
        }

        public void SetAuthor(string str)
        {
            _authorOfThisBook.AuthorOfBook = str;
        }

        public void SetContent(string str)
        {
            _contentOfThisBook.ContentOfBook = str;
        }

        public void Show()
        {
            _titleOfThisBook.Show();
            _authorOfThisBook.Show();
            _contentOfThisBook.Show();
            Console.WriteLine();
        }       

    }


    class Title
    {
        private string _titleOfBook;

        public string TitleOfBook
        {
            get { return _titleOfBook; }
            set { _titleOfBook = value; }
        }


        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.White; // устанавливаем цвет
            Console.WriteLine(_titleOfBook);
            Console.ResetColor(); // сбрасываем в стандартный
        }
    }

    class Author
    {
        private string _authorOfBook;

        public string AuthorOfBook
        {
            get { return _authorOfBook; }
            set { _authorOfBook = value; }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_authorOfBook);
            Console.ResetColor();
        }
    }

    class Content
    {
        private string _contentOfBook;

        public string ContentOfBook
        {
            get { return _contentOfBook; }
            set { _contentOfBook = value; }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green; // White? :)
            Console.WriteLine(_contentOfBook);
            Console.ResetColor();
        }
    }
}
