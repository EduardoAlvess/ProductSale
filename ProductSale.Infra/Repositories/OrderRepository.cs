using ProductSale.Domain.Entities;

namespace ProductSale.Domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public int CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public OrderProduct UpdateOrderProduct(OrderProduct orderProduct)
        {
            throw new NotImplementedException();
        }
    }
}
