using ProductSale.Domain.Repositories;

namespace ProductSale.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }

        private readonly IDbContext _dbContext;

        public UnitOfWork(
            IDbContext dbContext, 
            IOrderRepository orderRepository,
            IProductRepository productRepository, 
            ICustomerRepository customerRepository) 
        {

            _dbContext = dbContext;
            OrderRepository = orderRepository;
            ProductRepository = productRepository;
            CustomerRepository = customerRepository;
        }


        public void SaveChanges()
        {
            _dbContext.Save();
        }
    }
}
