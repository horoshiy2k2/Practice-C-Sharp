using HW2_SocialNetwork.Realizations;
using System;
using System.Collections.Generic;

namespace HW2_SocialNetwork
{
    class Program
    {
        public static Random r = new Random();

        static void Main(string[] args)
        {
            var vk = new VK();
            var ig = new IG();
            var fb = new FB();

            var countUsers = r.Next(3, 6);
            var usersVK = GetRandomUsers(countUsers); // просто данные пользователей
            var usersIG = GetRandomUsers(countUsers); 
            var usersFB = GetRandomUsers(countUsers); 

            AddUsersInSocialNetwork(usersVK, vk);
            AddUsersInSocialNetwork(usersIG, ig);
            AddUsersInSocialNetwork(usersFB, fb);

            vk.ShowUsers();
            ig.ShowUsers();
            fb.ShowUsers();

            AddRandomFriendsToUsersInSocialnetwork(usersVK, vk);
            AddRandomFriendsToUsersInSocialnetwork(usersIG, ig);
            AddRandomFriendsToUsersInSocialnetwork(usersFB, fb);
            
            vk.ShowUsers();
            ig.ShowUsers();
            fb.ShowUsers();

            Console.ForegroundColor = ConsoleColor.White;
        }


        static List<User> GetRandomUsers(int countUsers)
        {
            var users = new List<User>();
            for (int i = 0; i < countUsers; i++)
            {
                users.Add(new User());
            }
            return users;
        }

        static List<FriendBase> GetRandomFriends(int countFriends)
        {
            var friends = new List<FriendBase>();

            for (int i = 0; i < countFriends; i++)
            {
                switch (r.Next(0, 3))
                {
                    case 0:
                        friends.Add(new FriendVK());
                        break;
                    case 1:
                        friends.Add(new FriendFB());
                        break;
                    case 2:
                        friends.Add(new FriendIG());
                        break;
                    default:
                        break;
                }
            }

            return friends;
        }

        static void AddUsersInSocialNetwork(List<User> users, ISocialNetworkProvider socialNetwork)
        {
            foreach (var user in users)
            {
                socialNetwork.AddUser(user);
            }
        }

        static void AddRandomFriendsToUsersInSocialnetwork(List<User> users, ISocialNetworkProvider socialNetwork)
        {
            foreach (var user in users)
            {
                if (r.Next(0, 2) == 1) // 50% что кто-то зайдёт в аккаунт
                {
                    socialNetwork.Login(user.Email, user.Password);
                    Console.WriteLine();

                    var countFriends = r.Next(0, 15);
                    var friends = GetRandomFriends(countFriends);

                    foreach (var friend in friends)
                    {
                        socialNetwork.AddFriend(user.Email, user.Password, friend);
                    }

                    Console.WriteLine();
                    socialNetwork.Logout(user.Email, user.Password);
                }
            }
        }
    }
}

//Создать приложение (консольное приложение), с помощью которого
//пользователь сможет залогиниться, вылогиниться и добавить друга в
//социальной сети (VK, Facebook).
//Добавить поддержку трех соцсетей Vk и Facebook и Instagram.