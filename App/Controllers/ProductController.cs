using Microsoft.AspNetCore.Mvc;
using ProductSale.App.Services.ProductService;
using ProductSale.DTOs.Product;

namespace ProductSale.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public void Create(InputProductDto productDto)
        {
            _productService.CreateProduct(productDto);
        }

        [HttpDelete("{productId}")]
        public void Delete(int productId)
        {
            _productService.DeleteProduct(productId);
        }


        [HttpGet("{productId}")]
        public OutputProductDto GetById(int productId)
        {
            var product = _productService.GetProductById(productId);

            return product;
        }
    }
}
