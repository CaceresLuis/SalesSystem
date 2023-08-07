using Microsoft.AspNetCore.Mvc;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Application.Get;
using SalesSystem.Modules.Users.Application.Login;
using SalesSystem.Modules.Users.Application.Create;
using SalesSystem.Modules.Users.Application.GetAll;
using SalesSystem.Modules.Users.Application.CreatUserCard;
using SalesSystem.Modules.Users.Application.DeleteUserCard;
using SalesSystem.Modules.Users.Application.CreateUserAddres;
using SalesSystem.Modules.Users.Application.DeleteUserAddress;
using SalesSystem.Modules.Users.Application.UpdateUserAddress;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            ErrorOr<TokenDto> result = await _mediator.Send(query);

            return result.Match(result => Ok(result), errors => Problem(errors));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr<IReadOnlyList<UserResponseDto>> result = await _mediator.Send(new GetAllUsersQuery());

            return result.Match(users => Ok(users), errors => Problem(errors));
        }

        [HttpGet("{GetByEmail}")]
        public async Task<IActionResult> GetByEmail(string emailOrId)
        {
            ErrorOr<SingleUserResponseDto> result = await _mediator.Send(new GetUserQuery(emailOrId));

            return result.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            if (command.Password != command.PasswordConfirm) return BadRequest("Passwords do not match");

            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost("AddUserAddress")]
        public async Task<IActionResult> AddUserAddress([FromBody] CreateUserAddresCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPut("UpdateUserAddress")]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateUserAddressCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpDelete("DeleteUserAddress")]
        public async Task<IActionResult> DeleteUserAddress([FromBody] DeleteUserAddressCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost("AddUserCard")]
        public async Task<IActionResult> AddUserCard([FromBody] CreateUserCardCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpDelete("DeleteUserCard")]
        public async Task<IActionResult> DeleteUserCard([FromBody] DeleteUserCardCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }
    }
}
