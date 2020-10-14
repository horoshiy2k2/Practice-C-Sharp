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

            // в отдельный метод по добавлению случайных друзей списку друзей
            foreach (var user in users)
            {
                vk.Login(user.Email, user.Password);
                Console.WriteLine();

                var r = new Random();
                var countFriends = r.Next(0, 5);
                var friends = GetRandomFriends(countFriends);


                foreach (var friend in friends)
                {
                    vk.AddFriend(user.Email, user.Password, friend);
                }

                Console.WriteLine();
                vk.Logout(user.Email, user.Password);
            }
            


        }

        static List<User> GetRandomUsers(int countUsers)// А надо ли? Может просто работать с VK ? // List<T>
        {
            var users = new List<User>();
            for (int i = 0; i < countUsers; i++)
            {
                users.Add(new User() { Email = "email" + i, Password = "password" + i });
            }
            return users;
        }

        static List<FriendBase> GetRandomFriends(int countFriends)
        {
            var r = new Random(); // глобально объявить бы...

            var friends = new List<FriendBase>();

            for (int i = 0; i < countFriends; i++)
            {
                switch (r.Next(0, 3)) // 0 1 2
                {
                    case 0:
                        friends.Add(new FriendVK() { Name = "Name" + i }); // инициализатор заполнить везде
                        break;
                    case 1:
                        friends.Add(new FriendFB() { Name = "Name" + i });
                        break;
                    case 2:
                        friends.Add(new FriendIG() { Name = "Name" + i });
                        break;
                    default:
                        break;
                }
            }

            return friends;
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