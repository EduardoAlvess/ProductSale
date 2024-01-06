using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductSale.Domain.Entities;

namespace ProductSale.Infra.Configurations
{
    internal class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Stage).IsRequired();
            builder.Property(o => o.Amount).IsRequired();
            builder.Property(o => o.Profit).IsRequired();

            builder.HasOne<Customer>()
                   .WithMany()
                   .HasForeignKey(o => o.CustomerId)
                   .IsRequired();

            builder.HasMany(o => o.OrderProducts)
                   .WithOne()
                   .HasForeignKey(op => op.OrderId);
        }
    }
}
