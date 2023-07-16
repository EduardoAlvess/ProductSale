using Microsoft.AspNetCore.Mvc;
using ProductSale.App.Services.ProductService;
using ProductSale.DTOs.Products;
using Microsoft.AspNetCore.JsonPatch;

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

        /// <summary>
        /// Create new product
        /// </summary>
        /// <remarks>
        /// {"name":"Table","value":500,"amountInStock":2,"description":"A dinner table","productionCost":100}
        /// </remarks>
        /// <param name="productDto">Product infos</param>
        [HttpPost]
        public void Create(InputProductDto productDto) => _productService.CreateProduct(productDto);

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        [HttpDelete("{productId}")]
        public void Delete(int productId) => _productService.DeleteProduct(productId);

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product infos</returns>
        [HttpGet("{productId}")]
        public OutputProductDto GetById(int productId) => _productService.GetProductById(productId);

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>A list of products</returns>
        [HttpGet]
        public List<OutputProductDto> Get() => _productService.GetAllProducts();

        /// <summary>
        /// Update product infos
        /// </summary>
        /// <remarks>
        /// [{"op":"replace","path":"/name","value":"Diner table"}]
        /// </remarks>
        /// <param name="productId">Product identifier</param>
        /// <param name="product">Product info to be replaced and the new value</param>
        [HttpPatch("{productId}")]
        public void Update(int productId, [FromBody] JsonPatchDocument product) => _productService.UpdateProduct(productId, product);
    }
}
