using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSale.Domain.Entities;

namespace ProductSale.Infra.Configurations
{
    internal class OrderProductsConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(op => op.Id);

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(op => op.ProductId);
        }
    }
}
