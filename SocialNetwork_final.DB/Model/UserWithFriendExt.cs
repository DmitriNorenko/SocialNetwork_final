﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Model
{
    public class UserWithFriendExt : User
    {
        public bool IsFriendWithCurrent {  get; set; }
    }
}
