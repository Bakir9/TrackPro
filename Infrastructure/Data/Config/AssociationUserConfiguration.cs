
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class AssociationUserConfiguration
    {
        public void Configure(ModelBuilder builder)
        {
           builder.Entity<Association>()
           .HasMany(a => a.Users)
           .WithOne(a => a.Association)
           .HasForeignKey(a => a.AssociationId)
           .IsRequired();

           builder.Entity<Association>().Property(a => a.Id).IsRequired();
           builder.Entity<Association>().Property(a => a.Name).IsRequired();
           builder.Entity<Association>().Property(a => a.CreatedBy).IsRequired();
           builder.Entity<Association>().Property(a => a.CreatedAt).HasDefaultValue(DateTime.Now);
        }
    }
}