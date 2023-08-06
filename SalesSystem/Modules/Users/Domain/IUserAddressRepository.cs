using SalesSystem.Modules.Users.Domain.Entities;

namespace SalesSystem.Modules.Users.Domain
{
    public interface IUserAddressRepository
    {
        void Add(UserAddres userAddres);
        void Delete(UserAddres userAddres);
        void Update(UserAddres userAddres);
        Task<UserAddres?> Get(Guid id, string userId);
    }
}
