using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.PaymentMethod).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
        }
    }
}