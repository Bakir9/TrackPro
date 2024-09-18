using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class UserActivityConfiguration
    {
        public void Configure(ModelBuilder builder)
        { 
            // builder.Entity<User>()
            // .HasMany(e => e.Activities)
            // .WithMany(e => e.Users)
            // .UsingEntity<UserActivities>();
                // a => a.HasOne<Activity>(e => e.Activity).WithMany(e => e.UserActivities).HasForeignKey(e => e.ActivityId),
                // u => u.HasOne<User>(e => e.User).WithMany(e => e.UserActivities).HasForeignKey(e => e.UserId));
        }
    }
}