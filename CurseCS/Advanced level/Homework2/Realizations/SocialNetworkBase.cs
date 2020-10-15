using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork.Realizations
{
    abstract class SocialNetworkBase : ISocialNetworkProvider 
    {
        private Dictionary<User, List<FriendBase>> _users = new Dictionary<User, List<FriendBase>>(); 
        private Dictionary<User, List<FriendBase>> _LoggedUsers = new Dictionary<User, List<FriendBase>>(); 

        public void AddFriend(string email, string password, FriendBase friend)
        {
            SwitchColorConsole();

            var user = GetUserByEmailAndPassword(email, password);
            if (_LoggedUsers.ContainsKey(user.Key))
            {
                if (friend is FriendVK && this is VK || friend is FriendFB && this is FB || friend is FriendIG && this is IG)
                {
                    _users[user.Key].Add(friend);
                    //_LoggedUsers[user.Key].Add(friend); //??? как так то. Это же разные вообще области памяти... Спросить
                    Console.WriteLine($"У {user.Key.Email} новый друг: {friend}");
                }
                else
                {
                    Console.WriteLine($"Невозвможно добавить {friend.GetType().Name} ({friend}) пользователю {GetType().Name} ({user.Key.Email})");
                }
            }
            else
            {
                Console.WriteLine("Пользователь не авторизован");
            }

        }

        public void Login(string email, string password)
        {
            SwitchColorConsole();

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
                    Console.WriteLine($"Добро пожаловать в {GetType().Name}, {user.Key}");
                }
            }
            else
            {
                Console.WriteLine("Неверный адрес почты или пароль");
            }
        }

        public void Logout(string email, string password)
        {
            SwitchColorConsole();

            var user = GetUserByEmailAndPassword(email, password);
            if (user.Key != null)
            {
                if (_LoggedUsers.ContainsKey(user.Key))
                {
                    _LoggedUsers.Remove(user.Key);
                    Console.WriteLine($"Пользователь {user.Key} вышел из {GetType().Name}\n\n");
                }
                else
                {
                    Console.WriteLine("Пользователь не был авторизован\n\n");
                }

            }
            else
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
            SwitchColorConsole();
            
            Console.WriteLine($"Все зарегистрированные пользователи {GetType().Name}: ");
            
            foreach (var user in _users)
            {
                Console.WriteLine($"Пользователь {user.Key.Email}");

                if (user.Value.Count != 0)
                {
                    Console.WriteLine("Друзья:");
                    foreach (var friend in user.Value)
                    {
                        Console.WriteLine(friend);
                    }
                    Console.WriteLine();
                }
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

            return new KeyValuePair<User, List<FriendBase>>(); 
        }

        private void SwitchColorConsole()
        {
            if (this is VK)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (this is IG)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (this is FB)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
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