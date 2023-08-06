using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserCardRepository
    {
        void Add(UserCard userCard);
        void Delete(UserCard userCard);
        Task<UserCard?> Get(Guid id, string userId);
    }
}
