using SocialNetwork_final.DB.Model;
using System.Diagnostics.Contracts;

namespace SocialNetwork_final.ViewModels.Account
{
    public class UserViewModel
    {
        public User user { get; set; }
        public UserViewModel(User user)
        {
            this.user = user;
        }
    }
}
