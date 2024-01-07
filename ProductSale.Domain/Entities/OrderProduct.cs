using System.ComponentModel.DataAnnotations;

namespace ProductSale.Domain.Entities
{
    public record OrderProduct
    {
        [Key]
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public OrderProduct(int productId, int quantity)
        {
            Quantity = quantity;
            ProductId = productId;
        }
    }
}