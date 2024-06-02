using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class UserPaymentsConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasMany(p => p.Payments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .IsRequired();
        }
    }
}