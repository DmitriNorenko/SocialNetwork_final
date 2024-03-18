using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Repository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}
