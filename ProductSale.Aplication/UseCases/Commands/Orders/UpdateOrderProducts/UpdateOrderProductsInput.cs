namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrderProducts
{
    public record UpdateOrderProductsInput
    {
        public HashSet<UpdateOrderProductInput> UpdateOrderProducts { get; private set; }

        public UpdateOrderProductsInput(HashSet<UpdateOrderProductInput> updateOrderProducts)
        {
            UpdateOrderProducts = updateOrderProducts;
        }
    }

    public record UpdateOrderProductInput
    {
        public int OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public UpdateOrderProductInput(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}