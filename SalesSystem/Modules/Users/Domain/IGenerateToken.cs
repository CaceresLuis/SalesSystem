using SalesSystem.Modules.Users.Domain.Dto;
using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IGenerateToken
    {
        Task<TokenDto> GetToken(User user);
    }
}
