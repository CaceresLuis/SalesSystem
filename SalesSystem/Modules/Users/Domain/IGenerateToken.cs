using SalesSystem.Modules.Users.Domain.Dto;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IGenerateToken
    {
        TokenDto GetToken(User user);
    }
}
