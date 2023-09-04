using Microsoft.AspNetCore.Authorization;
using SalesSystem.Modules.Products.Domain.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SalesSystem.Modules.Products.Aplication.Create;
using SalesSystem.Modules.Products.Aplication.Update;
using SalesSystem.Modules.Products.Aplication.GetAll;
using SalesSystem.Modules.Products.Aplication.Delete;
using SalesSystem.Modules.Products.Aplication.GetById;
using SalesSystem.Modules.ProductCategories.Aplication.Create;
using SalesSystem.Modules.ProductCategories.Aplication.Delete;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ApiController
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(productId => Ok(productId), errors => Problem(errors));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateProductCommand command)
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

        [HttpPost("AddCategoryToProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategoryToProduct([FromBody] CreateProductCategoryCommand command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(productId => Ok(productId), errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(new DeleteProductCommand(id));

            return deleteResult.Match(productId => NoContent(), errors => Problem(errors));
        }

        [HttpDelete("DeleteCategoryToProduct")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategoryToProduct([FromBody] DeleteProductCategoryCommand command)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(command);

            return deleteResult.Match(productId => NoContent(), errors => Problem(errors));
        }
    }
}
