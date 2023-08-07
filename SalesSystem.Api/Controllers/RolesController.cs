using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Modules.Roles.Application.Create;

namespace SalesSystem.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class RolesController : ApiController
    {
        private readonly ISender _mediator;

        public RolesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }
    }
}
