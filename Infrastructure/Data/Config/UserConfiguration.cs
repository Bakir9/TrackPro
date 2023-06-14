using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Birthday).IsRequired();
            builder.Property(u => u.Adress).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Phone).IsRequired();
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.Nationality).IsRequired();
            builder.Property(u => u.MarriageStatus).IsRequired();
            builder.Property(u => u.MemberFrom).IsRequired();
            builder.Property(u => u.Active).IsRequired();
            builder.Property(u => u.LastActive).IsRequired();
            builder.HasMany(u => u.UserPayments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        }
    }
}