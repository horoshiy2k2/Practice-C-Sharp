using HW2_SocialNetwork.Realizations;
using System;
using System.Collections.Generic;

namespace HW2_SocialNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var vk = new VK();
            var countUsers = 10;
            var users = GetRandomUsers(countUsers); // метод для генерации юзеров

            AddUsersInSocialNetwork(users, vk);

            vk.ShowUsers();

            vk.Login("email1", "password1"); // вошёл в акк
            vk.Login("email1", "password1"); // уже вошёл
            vk.Login("asd", "sda"); // неверно
            Console.WriteLine();

            vk.Logout("email1", "password1"); // вышел из акка
            vk.Logout("email1", "password1"); // уже вышел из акка
            vk.Logout("213", "awe"); // неверно
            Console.WriteLine();

            vk.Login("email1", "password1"); // вошёл
            vk.Login("email1", "password1"); // уже вошёл
            Console.WriteLine();

            vk.AddFriend("email1", "password1", new FriendBase())

        }
        
        static List<User> GetRandomUsers(int countUsers)// А надо ли? Может просто работать с VK ?
        {
            var users = new List<User>();
            for (int i = 0; i < countUsers; i++)
            {
                users.Add(new User() { Email = "email" + i, Password = "password" + i });
            }
            return users;
        }

        static void AddUsersInSocialNetwork(List<User> users, ISocialNetworkProvider socialNetwork)// А надо ли? Может просто работать с VK ?
        {
            foreach (var user in users)
            {
                socialNetwork.AddUser(user);
            }
        }

    }
    //добавить рандомное количество юзеров = генереция = метод. МОжно ещё и друзей случано подобавлять (отдельный метод или сразу можно)
}

//Создать приложение (консольное приложение), с помощью которого
//пользователь сможет залогиниться, вылогиниться и добавить друга в
//социальной сети (VK, Facebook).





//6. Коллекция друзей – это Dictionary&lt; User, T & gt;. T берется из
//ISocialNetworkProvider&lt; T & gt;
//Добавить поддержку трех соцсетей Vk и Facebook и Instagram.