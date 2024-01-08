using ProductSale.Domain.Entities;

namespace ProductSale.Domain.Repositories
{
    public interface IOrderRepository
    {
        OrderProduct UpdateOrderProduct(OrderProduct orderProduct);
        List<Order> GetAllCustomerOrders(int customerId);
        Order UpdateOrder(int id, Order order);
        int CreateOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
    }
}
