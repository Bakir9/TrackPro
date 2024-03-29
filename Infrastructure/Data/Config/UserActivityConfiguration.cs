using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class UserActivityConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasMany(e => e.Activities)
            .WithMany(e => e.Users)
            .UsingEntity<UserActivities>();
        }
    }
}