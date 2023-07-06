using SalesSystem.Modules.Users.Domain;
using SalesSystem.Modules.Users.Domain.Dto;

namespace SalesSystem.Modules.Users.Application.GetAll
{
    public record GetAllUsersQuery() : IRequest<ErrorOr<IReadOnlyList<UserResponseDto>>>;
}
