using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SalesSystem.Modules.CartItems.Domain.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SalesSystem.Modules.CartItems.Application.Create;
using SalesSystem.Modules.CartItems.Application.Delete;
using SalesSystem.Modules.CartItems.Application.GetAll;
using SalesSystem.Modules.CartItems.Application.UpdateQyt;
using SalesSystem.Modules.CartItems.Application.CreateTempCartItem;
using SalesSystem.Modules.CartItems.Application.GetAllTempCartItemp;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ShoppingCartController : ApiController
    {
        private readonly ISender _mediator;

        public ShoppingCartController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromBody] GetAllTempCartItemQuery command)
        {
            Claim? cartClaim = User.Claims.FirstOrDefault(u => u.Type == "CartId");
            ErrorOr<IReadOnlyList<CartItemResponseDto>> result;
            if (cartClaim == null)
            {
                result = await _mediator.Send(command);
            }
            else
            {
                result = await _mediator.Send(new GetAllCartItemQuery(Guid.Parse(cartClaim.Value)));
            }

            return result.Match(items => Ok(items), errors => Problem(errors));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateTempCartItemCommand command)
        {
            Claim? cartClaim = User.Claims.FirstOrDefault(u => u.Type == "CartId");
            if (cartClaim == null)
            {
                var response = await _mediator.Send(command);
                return response.Match(cartId => Ok(cartId), errors => Problem(errors));
            }

            CreateCartItemCommad commando = new(cartClaim.Value, command.ProductId, command.Qty);
            var respon = await _mediator.Send(commando);
            return respon.Match(cartId => Ok(cartId), errors => Problem(errors));
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UpdateCartItemQtyCommand command)
        {
            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(cartItemId => NoContent(), errors => Problem(errors));
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromBody] DeleteCartItemCommand command)
        {
            ErrorOr<Unit> deleteResult = await _mediator.Send(command);

            return deleteResult.Match(cartItemId => NoContent(), errors => Problem(errors));
        }
    }
}
