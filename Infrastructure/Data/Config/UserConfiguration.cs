using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UserConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
           builder.Entity<User>()
            .HasMany(u => u.Payments)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(false);


            builder.Entity<User>().Property(u => u.FirstName).IsRequired();
            builder.Entity<User>().Property(u => u.LastName).IsRequired();
            builder.Entity<User>().Property(u => u.Gender).IsRequired();
            builder.Entity<User>().Property(u => u.Birthday).IsRequired();
            builder.Entity<User>().Property(u => u.Adress).IsRequired();
            builder.Entity<User>().Property(u => u.Country).IsRequired();
            builder.Entity<User>().Property(u => u.Nationality).IsRequired();
            builder.Entity<User>().Property(u => u.MemberFrom).HasDefaultValue(DateTime.Now);
            builder.Entity<User>().Property(u => u.Active).HasDefaultValue(1);
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.Password).HasDefaultValue("test");
            builder.Entity<User>().Property(u => u.Phone).IsRequired();
            builder.Entity<User>().Property(u => u.MarriageStatus).HasDefaultValue("Unknown");
            builder.Entity<User>().Property(u => u.LastActive).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}