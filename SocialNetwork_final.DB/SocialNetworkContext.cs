using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB
{
    public class SocialNetworkContext : IdentityDbContext<User>
    {
        public DbSet<Friend> UserFriends { get; set; }
        public DbSet<Message> Messages { get; set; }
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Friend>().ToTable("UserFriends");
            builder.Entity<Message>().ToTable("Messages");
        }
    }
}
