using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork.Realizations
{
    class VK : ISocialNetworkProvider // :SocialNetworkBase
    {
        private Dictionary<User, FriendBase> _users = new Dictionary<User, FriendBase>(); // Dictionary(User, FriendCollection)
        private Dictionary<User, FriendBase> _LoggedUsers = new Dictionary<User, FriendBase>(); // Dictionary

        public void AddFriend(User user, FriendBase friend)
        {
            if (_LoggedUsers.ContainsKey(user)) // проверить, как определяет, есть ли ключ
            {
                if (friend is FriendVK)
                {
                    _users.Add(user, friend); //в коллекцию с этим пользователем добавляем нового друга
                    _LoggedUsers.Add(user, friend);
                }
                else if (friend is FriendFB)
                {
                    Console.WriteLine("Невозвможно добавить друга из FB пользователю VK ");
                }
                else if (friend is FriendIG)
                {
                    Console.WriteLine("Невозвможно добавить друга из IG пользователю VK ");
                }
            }
            else {
                Console.WriteLine("Пользователь не авторизован");
            }
            
        }

        public void Login(string email, string password)
        {
            var user = GetUserByEmailAndPassword(email, password);

            if (user.Key != null) // структуру KeyValuePair<T,T> нельзя просто так сравнить с null
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
                    Console.WriteLine($"Пользователь {email} вышел из аккаунта");
                } else
                {
                    Console.WriteLine("Пользователь не был авторизован");
                }
                
            } else
            {
                Console.WriteLine("Неверно введён адрес почты или пароль для выхода из аккаунта");
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
                _users.Add(user, null); // у пользователья нет друзей :(
            }
        }

        public void ShowUsers()
        {
            foreach (var user in _users)
            {
                Console.WriteLine(user.Key.Email); // вывести с друзьями - переопределить метод ToString у друзей в базовом
            }
        }

        private KeyValuePair<User, FriendBase> GetUserByEmailAndPassword(string email, string password)
        {
            foreach (var user in _users)
            {
                if (user.Key.Email == email && user.Key.Password == password)
                {
                    return user;
                }
            }
            return new KeyValuePair<User, FriendBase>(); // вместо null
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