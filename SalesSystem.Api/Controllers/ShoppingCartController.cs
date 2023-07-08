using Microsoft.AspNetCore.Mvc;
using SalesSystem.Modules.CartItems.Application.Create;
using SalesSystem.Modules.CartItems.Application.Delete;
using SalesSystem.Modules.CartItems.Application.GetAll;
using SalesSystem.Modules.CartItems.Application.UpdateQyt;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ApiController
    {
        private readonly ISender _mediator;

        public ShoppingCartController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetAll(Guid cartId)
        {
            ErrorOr<IReadOnlyList<Modules.CartItems.Domain.Dto.CartItemResponseDto>> result = await _mediator.Send(new GetAllCartItemQuery(cartId));

            return result.Match
                (
                    categories => Ok(categories),
                    errors => Problem(errors)
                 );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCartItemCommad command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(cartItemId => Ok(), errors => Problem(errors));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCartItemQtyCommand command)
        {
            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(cartItemId => NoContent(), errors => Problem(errors));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCartItemCommand command)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(command);

            return deleteResult.Match(cartItemId => NoContent(), errors => Problem(errors));
        }
    }
}
