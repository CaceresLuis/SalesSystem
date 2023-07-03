using Microsoft.AspNetCore.Mvc;
using SalesSystem.Products.Domain.Dto;
using SalesSystem.Products.Aplication.Create;
using SalesSystem.Products.Aplication.GetAll;
using SalesSystem.Products.Aplication.Update;
using SalesSystem.Products.Aplication.Delete;
using SalesSystem.Products.Aplication.GetById;

namespace SalesSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiController
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr<IReadOnlyList<ProductResponseDto>> productResult = await _mediator.Send(new GetAllProductsQuery());

            return productResult.Match
                (
                    categories => Ok(categories),
                    errors => Problem(errors)
                 );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<ProductResponseDto> result = await _mediator.Send(new GetByIdProductQuery(id));

            return result.Match
                (
                    product => Ok(product),
                    errors => Problem(errors)
                 );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(productId => Ok(productId), errors => Problem(errors));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                List<Error> errors = new()
                {
                    Error.Validation("Product.UpdateInvalid", "The request Id does not match with the url Id")
                };

                return Problem(errors);
            }

            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(categoryId => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(new DeleteProductCommand(id));

            return deleteResult.Match(productId => NoContent(), errors => Problem(errors));
        }
    }
}
