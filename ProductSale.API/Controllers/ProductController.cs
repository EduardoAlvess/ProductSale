using ProductSale.Aplication.UseCases.Commands.Products.CreateProduct;
using ProductSale.Aplication.UseCases.Commands.Products.UpdateProduct;
using ProductSale.Aplication.UseCases.Queries.Products.GetAllProducts;
using ProductSale.Aplication.UseCases.Queries.Products.GetProductById;
using ProductSale.Aplication.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ProductSale.API.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        [Route("/CreateProduct")]
        public async Task<IActionResult> Create([FromBody] CreateProductInput createProductInput, [FromServices] IUseCase<CreateProductInput, UseCaseResult<int>> useCase)
        {
            var output = await useCase.Execute(createProductInput);

            return Ok(output);
        }

        [HttpPut]
        [Route("/UpdateProduct/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductInput updateProductInput, [FromServices] IUseCase<UpdateProductInput, UseCaseResult<UpdateProductOutput>> useCase)
        {
            updateProductInput.SetId(id);

            var output = await useCase.Execute(updateProductInput);

            return Ok(output);
        }

        [HttpDelete]
        [Route("/DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] IUseCase<int, UseCaseResult<NoOutput>> useCase)
        {
            var output = await useCase.Execute(id);

            return Ok(output);
        }

        [HttpGet]
        [Route("/GetProductById/{id}")]
        public async Task<IActionResult> GetById(int id, [FromServices] IUseCase<int, UseCaseResult<GetProductByIdOutput>> useCase)
        {
            var output = await useCase.Execute(id);

            return Ok(output);
        }

        [HttpGet]
        [Route("/GetAllProducts")]
        public async Task<IActionResult> GetAll([FromServices] IUseCase<NoInput, UseCaseResult<GetAllProductsOutput>> useCase)
        {
            var output = await useCase.Execute();

            return Ok(output);
        }
    }
}
