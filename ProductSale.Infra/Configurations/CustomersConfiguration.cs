using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductSale.Domain.Entities;

namespace ProductSale.Infra.Configurations
{
    internal class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Register).HasMaxLength(18).IsRequired();
        }
    }
}
