using ProductSale.App.Services.CustomerService;
using ProductSale.DTOs.Customers;
using ProductSale.Infra.Cache;

namespace ProductSaleTest
{
    public class CustomerTest
    {
        private readonly ICustomerService _customerService;
        private readonly ICacheProvider _cache;
        private readonly IDbContext _db;

        public CustomerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            _db = new DataContext(optionsBuilder.Options);
            _cache = new Mock<ICacheProvider>().Object;

            PopulateTable();

            _customerService = new CustomerService(_db, _cache);
        }

        [Fact]
        public void CreateCustomer_ShouldCreate()
        {
            InputCustomerDto inputCustomerDto = new()
            {
                Name = "Paulo",
                Phone = "51 982016597",
                Register = "823.918.950-73"
            };

            _customerService.CreateCustomer(inputCustomerDto);

            var customer = _db.Customers.First(p => p.Id == 2);

            Assert.Equal("Paulo", customer.Name);
            Assert.Equal("51 982016597", customer.Phone);
            Assert.Equal("823.918.950-73", customer.Register);
        }

        [Fact]
        public void GetAllCustomer_ShouldReturnAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();

            Assert.True(customers.Count() > 0);
        }

        [Fact]
        public void GetCustomerById_ShouldReturnCustomer()
        {
            var customer = _customerService.GetCustomerById(1);

            Assert.NotNull(customer);
        }

        [Fact]
        public void UpdateCustomer_ShouldUpdate()
        {
            var jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/name", "Roberto");

            _customerService.UpdateCustomer(1, jsonPatch);

            Assert.Equal("Roberto", _db.Customers.First(p => p.Id == 1).Name);
        }

        private void PopulateTable()
        {
            Customer customer = new()
            {
                Name = "Eduardo",
                Register = "673.608.520-72",
                Phone = "51 92202-2979",
            };

            _db.Customers.Add(customer);

            _db.Save();
        }
    }
}