using SalesSystem.Modules.Users.Domain.Dto;

namespace SalesSystem.Modules.Users.Application.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<TokenDto>>;
}
