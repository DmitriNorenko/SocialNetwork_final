using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Repository.Friends
{
    public interface IFriendsRepository
    {
        void AddFriend(User user, User Friend);
        void DeleteFriend(User User, User Friend);
        List<User> GetAllFriends(User user);
    }
}
