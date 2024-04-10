using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Repository
{
    public class FriendsRepository : IFriendsRepository
    {
        private SocialNetworkContext _context;

        public FriendsRepository(SocialNetworkContext context)
        {
            _context = context;
        }

        public void AddFriend(User user, User friend)
        {
            var friends = _context.UserFriends.Where(x => x.UserId == user.Id && x.CurrentFriendId == friend.Id).FirstOrDefault();
            if (friends == null)
            {
                var newFriends = new Friend
                {
                    id = new Guid(),
                    UserId = user.Id,
                    User = user,
                    CurrentFriend = friend,
                    CurrentFriendId = friend.Id,
                };
                _context.UserFriends.Add(newFriends);
            }
            _context.SaveChanges();
        }

        public void DeleteFriend(User user, User friend)
        {
            var friends = _context.UserFriends.Where(x => x.UserId == user.Id && x.CurrentFriendId == friend.Id).FirstOrDefault();
            if (friends != null)
            {
                _context.UserFriends.Remove(friends);
            }
            _context.SaveChanges();
        }

        public List<User> GetAllFriends(User user)
        {
            var friends = _context.UserFriends.Where(x => x.UserId == user.Id).Select(x => x.CurrentFriend).ToList();
            return friends;
        }
    }
}
