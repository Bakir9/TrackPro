using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class UserChildsConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasMany(u => u.Childs)
            .WithMany(u => u.Users)
            .UsingEntity<UserChilds>();
        }
    }
}