using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkContext _context;
        public UserRepository(SocialNetworkContext context) 
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            var empty = _context.Entry(user);
            if(empty.State == EntityState.Detached) 
            {
            await _context.Users.AddAsync(user);
            }
            await _context.SaveChangesAsync();
        }
    }
}
