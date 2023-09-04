using Microsoft.AspNetCore.Authorization;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Application.Get;
using SalesSystem.Modules.Users.Application.Login;
using SalesSystem.Modules.Users.Application.Create;
using SalesSystem.Modules.Users.Application.GetAll;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SalesSystem.Modules.Users.Application.CreatUserCard;
using SalesSystem.Modules.Users.Application.DeleteUserCard;
using SalesSystem.Modules.Users.Application.CreateUserAddres;
using SalesSystem.Modules.Users.Application.DeleteUserAddress;
using SalesSystem.Modules.Users.Application.UpdateUserAddress;

namespace SalesSystem.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ApiController
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            ErrorOr<TokenDto> result = await _mediator.Send(query);

            return result.Match(result => Ok(result), errors => Problem(errors));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr<IReadOnlyList<UserResponseDto>> result = await _mediator.Send(new GetAllUsersQuery());

            return result.Match(users => Ok(users), errors => Problem(errors));
        }

        [HttpGet("{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            ErrorOr<SingleUserResponseDto> result = await _mediator.Send(new GetUserQuery(email));

            return result.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            if (command.Password != command.PasswordConfirm) return BadRequest("Passwords do not match");

            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost("AddUserAddress")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> AddUserAddress([FromBody] CreateUserAddresCommand command)
        {
            System.Security.Claims.Claim mailClaim = User.Claims.FirstOrDefault(u => u.Type == "Email")!;
            if (command.UserEmail != mailClaim.Value)
                return BadRequest("Intestas cambiar la direccion de otro");

            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPut("UpdateUserAddress")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UpdateUserAddressCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpDelete("DeleteUserAddress")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteUserAddress([FromBody] DeleteUserAddressCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpPost("AddUserCard")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> AddUserCard([FromBody] CreateUserCardCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }

        [HttpDelete("DeleteUserCard")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteUserCard([FromBody] DeleteUserCardCommand command)
        {
            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }
    }
}
