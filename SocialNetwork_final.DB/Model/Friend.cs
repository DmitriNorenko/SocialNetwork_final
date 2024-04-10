using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Model
{
    [Table("UserFriends")]
    public class Friend
    {
        public Guid id { get; set; }
        public string? UserId {  get; set; }
        public User? User {  get; set; }
        public string? CurrentFriendId { get; set; }
        public User? CurrentFriend { get; set; }
    }
}
