using Microsoft.EntityFrameworkCore;
using ProductSale.Domain.Entities;
using ProductSale.Infra;

namespace ProductSale.Domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _context;

        public OrderRepository(IDbContext context)
        {
            _context = context;
        }

        public int CreateOrder(Order order)
        {
            _context.Orders.Add(order);

            return order.Id;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.AsNoTracking().ToList();
        }

        public List<Order> GetAllCustomerOrders(int customerId)
        {
            return _context.Orders.AsNoTracking().Where(x=> x.CustomerId == customerId).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(x => x.OrderProducts).SingleOrDefault(x => x.Id == id);
        }

        public Order UpdateOrder(Order order)
        {
            _context.Orders.Update(order);

            return order;
        }

        public OrderProduct UpdateOrderProduct(OrderProduct orderProduct)
        {
            throw new NotImplementedException();
        }
    }
}
