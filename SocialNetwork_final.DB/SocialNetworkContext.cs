﻿using Microsoft.EntityFrameworkCore;
using SocialNetwork_final.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork_final.DB
{
    public class SocialNetworkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public SocialNetworkContext(DbContextOptions<SocialNetworkContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}