using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork.Realizations
{
    abstract class FriendBase : IFriend
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public FriendBase ()
        {
            Name = ((Names)new Random().Next(0, 11)).ToString();
        }
    }
}
