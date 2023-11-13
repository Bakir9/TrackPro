using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class ChildConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Childs>().Property(c => c.FirstName).IsRequired();
            builder.Entity<Childs>().Property(c => c.LastName).IsRequired();
            builder.Entity<Childs>().Property(c => c.Gender).IsRequired();
            builder.Entity<Childs>().Property(c => c.Birthday).IsRequired();
            builder.Entity<Childs>().Property(c => c.Adress).IsRequired();
            builder.Entity<Childs>().Property(c => c.Country).IsRequired();
            builder.Entity<Childs>().Property(c => c.Nationality).IsRequired();
            builder.Entity<Childs>().Property(c => c.MemberFrom).HasDefaultValue(DateTime.Now);
            builder.Entity<Childs>().Property(c => c.Active).HasDefaultValue(1);
        }
    }
}