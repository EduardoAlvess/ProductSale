using ProductSale.Domain.Entities;

namespace ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrderProducts
{
    public record UpdateOrderProductsOutput
    {
        public List<UpdateOrderProductOutput> UpdateOrderProducts { get; set; }

        public UpdateOrderProductsOutput(List<OrderProduct> orderProducts)
        {
            UpdateOrderProducts = orderProducts.Select(op =>
                                                    new UpdateOrderProductOutput(op.Id, op.OrderId, op.ProductId, op.Quantity)
                                               ).ToList();
        }
    }

    public record UpdateOrderProductOutput
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public UpdateOrderProductOutput(int id, int orderId, int productId, int quantity)
        {
            Id = id;
            OrderId = orderId;
            Quantity = quantity;
            ProductId = productId;
        }
    }
}