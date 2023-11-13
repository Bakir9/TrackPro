using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Data.Config
{
    public class PaymentConfiguration 
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<Payment>().Property(p => p.UserId).IsRequired();
            builder.Entity<Payment>().Property(p => p.Amount).IsRequired();
            builder.Entity<Payment>().Property(p => p.PaymentMethod).IsRequired();
            builder.Entity<Payment>().Property(p => p.Month).IsRequired();
            builder.Entity<Payment>().Property(p => p.Year).IsRequired();
            builder.Entity<Payment>().Property(p => p.Purpose).IsRequired();
            builder.Entity<Payment>().Property(p => p.PaymentDate).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}