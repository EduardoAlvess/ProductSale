using ProductSale.App.Services.ProductService;
using ProductSale.DTOs.Products;
using ProductSale.Infra.Cache;

namespace ProductSaleTest
{
    public class ProductTest
    {
        private readonly IProductService _productService;
        private readonly ICacheProvider _cache;
        private readonly IDbContext _db;

        public ProductTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            _db = new DataContext(optionsBuilder.Options);
            _cache = new Mock<ICacheProvider>().Object;

            PopulateTable();

            _productService = new ProductService(_db, _cache);
        }

        [Fact]
        public void CreateProduct_ShouldCreate()
        {
            InputProductDto inputProductDto = new()
            {
                Value = 200,
                Name = "Bed",
                AmountInStock = 5,
                ProductionCost = 50,
                Description = "A bed"
            };

            _productService.CreateProduct(inputProductDto);

            var product = _db.Products.First(p => p.Id == 2);

            Assert.Equal(200, product.Value);
            Assert.Equal("Bed", product.Name);
            Assert.Equal(5, product.AmountInStock);
            Assert.Equal(50, product.ProductionCost);
            Assert.Equal("A bed", product.Description);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var products = _productService.GetAllProducts();

            Assert.True(products.Count() > 0);
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct()
        {
            var product = _productService.GetProductById(1);

            Assert.NotNull(product);
        }

        [Fact]
        public void DeleteProduct_ShouldDelete()
        {
            _productService.DeleteProduct(1);

            Assert.True(_db.Products.First(p => p.Id == 1).isDeleted == true);
        }

        [Fact]
        public void UpdateProduct_ShouldUpdate()
        {
            var jsonPatch = new JsonPatchDocument();
            jsonPatch.Replace("/name", "Microwave");

            _productService.UpdateProduct(1, jsonPatch);

            Assert.Equal("Microwave", _db.Products.First(p => p.Id == 1).Name);
        }

        private void PopulateTable()
        {
            Product product = new()
            {
                Value = 20,
                Name = "Table",
                AmountInStock = 2,
                ProductionCost = 10,
                Description = "A Table"
            };

            _db.Products.Add(product);

            _db.Save();
        }
    }
}