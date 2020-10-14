using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork.Realizations
{
    class VK : ISocialNetworkProvider // :SocialNetworkBase
    {
        private Dictionary<User, List<FriendBase>> _users = new Dictionary<User, List<FriendBase>>(); // Dictionary(User, FriendCollection)
        private Dictionary<User, List<FriendBase>> _LoggedUsers = new Dictionary<User, List<FriendBase>>();

        public void AddFriend(string email, string password, FriendBase friend) // для каждого свой можно сделать, а можно заморочиться с основным
        {
            var user = GetUserByEmailAndPassword(email, password);
            if (_LoggedUsers.ContainsKey(user.Key))
            {
                if (friend is FriendVK)
                {
                   //добавить друга в список в словаре
                    _users[user.Key].Add(friend);
                    _LoggedUsers[user.Key].Add(friend);

                    Console.WriteLine($"У {user.Key.Email} новый друг: {friend}");
                }
                else if (friend is FriendFB)
                {
                    Console.WriteLine($"Невозвможно добавить друга из FB ({friend}) пользователю VK ({user.Key.Email})");
                }
                else if (friend is FriendIG)
                {
                    Console.WriteLine($"Невозвможно добавить друга из IG ({friend}) пользователю VK ({user.Key.Email})");
                }
            }
            else {
                Console.WriteLine("Пользователь не авторизован");
            }
            
        }

        public void Login(string email, string password)
        {
            var user = GetUserByEmailAndPassword(email, password);

            if (user.Key != null) 
            {
                if (_LoggedUsers.ContainsKey(user.Key))
                {
                    Console.WriteLine("Пользователь уже авторизован");
                }
                else
                {
                    _LoggedUsers.Add(user.Key, user.Value);
                    Console.WriteLine($"Добро пожаловать в {GetType().Name}, {email}");
                }
            }
            else
            {
                Console.WriteLine("Неверный адрес почты или пароль");
            }            
        }

        public void Logout(string email, string password)
        {
            var user = GetUserByEmailAndPassword(email, password);
            if (user.Key != null) {
                if (_LoggedUsers.ContainsKey(user.Key))
                {
                    _LoggedUsers.Remove(user.Key); // проверить, как удаляет null. удаляет какую-то дичь чекнуть, как правильно сделать 2:2
                    Console.WriteLine($"Пользователь {email} вышел из аккаунта\n\n");
                } else
                {
                    Console.WriteLine("Пользователь не был авторизован\n\n");
                }
                
            } else
            {
                Console.WriteLine("Неверно введён адрес почты или пароль для выхода из аккаунта\n\n");
            }
            
        }

        public void AddUser(User user)
        {
            if (_users.ContainsKey(user))
            {
                Console.WriteLine("Такой пользователь уже зарегистрирован");
            }
            else
            {
                _users.Add(user, new List<FriendBase>()); // важно: выделяем место на список, а не null
            }
        }

        public void ShowUsers()
        {
            Console.WriteLine("Все зарегистрированные пользователи: ");
            foreach (var user in _users)
            {
                Console.WriteLine($"Пользователь {user.Key.Email}");

                if(user.Value.Count != 0)
                {
                    Console.WriteLine("Друзья:");
                    foreach (var friend in user.Value)
                    {
                        Console.WriteLine(friend);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private KeyValuePair<User, List<FriendBase>> GetUserByEmailAndPassword(string email, string password)
        {
            foreach (var user in _users)
            {
                if (user.Key.Email == email && user.Key.Password == password)
                {
                    return user;
                }
            }
            return new KeyValuePair<User, List<FriendBase>>(); // вместо null
        }
    }
}

//4. При реализации метода логин – проверяем в коллекции существующих
//пользователей что юзер существует (проверка идет по Email и
//Password) и добавляем User в коллекцию залогиненных. Данные две
//коллекции хранятся в классе конкретного провайдера.

//5. При вызове AddFriend проверяем что пользователь залогинен и если
//да – добавляем ему в коллекцию друзей нового. Если пытаемся
//добавить пользователя не того типа – пишем на консоль не могу
//добавить пользователя Facebook в Instagram.