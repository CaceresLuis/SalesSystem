using Microsoft.AspNetCore.Mvc;
using SalesSystem.Modules.Buys.Domain.Dto;
using SalesSystem.Modules.Buys.Application.Create;
using SalesSystem.Modules.Buys.Application.GetAll;
using SalesSystem.Modules.Buys.Application.GetById;

namespace SalesSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ApiController
    {
        private readonly ISender _mediator;

        public BuyController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            ErrorOr<IReadOnlyList<BuyResponseDto>> result = await _mediator.Send(new GetAllBuysQuery(userId));

            return result.Match(buys => Ok(buys), errors => Problem(errors));
        }

        [HttpGet("Get/{buyId}")]
        public async Task<IActionResult> Get(Guid buyId)
        {
            ErrorOr<BuyResponseDto> result = await _mediator.Send(new GetByIdBuyQuery(buyId));

            return result.Match(buys => Ok(buys), errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBuyCommand command)
        {
            ErrorOr<Unit> createResult = await _mediator.Send(command);

            return createResult.Match(buyId => Ok(), errors => Problem(errors));
        }
    }
}
