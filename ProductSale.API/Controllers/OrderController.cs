using ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrderProducts;
using ProductSale.Aplication.UseCases.Commands.Orders.CreateOrder;
using ProductSale.Aplication.UseCases.Commands.Orders.UpdateOrder;
using ProductSale.Aplication.UseCases.Queries.Orders.GetOrderById;
using ProductSale.Aplication.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ProductSale.API.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [Route("/CreateOrder")]
        public async Task<IActionResult> Create([FromBody] CreateOrderInput createOrderInput, [FromServices] IUseCase<CreateOrderInput, UseCaseResult<int>> useCase)
        {
            var output = useCase.Execute(createOrderInput);

            return Ok(output);
        }

        [HttpPatch]
        [Route("/UpdateOrder")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderInput updateOrderInput, [FromServices] IUseCase<UpdateOrderInput, UseCaseResult<UpdateOrderOutput>> useCase)
        {
            var output = useCase.Execute(updateOrderInput);

            return Ok(output);
        }

        [HttpPatch]
        [Route("/UpdateOrderProduct")]
        public async Task<IActionResult> UpdateOrderProduct([FromBody] UpdateOrderProductsInput updateOrderProductInput, [FromServices] IUseCase<UpdateOrderProductsInput, UseCaseResult<UpdateOrderProductsOutput>> useCase)
        {
            var output = useCase.Execute(updateOrderProductInput);

            return Ok(output);
        }

        [HttpGet]
        [Route("/GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id, [FromServices] IUseCase<int, UseCaseResult<GetOrderByIdOutput>> useCase)
        {
            var output = useCase.Execute(id);

            return Ok(output);
        }
    }
}
