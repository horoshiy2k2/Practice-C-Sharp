using HW2_SocialNetwork.Realizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork
{
    interface ISocialNetworkProvider
    {
        void Login(string email, string password);
        void Logout(string email, string password);
        void AddFriend(string email, string password, FriendBase friend);
        void AddUser(User user);

    }
}

//1.Нужно реализовать интерфейс ISocialNetworkProvider который будет
//иметь три метода. (Login, Logout, AddFriend())