﻿using Microsoft.AspNetCore.Mvc;
using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Application.Create;
using SalesSystem.Modules.Users.Application.GetAll;
using SalesSystem.Modules.Users.Application.GetByEmail;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr<IReadOnlyList<UserResponseDto>> result = await _mediator.Send(new GetAllUsersQuery());

            return result.Match(users => Ok(users), errors => Problem(errors));
        }

        [HttpGet("{emailOrId}")]
        public async Task<IActionResult> GetByEmail(string emailOrId)
        {
            ErrorOr<UserResponseDto> result = await _mediator.Send(new GetUserQuery(emailOrId));

            return result.Match
                (
                    user => Ok(user),
                    errors => Problem(errors)
                 );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            if (command.Password != command.PasswordConfirm) return BadRequest("Passwords do not match");

            ErrorOr<Unit> create = await _mediator.Send(command);
            return create.Match(user => Ok(user), errors => Problem(errors));
        }
    }
}
