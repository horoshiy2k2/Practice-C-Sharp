using System;
using System.Collections.Generic;
using System.Text;

namespace HW2_SocialNetwork
{
    interface IFriend
    {
        string Name { get; set; }
        //Что-то общее для всех друзей, не важно откуда они
    }
}

//3.Создать интерфейс IFriend(базовы) и конкретные интерфейсы, и
//реализации для трех соц. сетей Vk и Facebook, и Instagram.