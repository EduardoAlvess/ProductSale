namespace ProductSale.Domain.Entities
{
    public record OrderProduct
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public OrderProduct(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}