using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using SalesSystem.Modules.Buys.Domain.Dto;
using SalesSystem.Modules.Buys.Application.Create;
using SalesSystem.Modules.Buys.Application.GetAll;
using SalesSystem.Modules.Buys.Application.GetById;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SalesSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BuyController : ApiController
    {
        private readonly ISender _mediator;

        public BuyController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAll()
        {

            Claim mailClaim = User.Claims.FirstOrDefault(u => u.Type == "Email")!;

            ErrorOr<IReadOnlyList<BuyResponseDto>> result = await _mediator.Send(new GetAllBuysQuery(mailClaim.Value));

            return result.Match(buys => Ok(buys), errors => Problem(errors));
        }

        [HttpGet("Get/{buyId}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Get(Guid buyId)
        {
            ErrorOr<BuyResponseDto> result = await _mediator.Send(new GetByIdBuyQuery(buyId));

            return result.Match(buys => Ok(buys), errors => Problem(errors));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create([FromBody] CreateBuyCommand command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(buyId => Ok(), errors => Problem(errors));
        }
    }
}
