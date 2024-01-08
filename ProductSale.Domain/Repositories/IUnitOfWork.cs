namespace ProductSale.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        void SaveChanges();
    }
}
