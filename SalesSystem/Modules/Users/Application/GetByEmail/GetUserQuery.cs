﻿using SalesSystem.Modules.Users.Domain.Dto;

namespace SalesSystem.Modules.Users.Application.GetByEmail
{
    public record GetUserQuery(string User) : IRequest<ErrorOr<UserResponseDto>>;
}
