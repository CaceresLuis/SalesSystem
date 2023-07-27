using SalesSystem.Modules.Users.Domain.Dto;

namespace SalesSystem.Modules.Users.Application.Get
{
    public record GetUserQuery(string User) : IRequest<ErrorOr<SingleUserResponseDto>>;
}
