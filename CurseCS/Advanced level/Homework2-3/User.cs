using HW2_SocialNetwork.Realizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork
{
    enum Mail
    {
        gmail,
        mail,
        yandex,
        yahoo
    }

    enum Names
    {
        Vasya,
        Petr,
        Ira,
        Masha,
        Sasha,
        Dasha,
        Andrey,
        Dima,
        Egor,
        Arseniy,
        Vadim
    }

    class User
    {
        public static Random r = new Random();

        public string Email { get; set; }
        public string Password { get; set; } // пароль паблик только для режима разработчика
        public string Name { get; set; }
        public int Age { get; set; }
        private static int Id { get; set; }
        

        public User()
        {
            Name = ((Names)r.Next(0, 11)).ToString();
            Email = GenerateEmail();
            Password = GeneratePassword();
            Age = r.Next(13, 60);
            Id++;
        }

        string GenerateEmail()
        {
            return $"{Name}{Id}@{(Mail)r.Next(0, 4)}.com";
        }

        string GeneratePassword()
        {
            return $"{Name[0]}A_{Id}#{Age%4}";
        }

        public override string ToString()
        {
            return $"{Email}";
        }

        public void DisplayMessage(object obj, AccountEventArgs e)
        {
            Console.WriteLine($"{Email}: {e.Message}");
        }
    }
}

//2.Создать для пользователя класс User (поля определить самим. Точно
//будут Email и Password)
