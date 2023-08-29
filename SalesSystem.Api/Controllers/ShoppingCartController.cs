using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SalesSystem.Modules.CartItems.Domain.Dto;
using SalesSystem.Modules.TempCartItems.Domain.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SalesSystem.Modules.CartItems.Application.Create;
using SalesSystem.Modules.CartItems.Application.Delete;
using SalesSystem.Modules.CartItems.Application.GetAll;
using SalesSystem.Modules.CartItems.Application.UpdateQyt;
using SalesSystem.Modules.TempCartItems.Application.GetAllTempCartItem;
using SalesSystem.Modules.TempCartItems.Application.CreateTempCartItem;
using SalesSystem.Modules.TempCartItems.Application.UpdateTempCartItem;
using SalesSystem.Modules.TempCartItems.Application.DeleteTempCartItem;

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
            if (cartClaim == null)
            {
                ErrorOr<IReadOnlyList<TempCartItemResponseDto>> response = await _mediator.Send(command);
                return response.Match(items => Ok(items), errors => Problem(errors));
            }
            else
            {
                ErrorOr<IReadOnlyList<CartItemResponseDto>> result = await _mediator.Send(new GetAllCartItemQuery(Guid.Parse(cartClaim.Value)));
                return result.Match(items => Ok(items), errors => Problem(errors));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateTempCartItemCommand command)
        {
            Claim? cartClaim = User.Claims.FirstOrDefault(u => u.Type == "CartId");
            if (cartClaim == null)
            {
                ErrorOr<string> response = await _mediator.Send(command);
                return response.Match(cartId => Ok(cartId), errors => Problem(errors));
            }

            CreateCartItemCommad commando = new(cartClaim.Value, command.ProductId, command.Qty);
            ErrorOr<Unit> respon = await _mediator.Send(commando);
            return respon.Match(cartId => Ok(cartId), errors => Problem(errors));
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] UpdateTempCartItempCommand command)
        {
            Claim? cartClaim = User.Claims.FirstOrDefault(u => u.Type == "CartId");
            if (cartClaim == null)
            {
                ErrorOr<Unit> response = await _mediator.Send(command);
                return response.Match(cartItemId => NoContent(), erros => Problem(erros));
            }
            UpdateCartItemQtyCommand commando = new(command.CartItemId, command.Qty);
            ErrorOr<Unit> result = await _mediator.Send(commando);
            return result.Match(cartItemId => NoContent(), errors => Problem(errors));
        }

        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromBody] DeleteTempCartItemCommand command)
        {
            Claim? cartClaim = User.Claims.FirstOrDefault(u => u.Type == "CartId");
            if (cartClaim == null)
            {
                ErrorOr<Unit> response = await _mediator.Send(command);
                return response.Match(cartItemId => NoContent(), erros => Problem(erros));
            }

            DeleteCartItemCommand commando = new(command.CartItemId);
            ErrorOr<Unit> deleteResult = await _mediator.Send(commando);
            return deleteResult.Match(cartItemId => NoContent(), errors => Problem(errors));
        }
    }
}
