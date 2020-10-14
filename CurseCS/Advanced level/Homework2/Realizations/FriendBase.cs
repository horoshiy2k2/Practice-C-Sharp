using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork.Realizations
{
    abstract class FriendBase : IFriend //:user//?
    {
        //Дата регистрации в вк или вообще, Количество общих друзей
        public string Name{ get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
